using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO;
using BTCSTXSwap.DTO.CoinMarketCap;
using BTCSTXSwap.DTO.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TransactionController: Controller
    {
        private IUserService _userService;
        private ITransactionService _txService;

        public TransactionController(IUserService userService, ITransactionService txService)
        {
            _userService = userService;
            _txService = txService;
        }

        [HttpPut("createTx")]
        public ActionResult<bool> CreateTx(TransactionParamInfo param)
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
                var tx = _txService.CreateTx(param);
                
                return new ActionResult<bool>(tx.TxId > 0);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
