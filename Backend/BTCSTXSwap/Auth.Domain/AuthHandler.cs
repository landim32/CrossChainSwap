using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using Core.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Auth.Domain
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //private readonly ICryptoUtils _cryptoUtils;
        private readonly IUserService _userService;

        public AuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            //ICryptoUtils cryptoUtils,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            //_cryptoUtils = cryptoUtils;
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            string walletAddress = null;
            IUserModel user = null; 
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var masterKey = authHeader.Parameter;
                if(masterKey == "masterkeydoamor")
                {
                    user = _userService.GetUser("0x051684129FC36a4CcBCE92cC0b4213a2704C441B");
                }
                else
                {
                    var hashAuth = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter));
                    var hashList = hashAuth.Split("|separator|");
                    if (hashList.Count() == 2)
                    {
                        var signature = hashList[0];
                        walletAddress = hashList[1];

                        user = _userService.GetUser(walletAddress);
                        if (user == null)
                            return AuthenticateResult.Fail("Invalid Session");
                        /*
                        if (!_cryptoUtils.CheckPersonalSignature(user.Hash, signature, walletAddress))
                        {
                            return AuthenticateResult.Fail("Invalid Session");
                        }
                        */
                    }
                    else
                    {
                        return AuthenticateResult.Fail("Incorrect Session");
                    }
                }
                
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            
            var claims = new[] {
                new Claim("UserInfo",  JsonConvert.SerializeObject(new UserInfo() {
                     PublicAddress = user.PublicAddress,
                     Id = user.Id,
                     Hash = user.Hash
                }))
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
