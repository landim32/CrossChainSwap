using NoChainSwap.Domain.Impl.Models;
using NoChainSwap.Domain.Interfaces.Factory;
using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Mempool;
using NoChainSwap.DTO.Stacks;
using NoChainSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Services
{
    public class TransactionService : BaseTransactionService, ITransactionService
    {
        //private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly IMempoolService _mempoolService;
        private readonly IBitcoinService _btcService;
        private readonly IStacksService _stxService;
        private readonly ITransactionDomainFactory _txFactory;
        //private readonly ITransactionLogDomainFactory _txLogFactory;

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
            if (!string.IsNullOrEmpty(param.BtcAddress))
            {
                param.BtcAddress = param.BtcAddress.ToLower();
            }
            if (!string.IsNullOrEmpty(param.StxAddress))
            {
                param.StxAddress = param.StxAddress.ToUpper();
            }
            if (!string.IsNullOrEmpty(param.BtcTxid))
            {
                param.BtcTxid = param.BtcTxid.ToLower();
                var m1 = _txFactory.BuildTransactionModel().GetByBtcTxId(param.BtcTxid, _txFactory);
                if (m1 != null)
                {
                    throw new Exception($"Transaction '{param.BtcTxid}' is already registered");
                }
            }
            if (!string.IsNullOrEmpty(param.StxTxid))
            {
                if (param.StxTxid.StartsWith("0x") || param.StxTxid.StartsWith("0X")) {
                    param.StxTxid = param.StxTxid.Substring(2);
                }
                param.StxTxid = param.StxTxid.ToLower();
                var m2 = _txFactory.BuildTransactionModel().GetByStxTxId(param.StxTxid, _txFactory);
                if (m2 != null)
                {
                    throw new Exception($"Transaction '{param.StxTxid}' is already registered");
                }
            }
            try
            {
                var model = _txFactory.BuildTransactionModel();
                model.Type = param.BtcToStx ? TransactionEnum.BtcToStx : TransactionEnum.StxToBtc;
                model.BtcAddress = param.BtcAddress;
                model.StxAddress = param.StxAddress; 
                model.CreateAt = DateTime.Now;
                model.UpdateAt = DateTime.Now;
                model.Status = TransactionStatusEnum.Initialized;
                model.BtcAmount = 0;
                model.StxAmount = 0;
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

        public IEnumerable<ITransactionLogModel> ListLogById(long txid)
        {
            return _txLogFactory.BuildTransactionLogModel().ListById(txid, _txLogFactory);
        }

        private async Task<TransactionStepInfo> TransactionNextStep(
            ITransactionModel tx, 
            MemPoolTxInfo mempoolTx, 
            string poolBtcAddr, 
            long poolBtcAmount,
            ICoinService coinService
        )
        {
            TransactionStepInfo ret = null;
            switch (tx.Status)
            {
                case TransactionStatusEnum.Initialized:
                    ret = await coinService.CalculateStep(tx, mempoolTx, poolBtcAmount);
                    break;
                case TransactionStatusEnum.Calculated:
                    ret = await coinService.SenderFirstConfirmStep(tx, mempoolTx);
                    break;
                case TransactionStatusEnum.BtcNotConfirmed:
                    ret = await coinService.SenderTryConfirmStep(tx, mempoolTx);
                    break;
                case TransactionStatusEnum.BtcConfirmed:
                    if (!mempoolTx.Status.Confirmed)
                    {
                        AddLog(tx.TxId, "Transaction local is confirmed, but mempool not confirm", LogTypeEnum.Error);
                        tx.Status = TransactionStatusEnum.InvalidInformation;
                        tx.Update();
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = false,
                            DoNextStep = false
                        });
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
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = false,
                            DoNextStep = false
                        });
                    }
                    try
                    {
                        var txId = await StartStxTransfer(tx, stxAmount2);
                        if (string.IsNullOrEmpty(txId))
                        {
                            AddLog(tx.TxId, "Tansaction ID (tx_id) is empty", LogTypeEnum.Warning);
                            return await Task.FromResult(new TransactionStepInfo
                            {
                                Success = false,
                                DoNextStep = false
                            });
                        }
                        tx.StxAddress = txId;
                        tx.Status = TransactionStatusEnum.BtcConfirmedStxNotConfirmed;
                        tx.Update();
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = true,
                            DoNextStep = false
                        });
                    }
                    catch (Exception err)
                    {
                        AddLog(tx.TxId, err.Message, LogTypeEnum.Error);
                        tx.Status = TransactionStatusEnum.CriticalError;
                        tx.Update();
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = false,
                            DoNextStep = false
                        });
                    }
                case TransactionStatusEnum.BtcConfirmedStxNotConfirmed:
                    if (string.IsNullOrEmpty(tx.StxTxid))
                    {
                        AddLog(tx.TxId, "STX Transaction ID (tx_id) is empty", LogTypeEnum.Warning);
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = false,
                            DoNextStep = false
                        });
                    }
                    var stxTx = await _stxService.GetTransaction(tx.StxTxid);
                    if (stxTx == null)
                    {
                        AddLog(tx.TxId, "STX Transaction is empty", LogTypeEnum.Warning);
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = false,
                            DoNextStep = false
                        });
                    }
                    if (string.Compare(stxTx.TxStatus, "success", true) == 0)
                    {
                        int fee = 0;
                        if (!int.TryParse(stxTx.FeeRate, out fee))
                        {
                            AddLog(tx.TxId, string.Format("Cant convert fee to int ({0})", stxTx.FeeRate), LogTypeEnum.Warning);
                            return await Task.FromResult(new TransactionStepInfo
                            {
                                Success = false,
                                DoNextStep = false
                            });
                        }
                        tx.StxFee = fee;
                        tx.Status = TransactionStatusEnum.BtcConfirmedStxConfirmed;
                        tx.Update();
                        AddLog(tx.TxId, "STX Transaction confirmed.", LogTypeEnum.Information);
                        return await Task.FromResult(new TransactionStepInfo
                        {
                            Success = true,
                            DoNextStep = false
                        });
                    }
                    break;
            }
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
