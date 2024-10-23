using System;
using System.Text.Json.Serialization;
using NoChainSwap.DTO.Domain;

namespace NoChainSwap.DTO.User
{
    public class BalanceResult : StatusResult
    {
        [JsonPropertyName("balance")]
        public BalanceInfo Balance { get; set; }
    }
}
