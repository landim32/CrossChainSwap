using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO;
using BTCSTXSwap.DTO.CoinMarketCap;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PoolController: Controller
    {
        private IUserService _userService;
        private IBitcoinService _bitcoinService;

        public PoolController(IUserService userService, IBitcoinService bitcoinService)
        {
            _userService = userService;
            _bitcoinService = bitcoinService;
        }

        [HttpGet("getpoolinfo")]
        public async Task<ActionResult<PoolInfo>> GetPoolInfo()
        {
            try
            {
                /*
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                */
                var poolAddr = _bitcoinService.GetPoolAddress();
                return new PoolInfo()
                {
                    BtcAddress = poolAddr,
                    BtcBalance = await _bitcoinService.GetBalance(poolAddr)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
