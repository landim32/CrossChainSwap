using System;
using System.Collections.Generic;
using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.DTO.User;
using Microsoft.AspNetCore.Http;

namespace NoChainSwap.Domain.Interfaces.Services
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
