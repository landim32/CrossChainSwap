using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoChainSwap.DTO.Stacks
{
    public class TxHandleInfo
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("reason_data")]
        public TxReasonDataInfo ReasonData { get; set; }
    }
}
