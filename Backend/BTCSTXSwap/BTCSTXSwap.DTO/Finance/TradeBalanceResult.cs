using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Finance
{
    public class TradeBalanceResult : StatusResult
    {
        [JsonPropertyName("tradebalance")]
        public TradeBalanceInfo TradeBalance { get; set; }
    }
}
