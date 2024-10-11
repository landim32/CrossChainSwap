using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Referral
{
    public class ReferralModel: IReferralModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferralDomainFactory _referralFactory;
        private readonly IRetweetDomainFactory _retweetFactory;
        private readonly IReferralUserDomainFactory _refUserFactory;
        private readonly IReferralRepository<IReferralModel, IReferralDomainFactory> _repReferral;
        private readonly IRetweetRepository<IRetweetModel, IRetweetDomainFactory> _repRetweet;
        private readonly IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory> _repRefUser;

        public ReferralModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IReferralDomainFactory referralFactory,
            IRetweetDomainFactory retweetFactory,
            IReferralUserDomainFactory refUserFactory,
            IReferralRepository<IReferralModel, IReferralDomainFactory> repReferral,
            IRetweetRepository<IRetweetModel, IRetweetDomainFactory> repRetweet,
            IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory> repRefUser
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _referralFactory = referralFactory;
            _repReferral = repReferral;
            _retweetFactory = retweetFactory;
            _refUserFactory = refUserFactory;
            _repRetweet = repRetweet;
            _repRefUser = repRefUser;
        }

        public long IdUser { get; set; }
        public string ReferralCode { get; set; }
        public string Name { get; set; }
        public string PublicAddress { get; set; }
        public string Email { get; set; }
        public string TwitterId { get; set; }
        public string FacebookId { get; set; }
        public string DiscordId { get; set; }
        public string TelegramId { get; set; }

        public IReferralModel GetReferral(long idUser)
        {
            return _repReferral.GetReferral(_referralFactory, idUser);
        }

        public IEnumerable<IRetweetModel> ListRetweets()
        {
            return _repRetweet.ListByUser(_retweetFactory, IdUser);
        }
        public IEnumerable<IReferralUserModel> ListUserReferral()
        {
            return _repRefUser.ListByUser(_refUserFactory, IdUser);
        }

        public void Update()
        {
            _repReferral.Update(this);
        }
    }
}
