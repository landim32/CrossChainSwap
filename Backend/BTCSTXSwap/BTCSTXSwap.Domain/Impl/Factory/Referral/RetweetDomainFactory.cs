using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Referral;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Referral
{
    public class RetweetDomainFactory: IRetweetDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRetweetRepository<IRetweetModel, IRetweetDomainFactory> _repRetweet;

        public RetweetDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IRetweetRepository<IRetweetModel, IRetweetDomainFactory> repRetweet
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repRetweet = repRetweet;
        }

        public IRetweetModel BuildRetweetModel()
        {
            return new RetweetModel(_log, _unitOfWork, _repRetweet);
        }
    }
}
