using BTCSTXSwap.API.DTO;
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
        private IBitcoinService _bitcoinService;
        private IStacksService _stacksService;

        public TransactionController(
            IUserService userService, 
            ITransactionService txService, 
            IBitcoinService bitcoinService,
            IStacksService stacksService
        )
        {
            _userService = userService;
            _txService = txService;
            _bitcoinService = bitcoinService;
            _stacksService = stacksService;
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
        public ActionResult<IList<TxResult>> ListAllTransactions()
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
                var ds = _txService.ListAll().Select(x => new TxResult
                {
                    TxId = x.TxId,
                    IntType = (int) x.Type,
                    TxType = x.Type == TransactionEnum.BtcToStx ? "BTC To STX" : "STX to BTC",
                    BtcAddress = x.BtcAddress,
                    BtcAddressUrl = (x.BtcAddress != null) ? _bitcoinService.GetAddressUrl(x.BtcAddress) : null,
                    StxAddress = x.StxAddress,
                    StxAddressUrl = (x.StxAddress != null) ? _stacksService.GetAddressUrl(x.StxAddress) : null,
                    CreateAt = x.CreateAt.ToString("MM/dd/yyyy HH:mm:ss"),
                    UpdateAt = x.UpdateAt.ToString("MM/dd/yyyy HH:mm:ss"),
                    Status = _txService.GetTransactionEnumToString(x.Status),
                    BtcTxid = x.BtcTxid,
                    BtcTxidUrl = !string.IsNullOrEmpty(x.BtcTxid) ? _bitcoinService.GetTransactionUrl(x.BtcTxid) : null,
                    StxTxid = x.StxTxid,
                    StxTxidUrl = !string.IsNullOrEmpty(x.StxTxid) ? _stacksService.GetTransactionUrl(x.StxTxid) : null,
                    BtcFee = x.BtcFee.HasValue ? _bitcoinService.ConvertToString(x.BtcFee.Value) : null,
                    StxFee = x.StxFee.HasValue ? _stacksService.ConvertToString(x.StxFee.Value) : null,
                    BtcAmount = x.BtcAmount.HasValue ? _bitcoinService.ConvertToString(x.BtcAmount.Value) : null,
                    StxAmount = x.StxAmount.HasValue ? _stacksService.ConvertToString(x.StxAmount.Value) : null
                }).ToList();
                return new ActionResult<IList<TxResult>>(ds);
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
