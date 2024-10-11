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
    public class ReferralDomainFactory: IReferralDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRetweetDomainFactory _retweetFactory;
        private readonly IReferralUserDomainFactory _refUserFactory;
        private readonly IReferralRepository<IReferralModel, IReferralDomainFactory> _repReferral;
        private readonly IRetweetRepository<IRetweetModel, IRetweetDomainFactory> _repRetweet;
        private readonly IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory> _repRefUser;

        public ReferralDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IRetweetDomainFactory retweetFactory,
            IReferralUserDomainFactory refUserFactory,
            IReferralRepository<IReferralModel, IReferralDomainFactory> repReferral,
            IRetweetRepository<IRetweetModel, IRetweetDomainFactory> repRetweet,
            IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory> repRefUser
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _retweetFactory = retweetFactory;
            _refUserFactory = refUserFactory;
            _repReferral = repReferral;
            _repRetweet = repRetweet;
            _repRefUser = repRefUser;
        }

        public IReferralModel BuildReferralModel()
        {
            return new ReferralModel(
                _log, _unitOfWork, this, _retweetFactory, _refUserFactory, 
                _repReferral, _repRetweet, _repRefUser
            );
        }
    }
}
