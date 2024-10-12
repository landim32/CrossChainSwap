using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinanceController : Controller
    {
        private IUserService _userService;
        private IFinanceService _withdrawService;

        public FinanceController(IUserService userService, IFinanceService withdrawService)
        {
            _userService = userService;
            _withdrawService = withdrawService;
        }

        [HttpGet("list")]
        public ActionResult<FinanceListResult> List([FromQuery] int page)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return _withdrawService.List(user.Id, page);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getfinance")]
        public async Task<ActionResult<FinanceResult>> GetFinance()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new FinanceResult
                {
                    Finance = await _withdrawService.GetFinance(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("confirmdeposit")]
        public async Task<ActionResult<FinanceTransactionResult>> ConfirmDeposit(DepositConfirmInfo deposit)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new FinanceTransactionResult
                {
                    Transaction = await _withdrawService.ConfirmDeposit(new DepositInfo
                    {
                        IdUser = user.Id,
                        Token = (int)FinanceTokenEnum.GOBI,
                        TransactionHash = deposit.TransactionHash,
                        Value = deposit.Value
                    })
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("calculatefee")]
        public ActionResult<FinanceNumberResult> CalculateFee([FromQuery] decimal value)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new FinanceNumberResult
                {
                    Value = _withdrawService.CalculateFee(FinanceTokenEnum.GOBI, user.Id, value)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*[HttpGet("checkContracts")]
        public async Task<ActionResult> Check()
        {
            try
            {
                await _withdrawService.CheckContracts();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        [HttpGet("withdrawl")]
        public async Task<ActionResult<FinanceTransactionResult>> Withdrawl([FromQuery] decimal value)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new FinanceTransactionResult
                {
                    Transaction = await _withdrawService.Withdrawl(new FinanceRequestInfo { 
                        IdUser = user.Id,
                        Token = (int) FinanceTokenEnum.GOBI,
                        Value = value
                    })
                };
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
