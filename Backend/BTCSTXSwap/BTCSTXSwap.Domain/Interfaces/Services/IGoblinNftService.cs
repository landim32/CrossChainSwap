using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinNftService
    {
        Task<bool> Mint(long idUser, long TokenId);
        Task<bool> Claim(long idUser, long TokenId);
        Task<bool> ConfirmDeposit(long idUser, long TokenId, string transactionHash);
        Task<IList<GoblinInfo>> List(long idUser);
    }
}
