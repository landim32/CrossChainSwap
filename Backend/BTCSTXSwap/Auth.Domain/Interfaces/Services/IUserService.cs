using System;
using System.Collections.Generic;
using Auth.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.User;
using Microsoft.AspNetCore.Http;

namespace Auth.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IUserModel CreateNewUser(UserInfo user);
        IUserModel UpdateUser(UserInfo user);
        IUserModel GetUser(string publicAddress);
        IEnumerable<IUserModel> GetAllUserAddress();
        IUserModel GetUSerByID(long userId);
        IUserModel GetUserHash(string publicAddress, string fromReferralCode = null);
        UserInfo GetUserInSession(HttpContext httpContext);

    }
}
