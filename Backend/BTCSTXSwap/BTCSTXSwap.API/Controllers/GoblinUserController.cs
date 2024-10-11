using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoblinUserController : ControllerBase
    {
        private IGoblinUserService _goblinUserService;
        private IUserService _userService;

        public GoblinUserController(IGoblinUserService goblinUserService, IUserService userService)
        {
            _goblinUserService = goblinUserService;
            _userService = userService;
        }

        [HttpGet("balance")]
        public async Task<ActionResult<BalanceResult>> GetBalance()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                    return StatusCode(401, "Not Authorized");

                return new BalanceResult
                {
                    Balance = await _goblinUserService.GetBalance(user.PublicAddress)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
