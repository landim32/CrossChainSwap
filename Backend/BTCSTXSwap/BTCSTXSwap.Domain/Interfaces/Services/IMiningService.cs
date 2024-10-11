using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.DTO.Mining;
using BTCSTXSwap.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IMiningService
    {
        bool StartMining(long idUser, long tokenId);
        bool StopMining(long idUser, long tokenId);
        MiningInfo GetMining(long idUser);
        void RefreshMining();
        long GetHashPower(long idUser);
        long TotalHashPower();
        int MinHashPower();
        int TotalRewardPerDay();
        MiningListResult ListRanking(long idUser, MiningRewardTypeEnum miningType);
        IList<MiningRewardInfo> ListReward(long idUser);
        void ClaimReward(long idReward);
        IList<DateTime> ListHistoryDate(MiningRewardTypeEnum miningType);
        IList<MiningHistoryInfo> ListHistory(MiningRewardTypeEnum miningTypeEnum, DateTime rewardDate);
        IList<MiningHistoryInfo> ListHistoryByUser(long idUser);
        void ClaimRankingReward(long idUser, long IdMiningHistory);
    }
}
