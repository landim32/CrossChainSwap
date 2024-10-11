using BTCSTXSwap.Domain.Impl.Models.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Referral
{
    public class ReferralUserDomainFactory: IReferralUserDomainFactory
    {
        public IReferralUserModel BuildReferralUserModel()
        {
            return new ReferralUserModel();
        }
    }
}
