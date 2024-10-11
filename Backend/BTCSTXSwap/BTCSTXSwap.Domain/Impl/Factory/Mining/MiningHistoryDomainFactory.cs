using Core.Domain;
using Core.Domain.Repository;
using Core.Domain.Repository.Mining;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Mining
{
    public class MiningHistoryDomainFactory : IMiningHistoryDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory> _repMiningReward;

        public MiningHistoryDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory> repMiningReward
        ) {
            _log = log;
            _unitOfWork = unitOfWork;
            _repMiningReward = repMiningReward;
        }

        public IMiningHistoryModel BuildMiningHistoryModel()
        {
            return new MiningHistoryModel(_log, _unitOfWork, this, _repMiningReward);
        }
    }
}
