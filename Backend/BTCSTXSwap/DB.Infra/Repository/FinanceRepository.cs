using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class FinanceRepository: IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory>
    {
        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        public FinanceRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        private IFinanceTransactionModel DbToModel(IFinanceDomainFactory factory, Finance info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildFinanceModel();
            md.Id = info.Id;
            md.IdUser = info.IdUser;
            md.Address = info.Address;
            md.InsertDate = info.InsertDate;
            md.Credit = info.Credit;
            md.Debit = info.Debit;
            md.Fee = info.Fee;
            md.Balance = info.Balance;
            md.Gas = info.Gas;
            md.Message = info.Message;
            md.TxHash = info.TxHash;
            md.Status = (FinanceTransactionStatusEnum) info.Status;
            md.Withdrawal = info.Withdrawal == 0 ? false : true;
            return md;
        }

        private void ModelToDb(Finance info, IFinanceTransactionModel md)
        {
            info.Id = md.Id;
            info.IdUser = md.IdUser;
            info.Address = md.Address;
            info.InsertDate = md.InsertDate;
            info.Credit = md.Credit;
            info.Debit = md.Debit;
            info.Fee = md.Fee;
            info.Balance = md.Balance;
            info.Gas = md.Gas;
            info.Message = md.Message;
            info.TxHash = md.TxHash;
            info.Status = (int)md.Status;
            info.Withdrawal = (byte)(md.Withdrawal ? 1 : 0);
        }

        public DateTime? GetLastWithdrawl(long idUser)
        {
            var q = _goblinContext.Finances
                .Where(x => x.IdUser == idUser && x.Debit > 0 && x.Status == (int)FinanceTransactionStatusEnum.Confirmed && x.Withdrawal == 1)
                .OrderByDescending(x => x.InsertDate)
                .Select(x => x.InsertDate);
            if (q.Any())
            {
                return q.FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<IFinanceTransactionModel> ListByUser(IFinanceDomainFactory factory, long idUser, int page, out int balance)
        {
            var q = _goblinContext.Finances
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

        public IEnumerable<IFinanceTransactionModel> GetAll(IFinanceDomainFactory factory)
        {
            var q = _goblinContext.Finances
                .Where(x => x.Credit > 0 && x.TxHash != null)
                .OrderByDescending(x => x.InsertDate);

            return q.ToList().Select(i => DbToModel(factory, i));
        }

        public IEnumerable<IFinanceTransactionModel> ListStarted(IFinanceDomainFactory factory)
        {
            return _goblinContext.Finances
                .Where(x => x.Status == (int)FinanceTransactionStatusEnum.Start)
                .ToList()
                .Select(x => DbToModel(factory, x));
        }

        public IFinanceTransactionModel GetById(IFinanceDomainFactory factory, long id)
        {
            return DbToModel(factory, _goblinContext.Finances.Find(id));
        }

        public IFinanceTransactionModel GetByConfirmedTransationHash(IFinanceDomainFactory factory, string txHash)
        {
            return DbToModel(factory, _goblinContext.Finances
                .Where(x => x.TxHash.ToLower() == txHash.ToLower() && x.Status == (int)FinanceTransactionStatusEnum.Confirmed)
                .FirstOrDefault()
            );
        }

        public long Insert(IFinanceTransactionModel md)
        {
            Finance info = new Finance();
            ModelToDb(info, md);
            _goblinContext.Finances.Add(info);
            _goblinContext.SaveChanges();
            md.Id = info.Id;
            return info.Id;
        }

        public long Update(IFinanceTransactionModel md)
        {
            Finance info = _goblinContext.Finances.Find(md.Id);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
            return info.Id;
        }

        public decimal GetGobi(long idUser)
        {
            var user = _goblinContext.Users.Find(idUser);
            return user != null ? user.Gobi : 0;
        }

        public void UpdateGobi(long idUser, decimal value)
        {
            var info = _goblinContext.Users.Find(idUser);
            if (info == null)
            {
                throw new Exception(string.Format("User not found with Id {0}", idUser));
            }
            info.Gobi += value;
            _goblinContext.SaveChanges();
        }

        public bool CanWithdrawal(long idUser)
        {
            var user = _goblinContext.Users.Find(idUser);
            return user != null ? user.CanWithdrawal : false;
        }

        public decimal GetTotalCredit(long idUser)
        {
            var finances = _goblinContext.Finances.Where(x => x.IdUser == idUser && x.Credit > 0 && x.Status == (int)FinanceTransactionStatusEnum.Confirmed);
            if(finances != null && finances.Count() > 0)
            {
                decimal ret = 0;
                foreach(var finance in finances)
                {
                    ret += finance.Credit;
                }
                return ret;
            }
            return 0;
        }

        public void ActiveWithdrawal(long idUser)
        {
            var info = _goblinContext.Users.Find(idUser);
            if (info != null)
            {
                info.CanWithdrawal = true;
                _goblinContext.SaveChanges();
            }
        }

        public void SavePendingTransaction(long idUser, string transHash, decimal value)
        {
            _goblinContext.PendingTransactions.Add(new PendingTransaction
            {
                IdUser = idUser,
                InsertDate =  DateTime.Now,
                TxHash = transHash,
                Value = value
            });
        }
    }
}
