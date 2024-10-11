using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.WithDraw
{
    public interface IFinanceTransactionModel
    {
		long Id { get; set; }
		long IdUser { get; set; }
		string Address { get; set; }
		DateTime InsertDate { get; set; }
		decimal Credit { get; set; }
		decimal Debit { get; set; }
		decimal? Fee { get; set; }
		decimal Balance { get; set; }
		decimal? Gas { get; set; }
		string Message { get; set; }
		string TxHash { get; set; }
		FinanceTransactionStatusEnum Status { get; set; }
		bool Withdrawal { get; set; }

		bool CanWithdrawal(long _idUser);
		void ActiveWithdrawal(long _idUser);
		decimal GetGobi(long idUser);
		void UpdateGobi(long idUser, decimal value);
		DateTime? GetLastWithdrawl();
		IEnumerable<IFinanceTransactionModel> ListStarted();
		IEnumerable<IFinanceTransactionModel> ListByUser(long idUser, int page, out int balance);
		IEnumerable<IFinanceTransactionModel> GetAll();
		IFinanceTransactionModel GetByConfirmedTransationHash(string txHash);
		IFinanceTransactionModel GetById(long id);
		decimal GetTotalCredit(long idUser);
		void Save();
		void SavePendingTransaction(long idUser, string transHash, decimal value);

	}
}
