using System;
using Core.Domain;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;

namespace BTCSTXSwap.Domain.Impl.Factory.Goblins
{
    public class GoblinDNADomainFactory : IGoblinDNADomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> _contractGoblin;
        // private readonly IBornContract _bornContract;

        //public GoblinDNADomainFactory(ILogCore log, IUnitOfWork unitOfWork, IBornContract bornContract)
        public GoblinDNADomainFactory(ILogCore log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            //_contractGoblin = contractGoblin;
            //_bornContract = bornContract;
        }

        public IGoblinDNA BuildGoblinModel()
        {
            return new GoblinDNA(_log, _unitOfWork);
        }
    }
}
