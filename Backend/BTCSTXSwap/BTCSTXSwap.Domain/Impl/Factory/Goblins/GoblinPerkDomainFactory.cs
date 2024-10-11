using Core.Domain;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Goblins
{
    public class GoblinPerkDomainFactory: IGoblinPerkDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;

        public GoblinPerkDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public IGoblinPerkModel BuildGoblinPerkModel()
        {
            return new GoblinPerkModel(_log, _unitOfWork);
        }
    }
}
