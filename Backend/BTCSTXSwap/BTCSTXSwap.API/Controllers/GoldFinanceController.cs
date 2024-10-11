using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoldFinanceController : Controller
    {

        private IUserService _userService;
        private IGoldFinanceService _goldFinanceService;

        public GoldFinanceController(IUserService userService, IGoldFinanceService goldFinanceService)
        {
            _userService = userService;
            _goldFinanceService = goldFinanceService;
        }

        [HttpGet("list")]
        public ActionResult<GoldTransactionListResult> List([FromQuery] int page)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return _goldFinanceService.ListByUser(user.Id, page);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("gobipergold")]
        public ActionResult<GoldTradeRateResult> GobiPerGold([FromQuery] decimal gobi)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoldTradeRateResult
                {
                    TradeInfo = new GoldTradeRateInfo
                    {
                        GobiPerGold = _goldFinanceService.GetGobiPerGold(gobi)
                    }
                };
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("goldpergobi")]
        public ActionResult<GoldTradeRateResult> GoldPerGobi([FromQuery] decimal gold)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoldTradeRateResult
                {
                    TradeInfo = new GoldTradeRateInfo
                    {
                        GoldPerGobi = _goldFinanceService.GetGoldPerGobi(gold)
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("tradebalance")]
        public ActionResult<TradeBalanceResult> GetTradeBalance()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new TradeBalanceResult
                {
                    TradeBalance = new TradeBalanceInfo
                    {
                        TotalGobi = _goldFinanceService.GetTotalGobi(),
                        TotalGold = _goldFinanceService.GetTotalGold()
                    }
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("swapgold")]
        public ActionResult<StatusResult> SwapGold(SwapGoldParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                _goldFinanceService.SwapGoldForGOBI(user.Id, param.Gold);

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

        [HttpPost("swapgobi")]
        public ActionResult<StatusResult> SwapGobi(SwapGoldParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                _goldFinanceService.SwapGOBIForGold(user.Id, param.Gobi);

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
