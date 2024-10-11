using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Referral
{
    public interface IReferralUserModel
    {
        long IdUser { get; set; }
        string PublicAddress { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        int GoblinQtdy { get; set; }
    }
}
