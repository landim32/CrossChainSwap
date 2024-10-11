using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.DTO.Finance;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoldFinanceService
    {
        decimal GetUserGoldBalance(long idUser);
        GoldTransactionListResult ListByUser(long idUser, int page);
        void AddGoldTransaction(long idUser, decimal gold, string msg, bool usingTransaction = true);
        decimal GetGobiPerGold(decimal gobi);
        decimal GetGoldPerGobi(decimal gold);
        decimal GetTotalGold();
        decimal GetTotalGobi();
        void SwapGOBIForGold(long userId, decimal gobi);
        void SwapGoldForGOBI(long userId, decimal gold);
    }
}
