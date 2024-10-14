using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class TxInfo
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("locktime")]
        public int Locktime { get; set; }
        [JsonProperty("vin")]
        public IList<TxSpendInInfo> VIn { get; set; }
        [JsonProperty("vout")]
        public IList<TxSpendOutInfo> VOut { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
        [JsonProperty("sigops")]
        public int Sigops { get; set; }
        [JsonProperty("fee")]
        public int Fee { get; set; }
        [JsonProperty("status")]
        public TxStatusInfo Status { get; set; }

    }
}
