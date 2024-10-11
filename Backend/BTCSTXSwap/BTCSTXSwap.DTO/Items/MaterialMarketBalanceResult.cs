using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Items
{
    public class MaterialMarketBalanceResult : StatusResult
    {
        [JsonPropertyName("marketbalance")]
        public MaterialMarketBalanceInfo MarketBalance { get; set; }
    }
}
