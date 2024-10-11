using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Items
{
    public class MaterialMarketBalanceInfo
    {
        [JsonPropertyName("totalmaterial")]
        public decimal TotalMaterial { get; set; }
        [JsonPropertyName("totalgold")]
        public decimal TotalGold { get; set; }
    }
}
