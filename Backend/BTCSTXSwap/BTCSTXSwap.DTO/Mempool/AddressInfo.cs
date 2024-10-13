using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class AddressInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("chain_stats")]
        public AddressStatsInfo ChainStats { get; set; }
        [JsonProperty("mempool_stats")]
        public AddressStatsInfo MempoolStats { get; set; }
    }
}
