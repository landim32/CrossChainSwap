using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Referral
{
    public class ReferralRepository : IReferralRepository<IReferralModel, IReferralDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public ReferralRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IReferralModel DbToModel(IReferralDomainFactory factory, User info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildReferralModel();
            md.IdUser = info.Id;
            md.ReferralCode = info.ReferralCode;
            md.Name = info.Name;
            md.Email = info.Email;
            md.PublicAddress = info.PublicAddress;
            md.TwitterId = info.TwitterId;
            md.FacebookId = info.FacebookId;
            md.DiscordId = info.DiscordId;
            md.TelegramId = info.TelegramId;
            return md;
        }

        private void ModelToDb(User info, IReferralModel md)
        {
            info.ReferralCode = md.ReferralCode;
            info.Name = md.Name;
            info.Email = md.Email;
            info.TwitterId = md.TwitterId;
            info.FacebookId = md.FacebookId;
            info.DiscordId = md.DiscordId;
            info.TelegramId = md.TelegramId;
        }

        public IReferralModel GetReferral(IReferralDomainFactory factory, long idUser)
        {
            var info = _goblinContext.Users.Find(idUser);
            if (info == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(info.ReferralCode))
            {
                info.ReferralCode = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
                _goblinContext.SaveChanges();
            }
            return DbToModel(factory, info);
        }

        public long Update(IReferralModel md)
        {
            User info = _goblinContext.Users.Find(md.IdUser);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
            return info.Id;
        }
    }
}
