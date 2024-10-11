using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class MaterialMarketRepository : IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory>
    {
        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        public MaterialMarketRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        private IMaterialTradeModel DbToModel(IMaterialTradeDomainFactory factory, MaterialMarket info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildMaterialTradeModel();
            md.TradeInfo.Id = info.Id;
            md.TradeInfo.IdUser = info.IdUser;
            md.TradeInfo.InsertDate = info.InsertDate;
            md.TradeInfo.Status = (MaterialTradeEnum)info.Status;
            md.TradeInfo.MaterialCredit = info.MaterialCredit;
            md.TradeInfo.MaterialDebit = info.MaterialDebit;
            md.TradeInfo.GoldCredit = info.GoldCredit;
            md.TradeInfo.GoldDebit = info.GoldDebit;
            md.TradeInfo.MaterialKey = info.MaterialKey;
            return md;
        }

        private void ModelToDb(MaterialMarket info, IMaterialTradeModel md)
        {
            info.Id = md.TradeInfo.Id;
            info.IdUser = md.TradeInfo.IdUser;
            info.InsertDate = md.TradeInfo.InsertDate;
            info.Status = (int)md.TradeInfo.Status;
            info.MaterialCredit = md.TradeInfo.MaterialCredit;
            info.MaterialDebit = md.TradeInfo.MaterialDebit;
            info.GoldCredit = md.TradeInfo.GoldCredit;
            info.GoldDebit = md.TradeInfo.GoldDebit;
            info.MaterialKey = md.TradeInfo.MaterialKey;
        }

        public void Insert(IMaterialTradeModel model)
        {
            var info = new MaterialMarket();
            ModelToDb(info, model);
            _goblinContext.MaterialMarkets.Add(info);
            _goblinContext.SaveChanges();
        }

        public long GetTotalMaterial(long keyMaterial)
        {
            return _goblinContext.MaterialMarkets.Where(x => x.MaterialKey == keyMaterial).Sum(x => x.MaterialCredit - x.MaterialDebit);
        }

        public decimal GetTotalGoldMaterial(long keyMaterial)
        {
            return _goblinContext.MaterialMarkets.Where(x => x.MaterialKey == keyMaterial).Sum(x => x.GoldCredit - x.GoldDebit);
        }
    }
}
