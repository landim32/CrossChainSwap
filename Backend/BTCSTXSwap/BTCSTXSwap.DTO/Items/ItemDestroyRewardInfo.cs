using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Items
{
    public class ItemDestroyRewardInfo
    {
        [JsonPropertyName("item")]
        public ItemInfo Item { get; set; }
        [JsonPropertyName("percent")]
        public int Percent { get; set; }
        [JsonPropertyName("qtdemin")]
        public int QtdeMin { get; set; }
        [JsonPropertyName("qtdemax")]
        public int QtdeMax { get; set; }
    }
}
