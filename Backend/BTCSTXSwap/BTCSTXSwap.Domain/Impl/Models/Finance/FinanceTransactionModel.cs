using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Finance
{
    public class FinanceTransactionModel: IFinanceTransactionModel
    {
		private readonly ILogCore _log;
		private readonly IUnitOfWork _unitOfWork;
        private readonly IFinanceDomainFactory _financeFactory;
        private readonly IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory> _repFinance;

        public FinanceTransactionModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IFinanceDomainFactory financeFactory,
            IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory> repWithdrawToken
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _financeFactory = financeFactory;
            _repFinance = repWithdrawToken;
        }

        public long Id { get; set; }
		public long IdUser { get; set; }
		public string Address { get; set; }
		public DateTime InsertDate { get; set; }
		public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal? Fee { get; set; }
        public decimal Balance { get; set; }
        public decimal? Gas { get; set; }
        public string Message { get; set; }
        public string TxHash { get; set; }
        public FinanceTransactionStatusEnum Status { get; set; }
        public bool Withdrawal { get; set; }

        public bool CanWithdrawal(long _idUser) {
            return _repFinance.CanWithdrawal(_idUser);
        }

        public void ActiveWithdrawal(long _idUser)
        {
            _repFinance.ActiveWithdrawal(_idUser);
        }

        public decimal GetGobi(long _idUser)
        {
            return _repFinance.GetGobi(_idUser);
        }

        public void UpdateGobi(long _idUser, decimal value)
        {
            _repFinance.UpdateGobi(_idUser, value);
        }

        public DateTime? GetLastWithdrawl()
        {
            return _repFinance.GetLastWithdrawl(this.IdUser);
        }

        public IEnumerable<IFinanceTransactionModel> ListStarted()
        {
            return _repFinance.ListStarted(_financeFactory);
        }

        public IEnumerable<IFinanceTransactionModel> ListByUser(long idUser, int page, out int balance)
        {
            return _repFinance.ListByUser(_financeFactory, idUser, page, out balance);
        }

        public IFinanceTransactionModel GetByConfirmedTransationHash(string txHash)
        {
            return _repFinance.GetByConfirmedTransationHash(_financeFactory, txHash);
        }

        public IEnumerable<IFinanceTransactionModel> GetAll()
        {
            return _repFinance.GetAll(_financeFactory);
        }

        public IFinanceTransactionModel GetById(long id)
        {
            return _repFinance.GetById(_financeFactory, id);
        }

        public decimal GetTotalCredit(long idUser)
        {
            return _repFinance.GetTotalCredit(idUser);
        }

        public void Save()
        {
            if (this.Id > 0)
            {
                _repFinance.Update(this);
            }
            else
            {
                _repFinance.Insert(this);
            }
        }

        public void SavePendingTransaction(long idUser, string transHash, decimal value)
        {
            _repFinance.SavePendingTransaction(idUser, transHash, value);
        }
    }
}
