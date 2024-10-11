using System;
using System.Collections.Generic;
using Auth.Domain.Impl.Models;
using Auth.Domain.Interfaces.Factory;

namespace Auth.Domain.Interfaces.Models
{
    public interface IUserModel
    {
        long Id { get; set; }
        long IdReferral { get; set; }
        string ReferralCode { get; set; }
        string PublicAddress { get; set; }
        string Hash { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        //decimal Gobi { get; set; }
        int GobBlocked { get; set; }
        DateTime? GobBlockedDate { get; set; }
        DateTime? GobLastClaim { get; set; }
        int Gwb { get; set; }
        DateTime? GwdLastClaim { get; set; }
        DateTime? GoldLastClaim { get; set; }
        StatusEnum Status { get; set; }

        IUserModel Save();
        IUserModel Update();
        IUserModel GetUser(string publicAddress, IUserDomainFactory factory, string fromReferralCode = null);
        IUserModel GetById(long userId, IUserDomainFactory factory);
        IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory);
        long GetIdUserByReferralCode(string refCode);
    }
}
