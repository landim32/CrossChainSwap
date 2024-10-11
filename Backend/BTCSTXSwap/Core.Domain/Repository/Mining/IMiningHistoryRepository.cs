using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Mining
{
    public interface IMiningHistoryRepository<TModel, TFactory>
    {
        TModel GetById(TFactory factory, long idMiningHistory);
        IEnumerable<DateTime> ListHistoryDate(char miningType);
        IEnumerable<TModel> ListHistory(TFactory factory, char miningType, DateTime rewardDate);
        IEnumerable<TModel> ListHistoryByUser(TFactory factory, long idUser);
        void Claimed(long idMiningHistory);
    }
}
