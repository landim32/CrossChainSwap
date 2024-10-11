using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Mining
{
    public interface IMiningModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        DateTime LastMining { get; set; }
        string Name { get; set; }
        int HashPower { get; set; }
        int GoblinQtde { get; set; }
        decimal RewardPerMonth { get; set; }
        decimal RewardPerSecond { get; set; }
        long? HashforWeek { get; set; }
        long? HashForMonth { get; set; }
        decimal Gobi { get; set; }

        IEnumerable<IMiningModel> ListRanking(int limit);
        IMiningModel GetMining(long idUser);
        int GetHashPower(long idUser);
        int MinHashPower();
        int TotalHashPower();
        int DailyReward();
        int GoblinMining(long idUser);
        void RefreshMining();
    }
}
