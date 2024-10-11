using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IFinanceRepository<TModel, TFactory>
    {
        DateTime? GetLastWithdrawl(long idUser);
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser, int page, out int balance);
        IEnumerable<TModel> GetAll(TFactory factory);
        IEnumerable<TModel> ListStarted(TFactory factory);
        TModel GetByConfirmedTransationHash(TFactory factory, string txHash);
        TModel GetById(TFactory factory, long id);
        long Insert(TModel md);
        long Update(TModel md);
        decimal GetGobi(long idUser);
        void UpdateGobi(long idUser, decimal value);
        bool CanWithdrawal(long idUser);
        void ActiveWithdrawal(long idUser);
        decimal GetTotalCredit(long idUser);
        void SavePendingTransaction(long idUser, string transHash, decimal value);
    }
}
