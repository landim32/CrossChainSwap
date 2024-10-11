using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.GLog;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Mining;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoblinNftController : Controller
    {
        private IUserService _userService;
        //private IGoblinNftService _goblinNftService;

        //public GoblinNftController(IUserService userService, IGoblinNftService goblinNftService)
        public GoblinNftController(IUserService userService)
        {
            _userService = userService;
            //_goblinNftService = goblinNftService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<GoblinListResult>> List()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoblinListResult
                {
                    //Goblins = await _goblinNftService.List(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("mint")]
        public async Task<ActionResult<StatusResult>> Mint([FromQuery] long tokenId)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new StatusResult
                {
                    //Sucesso = await _goblinNftService.Mint(user.Id, tokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("claim")]
        public async Task<ActionResult<StatusResult>> Claim([FromQuery] long tokenId)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new StatusResult
                {
                    //Sucesso = await _goblinNftService.Claim(user.Id, tokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("confirmdeposit")]
        public async Task<ActionResult<StatusResult>> ConfirmDeposit([FromQuery] long tokenId, string transactionHash)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new StatusResult
                {
                    //Sucesso = await _goblinNftService.ConfirmDeposit(user.Id, tokenId, transactionHash)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
