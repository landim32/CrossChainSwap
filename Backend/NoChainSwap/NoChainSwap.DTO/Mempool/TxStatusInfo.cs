using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Mempool
{
    public class TxStatusInfo
    {
        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }
        [JsonProperty("block_height")]
        public int BlockHeight { get; set; }
        [JsonProperty("block_hash")]
        public string BlockHash { get; set; }
        [JsonProperty("block_time")]
        public int BlockTime { get; set; }
    }
}
