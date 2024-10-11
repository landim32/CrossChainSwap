using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Referral
{
    public interface IReferralModel
    {
        long IdUser { get; set; }
        string ReferralCode { get; set; }
        string Name { get; set; }
        string PublicAddress { get; set; }
        string Email { get; set; }
        string TwitterId { get; set; }
        string FacebookId { get; set; }
        string DiscordId { get; set; }
        string TelegramId { get; set; }
        IEnumerable<IRetweetModel> ListRetweets();
        IEnumerable<IReferralUserModel> ListUserReferral();
        void Update();

        IReferralModel GetReferral(long idUser);
    }
}
