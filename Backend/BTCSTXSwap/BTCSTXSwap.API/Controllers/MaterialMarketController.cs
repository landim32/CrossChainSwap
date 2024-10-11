using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Finance;
using BTCSTXSwap.DTO.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialMarketController : Controller
    {

        private IUserService _userService;
        private IMaterialMarketService _materialMarketService;

        public MaterialMarketController(IUserService userService, IMaterialMarketService materialMarketService)
        {
            _userService = userService;
            _materialMarketService = materialMarketService;
        }

        [HttpGet("marketbalance")]
        public ActionResult<MaterialMarketBalanceResult> GetTradeBalance([FromQuery] long materialKey)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MaterialMarketBalanceResult
                {
                    MarketBalance = new MaterialMarketBalanceInfo
                    {
                        TotalMaterial = _materialMarketService.GetTotalMaterial(materialKey),
                        TotalGold = _materialMarketService.GetTotalGoldMaterial(materialKey)
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("swapmaterialpergold")]
        public ActionResult<StatusResult> SwapGold(SwapMaterialParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                _materialMarketService.SwapMaterialForGold(user.Id, param.MaterialKey, param.Qtde);

                return new StatusResult
                {
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("swapgoldpermaterial")]
        public ActionResult<StatusResult> SwapGobi(SwapMaterialParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                _materialMarketService.SwapGoldForMaterial(user.Id, param.MaterialKey, param.Qtde);

                return new StatusResult
                {
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
