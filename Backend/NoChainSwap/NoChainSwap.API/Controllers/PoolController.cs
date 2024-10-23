using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO;
using NoChainSwap.DTO.CoinMarketCap;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NoChainSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PoolController: Controller
    {
        private IUserService _userService;
        private IBitcoinService _bitcoinService;
        private IStacksService _stacksService;
        private IMempoolService _mempoolService;

        public PoolController(
            IUserService userService, 
            IBitcoinService bitcoinService,
            IStacksService stacksService,
            IMempoolService mempoolService
        )
        {
            _userService = userService;
            _bitcoinService = bitcoinService;
            _stacksService = stacksService;
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
                var poolBtcAddr = _bitcoinService.GetPoolAddress();
                var poolStxAddr = await _stacksService.GetPoolAddress();
                return new PoolInfo()
                {
                    BtcAddress = poolBtcAddr,
                    BtcBalance = await _mempoolService.GetBalance(poolBtcAddr),
                    StxAddress = poolStxAddr,
                    StxBalance = await _stacksService.GetBalance(poolStxAddr)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
