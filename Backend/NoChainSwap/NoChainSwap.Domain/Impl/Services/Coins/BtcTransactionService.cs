using NoChainSwap.Domain.Impl.Models;
using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Mempool;
using NoChainSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Services.Coins
{
    public class BtcTransactionService : BaseTransactionService, ICoinService
    {

        public async Task<TransactionStepInfo> CalculateStep(
            ITransactionModel tx,
            MemPoolTxInfo mempoolTx,
            long poolAmount
        )
        {
            var price = _coinMarketCapService.GetCurrentPrice("bitcoin", "stacks");
            var stxAmount = Convert.ToInt64(poolAmount / price.BtcProportion * 100000000M);

            tx.BtcAmount = poolAmount;
            tx.StxAmount = stxAmount;
            tx.BtcFee = mempoolTx.Fee;
            tx.Status = TransactionStatusEnum.Calculated;
            tx.Update();

            decimal btcValue = Math.Round(poolAmount / 100000000M, 5);
            decimal stxValue = Math.Round(stxAmount / 100000000M, 5);

            AddLog(tx.TxId, string.Format("Transaction has {0:N5} BTC, Fee {1:N0} and extimate {2:N5} STX.", btcValue, tx.BtcFee, stxValue), LogTypeEnum.Information);
            return await Task.FromResult(new TransactionStepInfo
            {
                Success = true,
                DoNextStep = true
            });
        }
        public async Task<TransactionStepInfo> SenderFirstConfirmStep(ITransactionModel tx, MemPoolTxInfo mempoolTx)
        {
            if (mempoolTx.Status.Confirmed)
            {
                tx.Status = TransactionStatusEnum.BtcConfirmed;
                tx.Update();
                AddLog(tx.TxId, "BTC Transaction confirmed.", LogTypeEnum.Information);
                return await Task.FromResult(new TransactionStepInfo
                {
                    Success = true,
                    DoNextStep = true
                });
            }
            else
            {
                tx.Status = TransactionStatusEnum.BtcNotConfirmed;
                tx.Update();
                return await Task.FromResult(new TransactionStepInfo
                {
                    Success = false,
                    DoNextStep = false
                });
            }
        }

        public async Task<TransactionStepInfo> SenderTryConfirmStep(ITransactionModel tx, MemPoolTxInfo mempoolTx)
        {
            if (mempoolTx.Status.Confirmed)
            {
                tx.Status = TransactionStatusEnum.BtcConfirmed;
                tx.Update();
                AddLog(tx.TxId, "BTC Transaction confirmed.", LogTypeEnum.Information);
                return await Task.FromResult(new TransactionStepInfo
                {
                    Success = true,
                    DoNextStep = true
                });
            }
            else
            {
                return await Task.FromResult(new TransactionStepInfo
                {
                    Success = true,
                    DoNextStep = false
                });
            }
        }
    }
}
