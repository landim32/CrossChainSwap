using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO
{
    public class PoolInfo
    {
        [JsonProperty("btcaddress")]
        public string BtcAddress { get; set; }
        [JsonProperty("stxaddress")]
        public string StxAddress { get; set; }
        [JsonProperty("btcbalance")]
        public long BtcBalance { get; set; }
        [JsonProperty("stxbalance")]
        public long StxBalance { get; set; }
    }
}
