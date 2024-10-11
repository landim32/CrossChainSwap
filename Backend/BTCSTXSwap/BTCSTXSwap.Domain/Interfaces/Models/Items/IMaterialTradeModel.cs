using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Finance;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.Domain.Interfaces.Models.Items
{
    public interface IMaterialTradeModel
    {
        MaterialTradeInfo TradeInfo { get; set; }
        void Save();
        long GetTotalMaterial(long keyMaterial);
        decimal GetTotalGoldMaterial(long keyMaterial);
    }
}
