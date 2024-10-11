using System;
using System.Collections.Generic;
using BTCSTXSwap.DTO.Mining;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinEnergyModel
    {
        GoblinEnergyMiningInfo EnergyInfo { get; set; }
        int ChargeDuration { get; }
        IEnumerable<IGoblinEnergyModel> ListUserGoblin(long idUser);
        IGoblinEnergyModel GetGoblin(long idGoblin);
        decimal DoRecharge(long idGoblin, long idUser, bool free = false);
        decimal RechargeAll(long idUser);
        bool HasRecharge(long idGoblin);
        void RestartCharge(long idGoblin);
        void StopCharge(long idGoblin);
    }
}
