using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Stacks
{
    public class TxEventInfo
    {
        [JsonProperty("event_index")]
        public long EventIndex {  get; set; }
        [JsonProperty("event_type")]
        public string EventType { get; set; }
        [JsonProperty("tx_id")]
        public string TxId { get; set; }
        [JsonProperty("contract_log")]
        public TxContractLogInfo ContractLog {  get; set; }

    }
}
