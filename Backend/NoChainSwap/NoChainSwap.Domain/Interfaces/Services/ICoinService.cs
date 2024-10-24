using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.DTO.Mempool;
using NoChainSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Interfaces.Services
{
    public interface ICoinService
    {
        Task<TransactionStepInfo> CalculateStep(ITransactionModel tx, MemPoolTxInfo mempoolTx, long poolAmount);
        Task<TransactionStepInfo> SenderFirstConfirmStep(ITransactionModel tx, MemPoolTxInfo mempoolTx);
        Task<TransactionStepInfo> SenderTryConfirmStep(ITransactionModel tx, MemPoolTxInfo mempoolTx);
        Task<TransactionStepInfo> PayReceiverStep(ITransactionModel tx, MemPoolTxInfo mempoolTx, string poolAddr, long poolAmount);
    }
}
