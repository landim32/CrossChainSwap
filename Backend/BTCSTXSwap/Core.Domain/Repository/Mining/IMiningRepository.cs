using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Mining
{
    public interface IMiningRepository<TModel, TFactory>
    {
        int GetHashPower(long idUser);
        int TotalHashPower();
        int MinHashPower();
        int DailyReward();
        IEnumerable<TModel> ListRanking(TFactory factory, int limit);
        TModel GetMining(TFactory factory, long idUser);
        void RefreshProcRanking();
        int GetNumberOfMiningGoblin(long idUser);
    }
}
