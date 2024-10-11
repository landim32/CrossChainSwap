using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IGoldFinanceRepository<TModel, TFactory>
    {
        IEnumerable<TModel> List(TFactory factory, long idUser, int page, out int balance);
        decimal GetBalance(long idUser);
        void Insert(TModel model);
        decimal GetTotalGOBI();
        decimal GetTotalGold();
        TModel GetLastGoldSwap(TFactory factory, long idUser);
        TModel GetLastGOBISwap(TFactory factory, long idUser);
        decimal GetBalanceOfGobiSwapInTheLastDay(long idUser);
    }
}
