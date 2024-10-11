using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Goblin
{
    public class NftResult
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("tokenId")]
        public long TokenId { get; set; }
        [JsonPropertyName("attributes")]
        public List<NftAttribute> Attributes { get; set; }
    }
}
