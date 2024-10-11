using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Referral
{
    public class ReferralUserRepository : IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public ReferralUserRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IReferralUserModel DbToModel(IReferralUserDomainFactory factory, User info, int goblinQtdy)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildReferralUserModel();
            md.IdUser = info.Id;
            md.PublicAddress = info.PublicAddress;
            md.Name = info.Name;
            md.GoblinQtdy = goblinQtdy;
            return md;
        }

        public IEnumerable<IReferralUserModel> ListByUser(IReferralUserDomainFactory factory, long idUser)
        {
            return _goblinContext.Users.Where(x => x.IdReferral == idUser).Select(x => new
            {
                IdUser = x.Id,
                GoblinQtdy = x.Goblins != null ? x.Goblins.Count() : 0
            }).ToList()
            .Select(x => DbToModel(factory, _goblinContext.Users.Find(x.IdUser), x.GoblinQtdy));
        }
    }
}
