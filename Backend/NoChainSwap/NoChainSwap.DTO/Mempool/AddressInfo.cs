using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Mempool
{
    public class AddressInfo
    {
        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonProperty("chain_stats")]
        [JsonPropertyName("chain_stats")]
        public AddressStatsInfo ChainStats { get; set; }
        [JsonProperty("mempool_stats")]
        [JsonPropertyName("mempool_stats")]
        public AddressStatsInfo MempoolStats { get; set; }
    }
}
