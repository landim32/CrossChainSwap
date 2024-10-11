using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IRechargeRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListUserGoblin(TFactory factory, long idUser);
        TModel GetGoblin(TFactory factory, long idGoblin);
        decimal DoRecharge(long idGoblin, long idUser, TFactory factory, bool free = false);
        decimal RechargeAll(long idUser, TFactory factory);
        void RestartCharge(long idGoblin);
        void StopCharge(long idGoblin);
        bool HasRecharge(long idGoblin);
    }
}
