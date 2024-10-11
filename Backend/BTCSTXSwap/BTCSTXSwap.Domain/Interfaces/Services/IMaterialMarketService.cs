using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.DTO.Finance;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IMaterialMarketService
    {
        long GetTotalMaterial(long materialKey);
        decimal GetTotalGoldMaterial(long materialKey);
        void SwapMaterialForGold(long userId, long materialKey, long qtde);
        void SwapGoldForMaterial(long userId, long materialKey, long qtde);
    }
}
