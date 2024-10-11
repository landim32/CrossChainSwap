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
    public class GLogController : Controller
    {
        private IUserService _userService;
        private IGLogService _glogService;
        private IGoblinService _goblinService;

        public GLogController(IUserService userService, IGLogService glogService, IGoblinService goblinService)
        {
            _userService = userService;
            _glogService = glogService;
            _goblinService = goblinService;
        }

        [HttpGet("list")]
        public ActionResult<GLogListResult> List(int page)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return _glogService.List(user.Id, page);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
