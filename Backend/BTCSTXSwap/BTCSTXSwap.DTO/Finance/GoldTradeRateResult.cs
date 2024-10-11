using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Finance
{
    public class GoldTradeRateResult : StatusResult
    {
        [JsonPropertyName("tradeinfo")]
        public GoldTradeRateInfo TradeInfo { get; set; }
    }
}
