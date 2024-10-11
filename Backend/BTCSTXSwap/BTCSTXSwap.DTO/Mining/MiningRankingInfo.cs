using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningRankingInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hashpower")]
        public int HashPower { get; set; }
        [JsonPropertyName("hashforweek")]
        public long? HashforWeek { get; set; }
        [JsonPropertyName("hashformonth")]
        public long? HashforMonth { get; set; }
        [JsonPropertyName("goblinqtde")]
        public int GoblinQtde { get; set; }
        [JsonPropertyName("ranking")]
        public int Ranking { get; set; }
    }
}
