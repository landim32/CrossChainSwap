using Core.Domain;
using Core.Domain.Repository.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Mining
{
    public class MiningHistoryModel: IMiningHistoryModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMiningHistoryDomainFactory _miningFactory;
        private readonly IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory> _miningRep;

        public MiningHistoryModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMiningHistoryDomainFactory miningFactory,
            IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory> miningRep
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _miningFactory = miningFactory;
            _miningRep = miningRep;
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Name { get; set; }
        public MiningRewardTypeEnum RewardType { get; set; }
        public DateTime RewardDate { get; set; }
        public int Ranking { get; set; }
        public int GoblinQtde { get; set; }
        public int HashPower { get; set; }
        public long? HashForWeek { get; set; }
        public long? HashForMonth { get; set; }
        public GoboxEnum BoxType { get; set; }
        public bool Claimed { get; set; }

        public IMiningHistoryModel GetById(long idMiningHistory)
        {
            return _miningRep.GetById(_miningFactory, idMiningHistory);
        }
        public IEnumerable<DateTime> ListHistoryDate(MiningRewardTypeEnum miningType)
        {
            return _miningRep.ListHistoryDate((char)miningType);
        }
        public IEnumerable<IMiningHistoryModel> ListHistory(MiningRewardTypeEnum miningTypeEnum, DateTime rewardDate)
        {
            return _miningRep.ListHistory(_miningFactory, (char)miningTypeEnum, rewardDate);
        }
        public IEnumerable<IMiningHistoryModel> ListHistoryByUser(long idUser)
        {
            return _miningRep.ListHistoryByUser(_miningFactory, idUser);
        }
        public void DoClaimed(long idMiningHistory)
        {
            _miningRep.Claimed(idMiningHistory);
        }
    }
}
