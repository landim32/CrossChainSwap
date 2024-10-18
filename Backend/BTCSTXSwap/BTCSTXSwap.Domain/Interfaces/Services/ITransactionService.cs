using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        ITransactionModel GetTx(long txId);
        ITransactionModel CreateTx(TransactionParamInfo param);
        ITransactionModel Update(TransactionInfo tx);
        IEnumerable<ITransactionModel> ListByStatusActive();
        IEnumerable<ITransactionModel> ListAll();
        string GetTransactionEnumToString(TransactionStatusEnum status);
        Task<bool> ProcessTransaction(ITransactionModel tx);
    }
}
