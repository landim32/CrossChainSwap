using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Items
{
    public class DestroyRewardInfo
    {
        [JsonPropertyName("goldmin")]
        public int GoldMin { get; set; }
        [JsonPropertyName("goldmax")]
        public int GoldMax { get; set; }
        [JsonPropertyName("grantedqtdy")]
        public int GrantedQtdy { get; set; }
        [JsonPropertyName("randomqtdy")]
        public int RandomQtdy { get; set; }
        [JsonPropertyName("grantedreward")]
        public IEnumerable<ItemDestroyRewardInfo> GrantedReward { get; set; }
        [JsonPropertyName("randomreward")]
        public IEnumerable<ItemDestroyRewardInfo> RandomReward { get; set; }
    }
}
