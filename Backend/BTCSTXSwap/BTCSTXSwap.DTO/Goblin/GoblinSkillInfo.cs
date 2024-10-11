using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinSkillInfo
    {
        [JsonPropertyName("mining")]
        public SkillDetailInfo Mining { get; set; }
        [JsonPropertyName("hunting")]
        public SkillDetailInfo Hunting { get; set; }
        [JsonPropertyName("resistence")]
        public SkillDetailInfo Resistence { get; set; }
        [JsonPropertyName("attack")]
        public SkillDetailInfo Attack { get; set; }
        [JsonPropertyName("social")]
        public SkillDetailInfo Social { get; set; }
        [JsonPropertyName("tailoring")]
        public SkillDetailInfo Tailoring { get; set; }
        [JsonPropertyName("blacksmith")]
        public SkillDetailInfo Blacksmith { get; set; }
        [JsonPropertyName("stealth")]
        public SkillDetailInfo Stealth { get; set; }
        [JsonPropertyName("magic")]
        public SkillDetailInfo Magic { get; set; }
    }
}
