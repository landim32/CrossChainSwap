using Core.Domain.Repository.Mining;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Mining
{
    public class MiningHistoryRepository: IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public MiningHistoryRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IMiningHistoryModel DbToModel(IMiningHistoryDomainFactory factory, MiningHistory info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildMiningHistoryModel();
            md.Id = info.Id;
            md.IdUser = info.IdUser;
            md.Name = info.IdUserNavigation.Name;
            if (info.RewardType != null && info.RewardType.Length > 0)
            {
                md.RewardType = (MiningRewardTypeEnum)info.RewardType[0];
            }
            md.RewardDate = info.RewardDate;
            md.Ranking = info.Ranking;
            md.GoblinQtde = info.GoblinQtde;
            md.HashPower = info.HashPower;
            md.HashForWeek = info.HashForWeek;
            md.HashForMonth = info.HashForMonth;
            md.BoxType = (GoboxEnum) info.BoxType;
            md.Claimed = info.Claimed;
            return md;
        }
        public IMiningHistoryModel GetById(IMiningHistoryDomainFactory factory, long idMiningHistory)
        {
            return DbToModel(factory, _goblinContext.MiningHistories.Find(idMiningHistory));
        }

        public IEnumerable<DateTime> ListHistoryDate(char miningType)
        {
            return _goblinContext.MiningHistories
                .Where(x => x.RewardType == miningType.ToString())
                .OrderByDescending(x => x.RewardType)
                .Select(x => x.RewardDate)
                .Distinct()
                .ToList();
        }
        public IEnumerable<IMiningHistoryModel> ListHistory(IMiningHistoryDomainFactory factory, char miningTypeEnum, DateTime rewardDate)
        {
            return _goblinContext.MiningHistories
                .Where(x => x.RewardType == miningTypeEnum.ToString() && x.RewardDate == rewardDate)
                .OrderByDescending(x => x.RewardType)
                .ToList()
                .Select(x => DbToModel(factory, x));
        }
        public IEnumerable<IMiningHistoryModel> ListHistoryByUser(IMiningHistoryDomainFactory factory, long idUser)
        {
            return _goblinContext.MiningHistories
                .Where(x => x.IdUser == idUser)
                .ToList()
                .Select(x => DbToModel(factory, x));
        }
        public void Claimed(long idMiningHistory)
        {
            var info = _goblinContext.MiningHistories.Find(idMiningHistory);
            if (info == null)
            {
                throw new Exception("Mining History not found.");
            }
            if (info.Claimed)
            {
                throw new Exception("Reward has already been claimed.");
            }
            info.Claimed = true;
            _goblinContext.Update(info);
            _goblinContext.SaveChanges();
        }
    }
}
