﻿using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        ITransactionModel GetTx(long txId);
        ITransactionModel CreateTx(TransactionParamInfo param);
        ITransactionModel Update(TransactionInfo tx);
        IEnumerable<ITransactionModel> ListByStatusActive();
        IEnumerable<ITransactionModel> ListAll();
        IEnumerable<ITransactionLogModel> ListLogById(long txid);
        string GetTransactionEnumToString(TransactionStatusEnum status);
        Task<bool> ProcessTransaction(ITransactionModel tx);
    }
}
