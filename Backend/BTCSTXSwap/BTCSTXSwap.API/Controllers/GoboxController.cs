using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.GLog;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Gobox;
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
    public class GoboxController : Controller
    {
        private IUserService _userService;
        private IGoboxService _goboxService;
        private IGoblinService _goblinService;

        public GoboxController(IUserService userService, IGoboxService goboxService, IGoblinService goblinService)
        {
            _userService = userService;
            _goboxService = goboxService;
            _goblinService = goblinService;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public ActionResult<GoboxListResult> List()
        {
            try
            {
                /*var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }*/
                return new GoboxListResult
                {
                    Goboxes = _goboxService.ListByUser(-1)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listmybox")]
        public ActionResult<GoboxListResult> ListMyBox()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoboxListResult
                {
                    Goboxes = _goboxService.ListByUser(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getbygobox")]
        public ActionResult<GoboxResult> GetByGobox([FromQuery] int boxType)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoboxResult
                {
                    Gobox = _goboxService.GetByGobox(user.Id, (GoboxEnum)boxType)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("buybox")]
        public ActionResult<StatusResult> BuyBox([FromQuery] int box, int qtdy)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                _goboxService.BuyBox(user.Id, (GoboxEnum)box, qtdy);
                return new StatusResult { Sucesso = true };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("openbox")]
        public ActionResult<GoboxResult> OpenBox([FromQuery] int box)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoboxResult { 
                    Sucesso = true,
                    TokenId = _goboxService.OpenBox(user.Id, (GoboxEnum)box)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("openitembox")]
        public ActionResult<ItemBoxResult> OpenItemBox([FromQuery] int box)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new ItemBoxResult
                {
                    Sucesso = true,
                    Itens = _goboxService.OpenItemBox(user.Id, (GoboxEnum)box)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
