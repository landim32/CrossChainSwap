using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinResult : StatusResult
    {
        [JsonPropertyName("goblin")]
        public GoblinInfo Goblin { get; set; }
    }
}
