using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.User
{
    public class BalanceResult : StatusResult
    {
        [JsonPropertyName("balance")]
        public BalanceInfo Balance { get; set; }
    }
}
