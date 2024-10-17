using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO;
using BTCSTXSwap.DTO.CoinMarketCap;
using BTCSTXSwap.DTO.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("listalltransactions")]
        public ActionResult<IList<TransactionInfo>> ListAllTransactions()
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
                var ds = _txService.ListAll().Select(x => new TransactionInfo
                {
                    TxId = x.TxId,
                    Type = x.Type,
                    BtcAddress = x.BtcAddress,
                    StxAddress = x.StxAddress,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt,
                    Status = x.Status,
                    BtcTxid = x.BtcTxid,
                    StxTxid = x.StxTxid,
                    BtcFee = x.BtcFee,
                    StxFee = x.StxFee,
                    BtcAmount = x.BtcAmount,
                    StxAmount = x.StxAmount
                }).ToList();
                return new ActionResult<IList<TransactionInfo>>(ds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("processnexttransaction")]
        public async Task<ActionResult<bool>> ProcessNextTransaction()
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
                var tx = _txService.ListByStatusActive().FirstOrDefault();
                if (tx == null)
                {
                    return StatusCode(500, "Dont find any transaction");
                }
                return await _txService.ProcessTransaction(tx);
                //return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
