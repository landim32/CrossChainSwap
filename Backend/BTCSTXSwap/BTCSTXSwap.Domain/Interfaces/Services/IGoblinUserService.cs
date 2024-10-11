using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinUserService
    {
        Task<BalanceInfo> GetBalance(string publicAddress);
    }
}
