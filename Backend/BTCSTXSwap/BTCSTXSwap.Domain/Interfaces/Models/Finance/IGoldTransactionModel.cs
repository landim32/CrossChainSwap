using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Finance;

namespace BTCSTXSwap.Domain.Interfaces.Models.Finance
{
    public interface IGoldTransactionModel
    {
        GoldTransactionInfo GoldTransaction { get; set; }
        void Save();
        IEnumerable<IGoldTransactionModel> ListByUser(long idUser, int page, out int balance);
        decimal GetUserGoldBalance(long idUser);
        decimal GetTotalGOBI();
        decimal GetTotalGold();
        IGoldTransactionModel GetLastGoldSwap(long idUser);
        IGoldTransactionModel GetLastGOBISwap(long idUser);
        decimal GetBalanceOfGobiSwapInTheLastDay(long idUser);
    }
}
