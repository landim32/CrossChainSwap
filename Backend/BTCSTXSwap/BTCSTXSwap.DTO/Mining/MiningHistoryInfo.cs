using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningHistoryInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("rewardtype")]
        public string RewardType { get; set; }
        [JsonPropertyName("rewarddate")]
        public DateTime RewardDate { get; set; }
        [JsonPropertyName("rewarddatestr")]
        public string RewardDateStr { 
            get
            {
                return RewardDate.ToString("MM/dd/yyyy");
            }
        }
        [JsonPropertyName("ranking")]
        public int Ranking { get; set; }
        [JsonPropertyName("goblinqtde")]
        public int GoblinQtde { get; set; }
        [JsonPropertyName("hashpower")]
        public int HashPower { get; set; }
        [JsonPropertyName("hashforweek")]
        public long? HashForWeek { get; set; }
        [JsonPropertyName("hashformonth")]
        public long? HashForMonth { get; set; }
        [JsonPropertyName("boxtype")]
        public int BoxType { get; set; }
        [JsonPropertyName("claimed")]
        public bool Claimed { get; set; }
    }
}
