using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Mining;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinMiningService
    {
        GoblinEnergyMiningInfo BuildGoblinMining(long idGoblin);
        GoblinEnergyMiningInfo DoRecharge(long userId, long idGoblin, bool free = false);
        void RechargeAll(long idUser);
        IEnumerable<GoblinEnergyMiningInfo> BuildGoblinMiningList(long userId);
        bool HasRecharge(long idGoblin);
        void RestartGoblinCharge(long idGoblin);
        void StopGoblinCharge(long idGoblin);
    }
}
