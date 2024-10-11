using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("lastmining")]
        public DateTime LastMining { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hashpower")]
        public int HashPower { get; set; }
        [JsonPropertyName("goblinqtde")]
        public int GoblinQtde { get; set; }
        [JsonPropertyName("rewardpermonth")]
        public decimal RewardPerMonth { get; set; }
        [JsonPropertyName("rewardpersecond")]
        public decimal RewardPerSecond { get; set; }
        [JsonPropertyName("gobi")]
        public decimal Gobi { get; set; }
        //[JsonPropertyName("ranking")]
        //public int Ranking { get; set; }
        [JsonPropertyName("minhashpower")]
        public int MinHashPower { get; set; }
        [JsonPropertyName("totalhashpower")]
        public int TotalHashPower { get; set; }
        [JsonPropertyName("dailyreward")]
        public int DailyReward { get; set; }
        [JsonPropertyName("goblins")]
        public IList<GoblinInfo> Goblins { get; set; } = new List<GoblinInfo>();
    }
}
