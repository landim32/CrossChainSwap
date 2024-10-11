using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.Mining
{
    public class GoblinEnergyMiningInfo
    {
        [JsonPropertyName("idgoblin")]
        public long IdGoblin { get; set; }
        [JsonPropertyName("goblinrarity")]
        public int GoblinRarity { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("exhausted")]
        public bool Exhausted { get; set; }
        [JsonPropertyName("energypercent")]
        public decimal EnergyPercent { get; set; }
        [JsonPropertyName("energycost")]
        public decimal EnergyCost { get; set; }
        [JsonPropertyName("chargeduration")]
        public int ChargeDuration { get; set; }
        [JsonPropertyName("lastcharge")]
        public DateTime? LastCharge { get; set; }
        [JsonPropertyName("chargeexpiration")]
        public DateTime? ChargeExpiration { get; set; }
        [JsonPropertyName("hascost")]
        public bool HasCost { get; set; }
    }
}
