using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.User;
using Microsoft.AspNetCore.Http;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IUserModel CreateNewUser(UserInfo user);
        IUserModel UpdateUser(UserInfo user);
        IUserModel GetUser(string btcAddress, string stxAddress);
        IEnumerable<IUserModel> GetAllUserAddress();
        IUserModel GetUSerByID(long userId);
        IUserModel GetUserHash(string btcAddress, string stxAddress);
        UserInfo GetUserInSession(HttpContext httpContext);

    }
}
