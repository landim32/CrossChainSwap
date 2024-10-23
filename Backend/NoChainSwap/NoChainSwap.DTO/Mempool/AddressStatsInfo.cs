using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Mempool
{
    public class AddressStatsInfo
    {
        [JsonProperty("funded_txo_count")]
        [JsonPropertyName("funded_txo_count")]
        public long FundedTXOCount { get; set; }
        [JsonProperty("funded_txo_sum")]
        [JsonPropertyName("funded_txo_sum")]
        public long FundedTXOSum { get; set; }
        [JsonProperty("spent_txo_count")]
        [JsonPropertyName("spent_txo_count")]
        public long SpentTXOCount { get; set; }
        [JsonProperty("spent_txo_sum")]
        [JsonPropertyName("spent_txo_sum")]
        public long SpentTXOSum { get; set; }
        [JsonProperty("tx_count")]
        [JsonPropertyName("tx_count")]
        public long TXCount { get; set; }
    }
}
