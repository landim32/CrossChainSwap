using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Mempool;
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

        public TransactionService(
            ICoinMarketCapService coinMarketCapService, 
            IMempoolService mempoolService, 
            IBitcoinService btcService, 
            IStacksService stxService,
            ITransactionDomainFactory txFactory
        )
        {
            _coinMarketCapService = coinMarketCapService;
            _mempoolService = mempoolService;
            _btcService = btcService;
            _stxService = stxService;
            _txFactory = txFactory;
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

        private async Task<bool> ProcessBtcTransaction(ITransactionModel tx) {
            if (string.IsNullOrEmpty(tx.BtcTxid))
            {
                throw new Exception("Transaction txid is empty");
            }
            var mempoolTx = await _mempoolService.GetTransaction(tx.BtcTxid);
            if (mempoolTx == null)
            {
                throw new Exception("Dont find transaction on mempool");
            }
            var poolBtcAddr = _btcService.GetPoolAddress();

            var addrs = new List<string>();
            addrs.AddRange(mempoolTx.VIn.Select(x => x.Prevout.ScriptPubKeyAddress));
            addrs.AddRange(mempoolTx.VOut.Select(x => x.ScriptPubKeyAddress));

            if (!addrs.Contains(tx.BtcAddress))
            {
                throw new Exception("Sender address not in transaction");
            }

            if (!addrs.Contains(poolBtcAddr))
            {
                throw new Exception("Pool address not in transaction");
            }

            var poolBtcAmount = mempoolTx.VOut.Where(x => x.ScriptPubKeyAddress == poolBtcAddr).Select(x => x.Value).Sum();
            if (poolBtcAmount <= 0)
            {
                throw new Exception("Pool did not receive any value");
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
                    break;
                case TransactionStatusEnum.Calculated:
                    if (mempoolTx.Status.Confirmed)
                    {
                        tx.Status = TransactionStatusEnum.BtcConfirmedStxNotConfirmed;
                        tx.Update();
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
                        //tx.Status = TransactionStatusEnum.BtcConfirmedStxNotConfirmed;
                        //tx.Update();
                        await StartStxTransfer(tx, mempoolTx.Fee, poolBtcAmount);
                    }
                    break;
            }

            //var btcOrigAddr = mempoolTx.VIn.First().Prevout.ScriptPubKeyAddress;
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
                return await ProcessBtcTransaction(tx);
            }
            else
            {

            }
            return await Task.FromResult(false);
        }

        private async Task<bool> StartStxTransfer(ITransactionModel tx, int btcFee, long poolBtcAmount)
        {
            var price = _coinMarketCapService.GetCurrentPrice("bitcoin", "stacks");
            var stxAmount = Convert.ToInt64((poolBtcAmount / price.BtcProportion) * 100000000M);

            tx.BtcAmount = poolBtcAmount;
            tx.StxAmount = stxAmount;
            tx.BtcFee = btcFee;
            tx.Update();

            var poolAddr = await _stxService.GetPoolAddress();
            var poolBalance = await _stxService.GetBalance(poolAddr);
            if (poolBalance < stxAmount)
            {
                throw new Exception("Pool without enough STX");
            }
            var txHandle = await _stxService.Transfer(new DTO.Stacks.TransferParamInfo
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
                tx.StxTxid = txHandle.TxId;
                tx.Status = TransactionStatusEnum.BtcConfirmedStxNotConfirmed;
                tx.Update();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
