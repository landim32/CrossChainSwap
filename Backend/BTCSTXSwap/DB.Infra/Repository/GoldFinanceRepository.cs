using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.DTO.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class GoldFinanceRepository: IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory>
    {
        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        public GoldFinanceRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        private IGoldTransactionModel DbToModel(IGoldTransactionDomainFactory factory, GoldFinance info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildGoldTransactionModel();
            md.GoldTransaction.Id = info.Id;
            md.GoldTransaction.IdUser = info.IdUser;
            md.GoldTransaction.InsertDate = info.InsertDate;
            md.GoldTransaction.Status = (GoldTransactionEnum)info.Status;
            md.GoldTransaction.Credit = info.Credit;
            md.GoldTransaction.Debit = info.Debit;
            md.GoldTransaction.TransactionGoldTax = info.TransactionGoldTax;
            md.GoldTransaction.GobiCredit = info.GobiCredit;
            md.GoldTransaction.GobiDebit = info.GobiDebit;
            md.GoldTransaction.TransactionGobiTax = info.TransactionGobiTax;
            return md;
        }

        private void ModelToDb(GoldFinance info, IGoldTransactionModel md)
        {
            info.Id = md.GoldTransaction.Id;
            info.IdUser = md.GoldTransaction.IdUser;
            info.InsertDate = md.GoldTransaction.InsertDate;
            info.Status = (int)md.GoldTransaction.Status;
            info.Credit = md.GoldTransaction.Credit;
            info.Debit = md.GoldTransaction.Debit;
            info.TransactionGoldTax = md.GoldTransaction.TransactionGoldTax;
            info.GobiCredit = md.GoldTransaction.GobiCredit;
            info.GobiDebit = md.GoldTransaction.GobiDebit;
            info.TransactionGobiTax = md.GoldTransaction.TransactionGobiTax;
        }

        public IEnumerable<IGoldTransactionModel> List(IGoldTransactionDomainFactory factory, long idUser, int page, out int balance)
        {

            var q = _goblinContext.GoldFinances
                .Where(x => x.IdUser == idUser)
                .OrderByDescending(x => x.InsertDate);

            int maxPages = int.Parse(_configuration["Contract:ItensForPage"]);
            balance = q.Count();
            int pg = page;
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);
            return q.Skip(skip).Take(maxPages).ToList()
                .Select(i => DbToModel(factory, i));

        }

        public IGoldTransactionModel GetLastGoldSwap(IGoldTransactionDomainFactory factory, long idUser)
        {
            return DbToModel(factory, _goblinContext.GoldFinances
                .Where(x => x.IdUser == idUser && x.Status == (int)GoldTransactionEnum.GoldForGobi)
                .OrderByDescending(x => x.InsertDate).FirstOrDefault());
        }

        public IGoldTransactionModel GetLastGOBISwap(IGoldTransactionDomainFactory factory, long idUser)
        {
            return DbToModel(factory, _goblinContext.GoldFinances
                .Where(x => x.IdUser == idUser && x.Status == (int)GoldTransactionEnum.GobiForGold)
                .OrderByDescending(x => x.InsertDate).FirstOrDefault());
        }

        public decimal GetBalanceOfGobiSwapInTheLastDay(long idUser)
        {
            var lastDay = DateTime.Now.AddHours(-24);
            return _goblinContext.GoldFinances.Where(x => x.IdUser == idUser && x.InsertDate >= lastDay)?.Sum(x => x.GobiDebit) ?? 0;
        }

        public decimal GetBalance(long idUser)
        {
            var transactions = _goblinContext.GoldFinances.Where(x => x.IdUser == idUser).ToList();
            if(transactions == null)
                return 0;
            return GoldTotalCredit(transactions) - GoldTotalDebit(transactions);

        }

        private decimal GoldTotalCredit(IList<GoldFinance> finances)
        {
            return finances.Sum(x => x.Credit);
        }

        private decimal GoldTotalDebit(IList<GoldFinance> finances)
        {
            return finances.Sum(x => x.Debit);
        }

        public void Insert(IGoldTransactionModel model)
        {
            var info = new GoldFinance();
            ModelToDb(info, model);
            _goblinContext.GoldFinances.Add(info);
            _goblinContext.SaveChanges();
        }

        public decimal GetTotalGOBI()
        {
            return _goblinContext.GoldFinances.Where(x => x.IdUser == null).Sum(x => (x.GobiCredit ?? 0) - (x.GobiDebit ?? 0) );
        }

        public decimal GetTotalGold()
        {
            return _goblinContext.GoldFinances.Where(x => x.IdUser == null).Sum(x => x.Credit - x.Debit);
        }
    }
}
