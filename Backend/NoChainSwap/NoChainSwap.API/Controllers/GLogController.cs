using NoChainSwap.API.DTO;
using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Domain;
using NoChainSwap.DTO.GLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NoChainSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GLogController : Controller
    {
        private IUserService _userService;
        private IGLogService _glogService;

        public GLogController(IUserService userService, IGLogService glogService)
        {
            _userService = userService;
            _glogService = glogService;
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
