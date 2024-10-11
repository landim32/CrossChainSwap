using Core.Domain;
using BTCSTXSwap.Domain.Impl.Models;
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

namespace BTCSTXSwap.Domain.Impl.Factory
{
    [Obsolete]
    public class BalanceDomainFactory : IBalanceDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGobiContract _gobiContract;
        //private readonly IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> _contractGoblin;

        //public BalanceDomainFactory(ILogCore log, IUnitOfWork unitOfWork, IGobiContract gobiContract, IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> contractGoblin)
        public BalanceDomainFactory(ILogCore log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            //_gobiContract = gobiContract;
            //_contractGoblin = contractGoblin;
        }
        public IBalanceModel BuildBalanceModel()
        {
            //return new BalanceModel(_gobiContract, _contractGoblin);
            //return new BalanceModel(_gobiContract, null);
            return null;
        }
    }
}
