using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Finance
{
    public class TradeBalanceInfo
    {
        [JsonPropertyName("totalgobi")]
        public decimal TotalGobi { get; set; }
        [JsonPropertyName("totalgold")]
        public decimal TotalGold { get; set; }
    }
}
