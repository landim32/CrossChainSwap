using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Goblins
{
    public class GoblinIdleDomainFactory : IGoblinIdleDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory> _repositoryGoblinIdle;

        public GoblinIdleDomainFactory(ILogCore log, IUnitOfWork unitOfWork, IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory> repositoryGoblinIdle)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repositoryGoblinIdle = repositoryGoblinIdle;
        }

        public IGoblinIdleModel BuildGoblinIdleModel()
        {
            return new GoblinIdleModel(_log, _unitOfWork, _repositoryGoblinIdle);
        }
    }
}
