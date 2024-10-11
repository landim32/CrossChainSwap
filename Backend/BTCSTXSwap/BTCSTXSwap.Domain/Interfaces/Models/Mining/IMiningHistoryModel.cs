using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Mining
{
    public interface IMiningHistoryModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        string Name { get; set; }
        MiningRewardTypeEnum RewardType { get; set; }
        DateTime RewardDate { get; set; }
        int Ranking { get; set; }
        int GoblinQtde { get; set; }
        int HashPower { get; set; }
        long? HashForWeek { get; set; }
        long? HashForMonth { get; set; }
        GoboxEnum BoxType { get; set; }
        bool Claimed { get; set; }

        IMiningHistoryModel GetById(long idMiningHistory);
        IEnumerable<DateTime> ListHistoryDate(MiningRewardTypeEnum miningType);
        IEnumerable<IMiningHistoryModel> ListHistory(MiningRewardTypeEnum miningTypeEnum, DateTime rewardDate);
        IEnumerable<IMiningHistoryModel> ListHistoryByUser(long idUser);
        void DoClaimed(long idMiningHistory);
    }
}
