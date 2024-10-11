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
    public class MiningDomainFactory : IMiningDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMiningRepository<IMiningModel, IMiningDomainFactory> _repMining;

        public MiningDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMiningRepository<IMiningModel, IMiningDomainFactory> repMining
        ) {
            _log = log;
            _unitOfWork = unitOfWork;
            _repMining = repMining;
        }

        public IMiningModel BuildMiningModel()
        {
            return new MiningModel(_log, _unitOfWork, this, _repMining);
        }
    }
}
