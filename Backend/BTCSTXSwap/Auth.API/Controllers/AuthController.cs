using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Auth.API.DTOs;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{publicAddress}")]
        [HttpGet("{publicAddress}/{fromReferralCode}")]
        public ActionResult<UserResult> Get(string publicAddress, string fromReferralCode = null)
        {
            try
            {
                var user = _userService.GetUserHash(publicAddress, fromReferralCode);
                if (user == null)
                {
                    return new UserResult() { User = null, Sucesso = true, Mensagem = "Public Address Not Found" };
                }
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        Hash = user.Hash,
                        PublicAddress = user.PublicAddress,
                        Name = user.Name,
                        Email = user.Email
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("checkUserRegister/{publicAddress}")]
        public ActionResult<UserResult> CheckUserRegister(string publicAddress)
        {
            try
            {
                Console.WriteLine("Chegou aqui");
                var user = _userService.GetUser(publicAddress);
                if (user == null)
                {
                    return new UserResult() { User = null, Sucesso = true, Mensagem = "Public Address Not Found" };
                }
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        PublicAddress = user.PublicAddress
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<UserResult> Post(UserParam param)
        {
            try
            {
                if(String.IsNullOrEmpty(param.PublicAddress))
                    return StatusCode(400, "Public Address is empty");
                if (!String.IsNullOrEmpty(param.Email) && !ValidateEmail(param.Email))
                    return StatusCode(400, "Email is invalid");

                var user = _userService.CreateNewUser(new UserInfo
                {
                    FromReferralCode = param.FromReferralCode,
                    Name = param.Name,
                    Email = param.Email,
                    PublicAddress = param.PublicAddress
                });
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        Hash = user.Hash,
                        PublicAddress = user.PublicAddress,
                        Name = user.Name,
                        Email = user.Email
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult<UserResult> UpdateUser(UserParam param)
        {
            try
            {

                var userSession = _userService.GetUserInSession(HttpContext);
                if (userSession == null)
                    return StatusCode(401, "Not Authorized");

                if (!String.IsNullOrEmpty(param.Email) && !ValidateEmail(param.Email))
                    return StatusCode(400, "Email is invalid");

                var user = _userService.UpdateUser(new UserInfo
                {
                    Name = param.Name,
                    Email = param.Email,
                    PublicAddress = userSession.PublicAddress
                });
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        PublicAddress = user.PublicAddress,
                        Name = user.Name,
                        Email = user.Email
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return (address.Address == email);
            }
            catch(Exception)
            {
                return false;
            }
            
        }

    }
}
