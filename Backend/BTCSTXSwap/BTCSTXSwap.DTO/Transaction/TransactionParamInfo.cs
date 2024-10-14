using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Transaction
{
    public class TransactionParamInfo
    {
        [JsonPropertyName("btcToStx")]
        public bool BtcToStx { get; set; }
        [JsonPropertyName("btcAddress")]
        public string BtcAddress { get; set; }
        [JsonPropertyName("stxAddress")]
        public string StxAddress { get; set; }
        [JsonPropertyName("btcTxid")]
        public string BtcTxid { get; set; }
        [JsonPropertyName("stxTxid")]
        public string StxTxid { get; set; }
        [JsonPropertyName("btcAmount")]
        public long? BtcAmount { get; set; }
        [JsonPropertyName("stxAmount")]
        public long? StxAmount { get; set; }
    }
}
