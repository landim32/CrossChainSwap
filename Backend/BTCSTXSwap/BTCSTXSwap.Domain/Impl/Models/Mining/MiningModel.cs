using Core.Domain;
using Core.Domain.Repository;
using Core.Domain.Repository.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Mining
{
    public class MiningModel: IMiningModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMiningDomainFactory _miningFactory;
        private readonly IMiningRepository<IMiningModel, IMiningDomainFactory> _miningRep;

        public MiningModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMiningDomainFactory miningFactory,
            IMiningRepository<IMiningModel, IMiningDomainFactory> miningRep
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _miningFactory = miningFactory;
            _miningRep = miningRep;
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime LastMining { get; set; }
        public string Name { get; set; }
        public int HashPower { get; set; }
        public int GoblinQtde { get; set; }
        public decimal RewardPerMonth { get; set; }
        public decimal RewardPerSecond { get; set; }
        public long? HashforWeek { get; set; }
        public long? HashForMonth { get; set; }
        public decimal Gobi { get; set; }

        public IEnumerable<IMiningModel> ListRanking(int limit)
        {
            return _miningRep.ListRanking(_miningFactory, limit);
        }
        public IMiningModel GetMining(long idUser)
        {
            //_miningRep.RefreshProcRanking();
            return _miningRep.GetMining(_miningFactory, idUser);
        }
        public int GetHashPower(long idUser)
        {
            return _miningRep.GetHashPower(idUser);
        }
        public int MinHashPower()
        {
            return _miningRep.MinHashPower();
        }
        public int TotalHashPower() {
            return _miningRep.TotalHashPower();
        }
        public int DailyReward()
        {
            return _miningRep.DailyReward();
        }

        public int GoblinMining(long idUser)
        {
            return _miningRep.GetNumberOfMiningGoblin(idUser);
        }

        public void RefreshMining()
        {
            _miningRep.RefreshProcRanking();
        }
    }
}
