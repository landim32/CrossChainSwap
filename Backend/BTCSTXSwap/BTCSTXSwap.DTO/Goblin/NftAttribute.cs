using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Goblin
{
    public class NftAttribute
    {
        [JsonPropertyName("trait_type")]
        public string TraittType { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
