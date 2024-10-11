using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Mining
{
    public interface IMiningRewardRepository<TModel, TFactory>
    {
        IEnumerable<TModel> List(TFactory factory, long idUser, int limit);
        TModel GetById(TFactory factory, long id);
        decimal GetBalanceClaimable(long idUser);
        void Update(TModel md);
    }
}
