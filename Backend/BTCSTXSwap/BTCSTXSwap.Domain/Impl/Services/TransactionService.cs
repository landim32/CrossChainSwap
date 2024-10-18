using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Mempool;
using BTCSTXSwap.DTO.Stacks;
using BTCSTXSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly IMempoolService _mempoolService;
        private readonly IBitcoinService _btcService;
        private readonly IStacksService _stxService;
        private readonly ITransactionDomainFactory _txFactory;
        private readonly ITransactionLogDomainFactory _txLogFactory;

        public TransactionService(
            ICoinMarketCapService coinMarketCapService, 
            IMempoolService mempoolService, 
            IBitcoinService btcService, 
            IStacksService stxService,
            ITransactionDomainFactory txFactory,
            ITransactionLogDomainFactory txLogFactory
        )
        {
            _coinMarketCapService = coinMarketCapService;
            _mempoolService = mempoolService;
            _btcService = btcService;
            _stxService = stxService;
            _txFactory = txFactory;
            _txLogFactory = txLogFactory;
        }

        public ITransactionModel CreateTx(TransactionParamInfo param)
        {
            try
            {
                var model = _txFactory.BuildTransactionModel();
                model.Type = param.BtcToStx ? TransactionEnum.BtcToStx : TransactionEnum.StxToBtc;
                model.BtcAddress = param.BtcAddress;
                model.StxAddress = param.StxAddress; 
                model.CreateAt = DateTime.Now;
                model.UpdateAt = DateTime.Now;
                model.Status = TransactionStatusEnum.Initialized;
                model.BtcAmount = param.BtcAmount;
                model.StxAmount = param.StxAmount;
                model.BtcTxid = param.BtcTxid;
                model.StxTxid = param.StxTxid;
                model.BtcFee = null;
                model.StxFee = null;

                model.Save();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel GetTx(long txId)
        {
            try
            {
                return _txFactory.BuildTransactionModel().GetById(txId, _txFactory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel Update(TransactionInfo tx)
        {
            try
            {
                var model = _txFactory.BuildTransactionModel().GetById(tx.TxId, _txFactory);
                if (model == null)
                {
                    throw new Exception("Transaction not found.");
                }
                model.UpdateAt = DateTime.Now;
                model.Status = tx.Status;
                model.BtcAmount = tx.BtcAmount;
                model.StxAmount = tx.StxAmount;
                model.BtcTxid = tx.BtcTxid;
                model.StxTxid = tx.StxTxid;
                model.BtcFee = tx.BtcFee;
                model.StxFee = tx.StxFee;
                return model.Update();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ITransactionModel> ListByStatusActive()
        {
            var status = new List<int>() { 
                (int) TransactionStatusEnum.Initialized,
                (int) TransactionStatusEnum.Calculated,
                (int) TransactionStatusEnum.BtcNotConfirmed,
                (int) TransactionStatusEnum.StxNotConfirmed,
                (int) TransactionStatusEnum.BtcConfirmed,
                (int) TransactionStatusEnum.StxConfirmed,
                (int) TransactionStatusEnum.BtcConfirmedStxNotConfirmed,
                (int) TransactionStatusEnum.StxConfirmedBtcNotConfirmed
            };
            return _txFactory.BuildTransactionModel().ListByStatus(status, _txFactory);
        }

        public IEnumerable<ITransactionModel> ListAll()
        {
            return _txFactory.BuildTransactionModel().ListAll(_txFactory);
        }

        public string GetTransactionEnumToString(TransactionStatusEnum status) {
            string str = string.Empty;
            switch (status)
            {
                case TransactionStatusEnum.Initialized:
                    str = "Initialized";
                    break;
                case TransactionStatusEnum.Calculated:
                    str = "Calculated";
                    break;
                case TransactionStatusEnum.BtcNotConfirmed:
                    str = "Btc Not Confirmed";
                    break;
                case TransactionStatusEnum.StxNotConfirmed:
                    str = "Stx Not Confirmed";
                    break;
                case TransactionStatusEnum.BtcConfirmed:
                    str = "Btc Confirmed";
                    break;
                case TransactionStatusEnum.StxConfirmed:
                    str = "Stx Confirmed";
                    break;
                case TransactionStatusEnum.BtcConfirmedStxNotConfirmed:
                    str = "Btc Confirmed, Stx Not Confirmed";
                    break;
                case TransactionStatusEnum.StxConfirmedBtcNotConfirmed:
                    str = "Stx Confirmed, Btc Not Confirmed";
                    break;
                case TransactionStatusEnum.BtcConfirmedStxConfirmed:
                    str = "Btc Confirmed and Stx Confirmed";
                    break;
                case TransactionStatusEnum.StxConfirmedBtcConfirmed:
                    str = "Stx Confirmed and Btc Confirmed";
                    break;
                case TransactionStatusEnum.InvalidInformation:
                    str = "Invalid Information";
                    break;
                case TransactionStatusEnum.CriticalError:
                    str = "Critical Error";
                    break;
            }
            return str;
        }

        private void AddLog(long txId, string msg, LogTypeEnum t = LogTypeEnum.Information)
        {
            var md = _txLogFactory.BuildTransactionLogModel();
            md.TxId = txId;
            md.Date = DateTime.Now;
            md.LogType = t;
            md.Message = msg;
            md.Insert();
        }

        private async Task<bool> ProcessBtcTransaction(ITransactionModel tx) {
            if (string.IsNullOrEmpty(tx.BtcTxid))
            {
                AddLog(tx.TxId, "Transaction tx_id is empty", LogTypeEnum.Error);
                tx.Status = TransactionStatusEnum.InvalidInformation;
                tx.Update();
                return await Task.FromResult(false);
            }
            var mempoolTx = await _mempoolService.GetTransaction(tx.BtcTxid);
            if (mempoolTx == null)
            {
                //throw new Exception("Dont find transaction on mempool");
                AddLog(tx.TxId, "Dont find transaction on mempool", LogTypeEnum.Warning);
                return await Task.FromResult(false);
            }
            var poolBtcAddr = _btcService.GetPoolAddress();

            //var addrs = new List<string>();
            var addrsSender = mempoolTx.VIn.Select(x => x.Prevout.ScriptPubKeyAddress).ToList();
            var addrsReceiver = mempoolTx.VOut.Select(x => x.ScriptPubKeyAddress).ToList();

            if (!addrsSender.Contains(tx.BtcAddress))
            {
                AddLog(tx.TxId, "Sender address not in transaction", LogTypeEnum.Error);
                tx.Status = TransactionStatusEnum.InvalidInformation;
                tx.Update();
                return await Task.FromResult(false);
            }

            if (!addrsReceiver.Contains(poolBtcAddr))
            {
                AddLog(tx.TxId, "Pool address not in transaction", LogTypeEnum.Error);
                tx.Status = TransactionStatusEnum.InvalidInformation;
                tx.Update();
                return await Task.FromResult(false);
            }

            var poolBtcAmount = mempoolTx.VOut.Where(x => x.ScriptPubKeyAddress == poolBtcAddr).Select(x => x.Value).Sum();
            if (poolBtcAmount <= 0)
            {
                AddLog(tx.TxId, "Pool did not receive any value", LogTypeEnum.Error);
                tx.Status = TransactionStatusEnum.InvalidInformation;
                tx.Update();
                return await Task.FromResult(false);
            }
            switch (tx.Status)
            {
                case TransactionStatusEnum.Initialized:
                    var price = _coinMarketCapService.GetCurrentPrice("bitcoin", "stacks");
                    var stxAmount = Convert.ToInt64((poolBtcAmount / price.BtcProportion) * 100000000M);

                    tx.BtcAmount = poolBtcAmount;
                    tx.StxAmount = stxAmount;
                    tx.BtcFee = mempoolTx.Fee;
                    tx.Status = TransactionStatusEnum.Calculated;
                    tx.Update();

                    decimal btcValue = Math.Round(poolBtcAmount / 100000000M, 5);
                    decimal stxValue = Math.Round(stxAmount / 100000000M, 5);

                    AddLog(tx.TxId, string.Format("Transaction has {0:N5} BTC, Fee {1:N0} and extimate {2:N5} STX.", btcValue, tx.BtcFee, stxValue), LogTypeEnum.Information);
                    break;
                case TransactionStatusEnum.Calculated:
                    if (mempoolTx.Status.Confirmed)
                    {
                        tx.Status = TransactionStatusEnum.BtcConfirmed;
                        tx.Update();
                        AddLog(tx.TxId, "BTC Transaction confirmed.", LogTypeEnum.Information);
                    }
                    else
                    {
                        tx.Status = TransactionStatusEnum.BtcNotConfirmed;
                        tx.Update();
                    }
                    break;
                case TransactionStatusEnum.BtcNotConfirmed:
                    if (mempoolTx.Status.Confirmed)
                    {
                        tx.Status = TransactionStatusEnum.BtcConfirmed;
                        tx.Update();
                        AddLog(tx.TxId, "BTC Transaction confirmed.", LogTypeEnum.Information);
                    }
                    break;
                case TransactionStatusEnum.BtcConfirmed:
                    if (!mempoolTx.Status.Confirmed)
                    {
                        AddLog(tx.TxId, "Transaction local is confirmed, but mempool not confirm", LogTypeEnum.Error);
                        tx.Status = TransactionStatusEnum.InvalidInformation;
                        tx.Update();
                        return await Task.FromResult(false);
                    }
                    var price2 = _coinMarketCapService.GetCurrentPrice("bitcoin", "stacks");
                    var stxAmount2 = Convert.ToInt64((poolBtcAmount / price2.BtcProportion) * 100000000M);

                    tx.BtcAmount = poolBtcAmount;
                    tx.StxAmount = stxAmount2;
                    tx.BtcFee = mempoolTx.Fee;
                    tx.Update();

                    decimal btcValue2 = Math.Round(poolBtcAmount / 100000000M, 5);
                    decimal stxValue2 = Math.Round(stxAmount2 / 100000000M, 5);

                    AddLog(tx.TxId, string.Format("Transaction has {0:N5} BTC, Fee {1:N0} and extimate {2:N5} STX.", btcValue2, tx.BtcFee, stxValue2), LogTypeEnum.Information);

                    var poolAddr = await _stxService.GetPoolAddress();
                    var poolBalance = await _stxService.GetBalance(poolAddr);
                    if (poolBalance < stxAmount2)
                    {
                        AddLog(tx.TxId, "Pool without enough STX", LogTypeEnum.Warning);
                        return await Task.FromResult(false);
                    }
                    try
                    {
                        var txId = await StartStxTransfer(tx, stxAmount2);
                        if (string.IsNullOrEmpty(txId))
                        {
                            AddLog(tx.TxId, "Tansaction ID (tx_id) is empty", LogTypeEnum.Warning);
                            return await Task.FromResult(false);
                        }
                        tx.StxAddress = txId;
                        tx.Status = TransactionStatusEnum.BtcConfirmedStxNotConfirmed;
                        tx.Update();
                    }
                    catch (Exception err)
                    {
                        AddLog(tx.TxId, err.Message, LogTypeEnum.Error);
                        tx.Status = TransactionStatusEnum.CriticalError;
                        tx.Update();
                        return await Task.FromResult(false);
                    }
                    break;
                case TransactionStatusEnum.BtcConfirmedStxNotConfirmed:
                    if (string.IsNullOrEmpty(tx.StxTxid))
                    {
                        AddLog(tx.TxId, "STX Transaction ID (tx_id) is empty", LogTypeEnum.Warning);
                        return await Task.FromResult(false);
                    }
                    var stxTx = await _stxService.GetTransaction(tx.StxTxid);
                    if (stxTx == null)
                    {
                        AddLog(tx.TxId, "STX Transaction is empty", LogTypeEnum.Warning);
                        return await Task.FromResult(false);
                    }
                    if (string.Compare(stxTx.TxStatus, "success", true) == 0)
                    {
                        int fee = 0;
                        if (!int.TryParse(stxTx.FeeRate, out fee))
                        {
                            AddLog(tx.TxId, string.Format("Cant convert fee to int ({0})", stxTx.FeeRate), LogTypeEnum.Warning);
                            return await Task.FromResult(false);
                        }
                        tx.StxFee = fee;
                        tx.Status = TransactionStatusEnum.BtcConfirmedStxConfirmed;
                        tx.Update();
                        AddLog(tx.TxId, "STX Transaction confirmed.", LogTypeEnum.Information);
                    }
                    break;
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> ProcessTransaction(ITransactionModel tx)
        {
            if (tx == null)
            {
                throw new Exception("Transaction is null");
            }
            if (tx.Type == TransactionEnum.BtcToStx)
            {
                try
                {
                    return await ProcessBtcTransaction(tx);
                }
                catch (Exception err)
                {
                    AddLog(tx.TxId, err.Message, LogTypeEnum.Error);
                    tx.Status = TransactionStatusEnum.CriticalError;
                    tx.Update();
                }
            }
            else
            {

            }
            return await Task.FromResult(false);
        }

        private async Task<string> StartStxTransfer(ITransactionModel tx, long stxAmount)
        {
            var txHandle = await _stxService.Transfer(new TransferParamInfo
            {
                recipientAddress = tx.StxAddress,
                amount = stxAmount
            });
            if (!string.IsNullOrEmpty(txHandle.Error))
            {
                throw new Exception(string.Format("{0} ({1})", txHandle.Error, txHandle.Reason));
            }
            if (!string.IsNullOrEmpty(txHandle.TxId))
            {
                return await Task.FromResult(txHandle.TxId);
            }
            return await Task.FromResult("");
        }
    }
}
