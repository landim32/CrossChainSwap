using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinTokenResult : StatusResult
    {
        [JsonPropertyName("tokenid")]
        public long TokenId { get; set; }
    }
}
