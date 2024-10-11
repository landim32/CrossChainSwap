using BTCSTXSwap.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    [Obsolete]
    public interface IBalanceModel
    {
        [Obsolete]
        BalanceInfo Balance { get; set; }
        [Obsolete]
        string PublicAddress { get; set; }

        [Obsolete]
        Task LoadBalance();
        [Obsolete]
        Task<long> GetGoblinBalance();
    }
}
