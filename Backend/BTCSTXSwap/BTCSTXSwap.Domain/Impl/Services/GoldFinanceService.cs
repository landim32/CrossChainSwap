using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Finance;
using Microsoft.Extensions.Configuration;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoldFinanceService : IGoldFinanceService
    {

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGLogService _logService;
        private readonly IGoldTransactionDomainFactory _goldTransactionDomainFactory;
        private readonly IConfigurationService _configurationService;
        private readonly IFinanceService _financeService;
        private IConfiguration _configuration;

        private const string LOG_SWAP_GOLD = "Swap __GOLD({0})__ per __GOBI({1})__ - __GOBI({2})__ (Fee).";
        private const string LOG_SWAP_GOBI = "Swap __GOBI({0})__ per __GOLD({1})__ - __GOLD({2})__ (Fee).";

        public GoldFinanceService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGLogService logService,
            IGoldTransactionDomainFactory goldTransactionDomainFactory,
            IConfigurationService configurationService,
            IFinanceService financeService,
            IConfiguration configuration
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goldTransactionDomainFactory = goldTransactionDomainFactory;
            _logService = logService;
            _configurationService = configurationService;
            _financeService = financeService;
            _configuration = configuration;
        }

        public decimal GetUserGoldBalance(long idUser)
        {
            return _goldTransactionDomainFactory.BuildGoldTransactionModel().GetUserGoldBalance(idUser);
        }

        public GoldTransactionListResult ListByUser(long idUser, int page)
        {
            int balance = 0;
            var transactions = _goldTransactionDomainFactory.BuildGoldTransactionModel()
                .ListByUser(idUser, page, out balance)?.Select(x => x.GoldTransaction) ?? new List<GoldTransactionInfo>();

            return new GoldTransactionListResult
            {
                Transactions = transactions,
                TotalPages = (int)Math.Ceiling((decimal)balance / int.Parse(_configuration["Contract:ItensForPage"])),
                Page = page
            };
        }

        private void AddGold(long idUser, decimal gold, string msg)
        {
            var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
            md.GoldTransaction.IdUser = idUser;
            md.GoldTransaction.InsertDate = DateTime.Now;
            md.GoldTransaction.Status = DTO.Enum.GoldTransactionEnum.Transaction;
            if (gold >= 0)
            {
                md.GoldTransaction.Credit = gold;
            }
            else
            {
                md.GoldTransaction.Debit = gold * -1;
            }
            _logService.AddLog(idUser, msg, Core.LogType.Gold);
            md.Save();
        }

        public void AddGoldTransaction(long idUser, decimal gold, string msg, bool usingTransaction = true)
        {
            if (!usingTransaction)
            {
                AddGold(idUser, gold, msg);
                return;
            }

            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    AddGold(idUser, gold, msg);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public decimal GetGobiPerGold(decimal gobi)
        {
            var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
            var totalGold = md.GetTotalGold();
            var totalGobi = md.GetTotalGOBI();
            return totalGold / (totalGobi + gobi);
        }

        public decimal GetGoldPerGobi(decimal gold)
        {
            var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
            var totalGold = md.GetTotalGold();
            var totalGobi = md.GetTotalGOBI();
            return totalGobi / (totalGold + gold);
        }

        public decimal GetTotalGold()
        {
            var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
            return md.GetTotalGold();
        }

        public decimal GetTotalGobi()
        {
            var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
            return md.GetTotalGOBI();
        }

        public void SwapGOBIForGold(long userId, decimal gobi)
        {
            var tax = _configurationService.GetSwapTax();
            using (var transaction = _unitOfWork.BeginTransaction())
                try
                {
                    if (gobi <= 0)
                        throw new Exception("Invalid gobi value.");
                    var userBalance = _financeService.GetGobiOnCloud(userId);
                    if (userBalance < gobi)
                        throw new Exception("Insuffient balance of GOBI.");
                    var lastSwap = _goldTransactionDomainFactory.BuildGoldTransactionModel().GetLastGOBISwap(userId);
                    if(lastSwap != null && lastSwap.GoldTransaction.InsertDate.AddHours(1) > DateTime.Now)
                        throw new Exception("Only one swap per hour is allowed.");

                    var swapRate = GetGobiPerGold(gobi);
                    var qtdeGold = gobi * swapRate;
                    var qtdeTax = (qtdeGold * (decimal.Parse(tax.ToString()) / 100));
                    var qtdeGoldLiquid = qtdeGold - qtdeTax;

                    if (qtdeGold > GetTotalGold())
                        throw new Exception("Insufficient balance of gold for swap");

                    _financeService.DebitGobi(userId, gobi, 0, string.Format(LOG_SWAP_GOBI, gobi, qtdeGoldLiquid, qtdeTax), Core.LogType.Swap);

                    var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
                    md.GoldTransaction.IdUser = userId;
                    md.GoldTransaction.InsertDate = DateTime.Now;
                    md.GoldTransaction.Status = DTO.Enum.GoldTransactionEnum.GobiForGold;
                    md.GoldTransaction.Credit = qtdeGoldLiquid;
                    md.GoldTransaction.Debit = 0;
                    md.GoldTransaction.TransactionGoldTax = qtdeTax;
                    //Only for historic and validation
                    md.GoldTransaction.GobiCredit = 0;
                    md.GoldTransaction.GobiDebit = gobi;
                    md.GoldTransaction.TransactionGobiTax = 0;
                    md.Save();

                    //Pool Transaction
                    var mdCenter = _goldTransactionDomainFactory.BuildGoldTransactionModel();
                    mdCenter.GoldTransaction.IdUser = null;
                    mdCenter.GoldTransaction.InsertDate = DateTime.Now;
                    mdCenter.GoldTransaction.Status = DTO.Enum.GoldTransactionEnum.GobiForGold;
                    mdCenter.GoldTransaction.Credit = 0;
                    mdCenter.GoldTransaction.Debit = qtdeGold;
                    mdCenter.GoldTransaction.GobiCredit = gobi;
                    mdCenter.GoldTransaction.GobiDebit = 0;
                    mdCenter.Save();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
        }

        public void SwapGoldForGOBI(long userId, decimal gold)
        {
            var tax = _configurationService.GetSwapTax();
            var limit = _configurationService.GetSwapGobiDailyLimit();
            using (var transaction = _unitOfWork.BeginTransaction())
                try
                {
                    if(gold <= 0)
                        throw new Exception("Invalid gold value.");

                    var userBalance = GetUserGoldBalance(userId);
                    if (userBalance < gold)
                        throw new Exception("Insuffient balance of Gold.");
                    var lastSwap = _goldTransactionDomainFactory.BuildGoldTransactionModel().GetLastGoldSwap(userId);
                    if (lastSwap != null && lastSwap.GoldTransaction.InsertDate.AddHours(1) > DateTime.Now)
                        throw new Exception("Only one swap per hour is allowed.");

                    if(_goldTransactionDomainFactory.BuildGoldTransactionModel().GetBalanceOfGobiSwapInTheLastDay(userId) > limit)
                        throw new Exception("Daily GOBI exchange limit of " + limit + " exceeded.");

                    var swapRate = GetGoldPerGobi(gold);
                    var qtdeGobi = gold * swapRate;
                    var qtdeTax = (qtdeGobi * (decimal.Parse(tax.ToString()) / 100));
                    var qtdeGobiLiquid = qtdeGobi - qtdeTax;

                    if (qtdeGobi > GetTotalGobi())
                        throw new Exception("Insufficient balance of gobi for swap");

                    var md = _goldTransactionDomainFactory.BuildGoldTransactionModel();
                    md.GoldTransaction.IdUser = userId;
                    md.GoldTransaction.InsertDate = DateTime.Now;
                    md.GoldTransaction.Status = DTO.Enum.GoldTransactionEnum.GoldForGobi;
                    md.GoldTransaction.Credit = 0;
                    md.GoldTransaction.TransactionGoldTax = 0;
                    md.GoldTransaction.Debit = gold;
                    //Only for historic and validation
                    md.GoldTransaction.GobiCredit = qtdeGobiLiquid;
                    md.GoldTransaction.TransactionGobiTax = qtdeTax;
                    md.GoldTransaction.GobiDebit = 0;
                    md.Save();

                    //Pool Transaction
                    var mdCenter = _goldTransactionDomainFactory.BuildGoldTransactionModel();
                    mdCenter.GoldTransaction.IdUser = null;
                    mdCenter.GoldTransaction.InsertDate = DateTime.Now;
                    mdCenter.GoldTransaction.Status = DTO.Enum.GoldTransactionEnum.GobiForGold;
                    mdCenter.GoldTransaction.Credit = gold;
                    mdCenter.GoldTransaction.Debit = 0;
                    mdCenter.GoldTransaction.GobiCredit = 0;
                    mdCenter.GoldTransaction.GobiDebit = qtdeGobi;
                    mdCenter.Save();

                    _financeService.CreditGobi(userId, qtdeGobiLiquid, qtdeTax, string.Format(LOG_SWAP_GOLD, gold, qtdeGobiLiquid, qtdeTax), Core.LogType.Swap);

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
