using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Finance;
using Microsoft.Extensions.Configuration;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class MaterialMarketService : IMaterialMarketService
    {

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGLogService _logService;
        private readonly IMaterialTradeDomainFactory _materialTradeDomainFactory;
        private readonly IConfigurationService _configurationService;
        private readonly IGoldFinanceService _goldFinanceService;
        private readonly IUserItemService _userItemService;
        private IConfiguration _configuration;

        private const string LOG_SWAP_MATERIAL = "Swap __ITEM({0})__ per __GOLD({1})__ - (__GOLD({2})__ tax).";
        private const string LOG_SWAP_GOLD = "Swap __GOLD({0})__ + (__GOLD({1})__ tax) per __ITEM({2})__ .";

        public MaterialMarketService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGLogService logService,
            IMaterialTradeDomainFactory materialTradeDomainFactory,
            IConfigurationService configurationService,
            IConfiguration configuration,
            IGoldFinanceService goldFinanceService,
            IUserItemService userItemService
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _materialTradeDomainFactory = materialTradeDomainFactory;
            _logService = logService;
            _configurationService = configurationService;
            _configuration = configuration;
            _goldFinanceService = goldFinanceService;
            _userItemService = userItemService;
        }


        private decimal GetMaterialPerGold(long itemKey, long qtdeMaterial)
        {
            var md = _materialTradeDomainFactory.BuildMaterialTradeModel();
            var totalMaterial = md.GetTotalMaterial(itemKey);
            var totalGoldMaterial = md.GetTotalGoldMaterial(itemKey);
            return totalGoldMaterial / (totalMaterial + qtdeMaterial);
        }

        private decimal GetGoldPerMaterial(long itemKey, long qtdeMaterial)
        {
            var md = _materialTradeDomainFactory.BuildMaterialTradeModel();
            var totalMaterial = md.GetTotalMaterial(itemKey);
            var totalGoldMaterial = md.GetTotalGoldMaterial(itemKey);
            return totalGoldMaterial / (totalMaterial - qtdeMaterial);
        }

        public long GetTotalMaterial(long materialKey)
        {
            return _materialTradeDomainFactory.BuildMaterialTradeModel().GetTotalMaterial(materialKey);
        }

        public decimal GetTotalGoldMaterial(long materialKey)
        {
            return _materialTradeDomainFactory.BuildMaterialTradeModel().GetTotalGoldMaterial(materialKey);
        }

        public void SwapMaterialForGold(long userId, long materialKey, long qtde)
        {
            var tax = _configurationService.GetSwapMaterialTax();
            using (var transaction = _unitOfWork.BeginTransaction())
                try
                {
                    if (qtde <= 0)
                        throw new Exception("Invalid amount of materials.");
                    var item = _userItemService.GetByKey(userId, materialKey);
                    if (item.Qtde < qtde)
                        throw new Exception("Insuffient balance of materials.");

                    var swapRate = GetMaterialPerGold(materialKey, qtde);
                    var qtdeGold = qtde * swapRate;
                    var goldTax = qtdeGold * (decimal.Parse(tax.ToString()) / 100);

                    //O Gold é inserido sem a taxa, então a taxa não entra na validação.
                    if (qtdeGold > GetTotalGoldMaterial(materialKey))
                        throw new Exception("Insufficient balance of gold for swap");

                    

                    var md = _materialTradeDomainFactory.BuildMaterialTradeModel();
                    md.TradeInfo.IdUser = userId;
                    md.TradeInfo.InsertDate = DateTime.Now;
                    md.TradeInfo.MaterialKey = materialKey;
                    md.TradeInfo.MaterialCredit = qtde;
                    md.TradeInfo.MaterialDebit = 0;
                    md.TradeInfo.GoldCredit = 0;
                    md.TradeInfo.GoldDebit = qtdeGold;
                    md.TradeInfo.Status = DTO.Enum.MaterialTradeEnum.MaterialPerGold;
                    md.Save();

                    _userItemService.Remove(userId, materialKey, (int)qtde);
                    _goldFinanceService.AddGoldTransaction(userId, (qtdeGold - goldTax), string.Format(LOG_SWAP_MATERIAL, materialKey, qtdeGold, goldTax), false);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
        }

        public void SwapGoldForMaterial(long userId, long materialKey, long qtde)
        {
            var tax = _configurationService.GetSwapMaterialTax();
            using (var transaction = _unitOfWork.BeginTransaction())
                try
                {
                    if (qtde <= 0)
                        throw new Exception("Invalid amount of materials.");

                    var swapRate = GetGoldPerMaterial(materialKey, qtde);
                    var qtdeGold = qtde * swapRate;
                    var goldTax = qtdeGold * (decimal.Parse(tax.ToString()) / 100);

                    var userBalance = _goldFinanceService.GetUserGoldBalance(userId);
                    if (userBalance < (qtdeGold + goldTax))
                        throw new Exception("Insuffient balance of Gold.");

                    if (qtde > GetTotalMaterial(materialKey))
                        throw new Exception("Insufficient balance of material for swap");

                    var md = _materialTradeDomainFactory.BuildMaterialTradeModel();
                    md.TradeInfo.IdUser = userId;
                    md.TradeInfo.InsertDate = DateTime.Now;
                    md.TradeInfo.MaterialKey = materialKey;
                    md.TradeInfo.MaterialCredit = 0;
                    md.TradeInfo.MaterialDebit = qtde;
                    md.TradeInfo.GoldCredit = qtdeGold;
                    md.TradeInfo.GoldDebit = 0;
                    md.TradeInfo.Status = DTO.Enum.MaterialTradeEnum.GoldPerMaterial;
                    md.Save();

                    _userItemService.Add(userId, materialKey, (int)qtde);
                    _goldFinanceService.AddGoldTransaction(userId, (qtdeGold + goldTax) * -1, string.Format(LOG_SWAP_GOLD, qtdeGold, goldTax, materialKey), false);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
        }
    }
}
