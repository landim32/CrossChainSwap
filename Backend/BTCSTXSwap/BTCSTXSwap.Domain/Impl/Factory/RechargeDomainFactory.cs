using System;
using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;

namespace BTCSTXSwap.Domain.Impl.Factory
{
    public class RechargeDomainFactory : IRechargeDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory> _repRecharge;

        public RechargeDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory> repRecharge
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repRecharge = repRecharge;
        }

        public IGoblinEnergyModel BuildGoblinEnergyModel()
        {
            return new GoblinEnergyModel(_log, _unitOfWork, this, _repRecharge);
        }
    }
}
