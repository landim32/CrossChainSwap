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

        [HttpGet("{btcAddress}/{stxAddress}")]
        public ActionResult<UserResult> Get(string btcAddress, string stxAddress)
        {
            try
            {
                var user = _userService.GetUserHash(btcAddress, stxAddress);
                if (user == null)
                {
                    return new UserResult() { User = null, Sucesso = true, Mensagem = "BTC Address Not Found" };
                }
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        Hash = user.Hash,
                        BtcAddress = user.BtcAddress,
                        StxAddress = user.StxAddress
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("checkUserRegister/{btcAddress}/{stxAddress}")]
        public ActionResult<UserResult> CheckUserRegister(string btcAddress, string stxAddress)
        {
            try
            {
                //Console.WriteLine("Chegou aqui");
                var user = _userService.GetUser(btcAddress, stxAddress);
                if (user == null)
                {
                    return new UserResult() { User = null, Sucesso = true, Mensagem = "BTC Address Not Found" };
                }
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        BtcAddress = user.BtcAddress
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
                if(String.IsNullOrEmpty(param.BtcAddress))
                    return StatusCode(400, "BTC Address is empty");

                var user = _userService.CreateNewUser(new UserInfo
                {
                    BtcAddress = param.BtcAddress
                });
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        Hash = user.Hash,
                        BtcAddress = user.BtcAddress,
                        StxAddress = user.StxAddress
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
                {
                    return StatusCode(401, "Not Authorized");
                }

                var user = _userService.UpdateUser(new UserInfo
                {
                    BtcAddress = userSession.BtcAddress,
                    StxAddress = userSession.StxAddress
                });
                return new UserResult()
                {
                    User = new UserInfo()
                    {
                        Id = user.Id,
                        BtcAddress = user.BtcAddress,
                        StxAddress = user.StxAddress
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
