using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class AddressStatsInfo
    {
        [JsonProperty("funded_txo_count")]
        public long FundedTXOCount { get; set; }
        [JsonProperty("funded_txo_sum")]
        public long FundedTXOSum { get; set; }
        [JsonProperty("spent_txo_count")]
        public long SpentTXOCount { get; set; }
        [JsonProperty("spent_txo_sum")]
        public long SpentTXOSum { get; set; }
        [JsonProperty("tx_count")]
        public long TXCount { get; set; }
    }
}
