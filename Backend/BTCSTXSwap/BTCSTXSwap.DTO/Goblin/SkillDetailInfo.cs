using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Goblin
{
    public class SkillDetailInfo
    {
        [JsonPropertyName("base")]
        public long Base { get; set; }
        [JsonPropertyName("bonus")]
        public long Bonus { get; set; }
        [JsonPropertyName("total")]
        public long Total { get; set; }
    }
}
