using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Finance
{
    public class GoldTradeRateInfo
    {
        [JsonPropertyName("goldpergobi")]
        public decimal GoldPerGobi { get; set; }
        [JsonPropertyName("gobipergold")]
        public decimal GobiPerGold { get; set; }
    }
}
