using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Auth.Domain.Impl.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDomainFactory _userFactory;

        public UserService(IUserDomainFactory userFactory)
        {
            _userFactory = userFactory;
        }

        public IUserModel CreateNewUser(UserInfo user)
        {
            try
            {
                var model = _userFactory.BuildUserModel();
                model.PublicAddress = user.PublicAddress;
                model.Email = user.Email;
                model.Name = user.Name;
                model.Hash = GetUniqueToken();
                model.Status = Models.StatusEnum.Active;

                if (!string.IsNullOrEmpty(user.FromReferralCode)) {
                    model.IdReferral = model.GetIdUserByReferralCode(user.FromReferralCode);
                }

                model.Save();

                if(String.IsNullOrEmpty(user.Name))
                {
                    model.Name = "Goblin Master " + model.Id;
                    model.Update();
                }

                return model;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IUserModel UpdateUser(UserInfo user)
        {
            try
            {
                var model = _userFactory.BuildUserModel().GetUser(user.PublicAddress, _userFactory);
                model.PublicAddress = user.PublicAddress;
                model.Email = user.Email;
                model.Name = user.Name;
                model.Update();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel GetUser(string publicAddress)
        {
            try
            {
                return _userFactory.BuildUserModel().GetUser(publicAddress, _userFactory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel GetUSerByID(long userId)
        {
            try
            {
                return _userFactory.BuildUserModel().GetById(userId, _userFactory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel GetUserHash(string publicAddress, string fromReferralCode = null)
        {
            try
            {
                var user = _userFactory.BuildUserModel().GetUser(publicAddress, _userFactory, fromReferralCode);
                if (user != null)
                {
                    /*
                    var newUser = _userFactory.BuildUserModel();
                    newUser.PublicAddress = user.PublicAddress;
                    newUser.Id = user.Id;
                    newUser.Hash = GetUniqueToken();
                    newUser.Name = user.Name;
                    newUser.Email = user.Email;
                    newUser.Gobi = user.Gobi;
                    return newUser.Update();
                    */
                    user.Hash = GetUniqueToken();
                    return user.Update();
                } 
                else
                {
                    return user;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public UserInfo GetUserInSession(HttpContext httpContext)
        {
            try
            {
                if (httpContext.User.Claims.Count() > 0)
                {
                    return JsonConvert.DeserializeObject<UserInfo>(httpContext.User.Claims.First().Value);
                }
                return null;
            }
            catch(Exception err)
            {
                return null;
            }
            
        }
        private string GetUniqueToken()
        {
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                int length = 100;
                string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";
                byte[] data = new byte[length];

                // If chars.Length isn't a power of 2 then there is a bias if we simply use the modulus operator. The first characters of chars will be more probable than the last ones.
                // buffer used if we encounter an unusable random byte. We will regenerate it in this buffer
                byte[] buffer = null;

                // Maximum random number that can be used without introducing a bias
                int maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);

                crypto.GetBytes(data);

                char[] result = new char[length];

                for (int i = 0; i < length; i++)
                {
                    byte value = data[i];

                    while (value > maxRandom)
                    {
                        if (buffer == null)
                        {
                            buffer = new byte[1];
                        }

                        crypto.GetBytes(buffer);
                        value = buffer[0];
                    }

                    result[i] = chars[value % chars.Length];
                }

                return new string(result);
            }
        }

        public IEnumerable<IUserModel> GetAllUserAddress()
        {
            return _userFactory.BuildUserModel().ListUsers(_userFactory);
        }
    }
}
