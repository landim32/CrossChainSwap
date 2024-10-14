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
        private IMempoolService _mempoolService;

        public PoolController(IUserService userService, IBitcoinService bitcoinService, IMempoolService mempoolService)
        {
            _userService = userService;
            _bitcoinService = bitcoinService;
            _mempoolService = mempoolService;
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
                    BtcBalance = await _mempoolService.GetBalance(poolAddr)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
