using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Referral
{
    public class ReferralUserModel: IReferralUserModel
    {
        public long IdUser { get; set; }
        public string PublicAddress { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int GoblinQtdy { get; set; }
    }
}
