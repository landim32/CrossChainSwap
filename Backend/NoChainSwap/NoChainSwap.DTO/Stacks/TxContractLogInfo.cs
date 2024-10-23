using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Stacks
{
    public class TxContractLogInfo
    {
        [JsonProperty("contract_id")]
        public string ContractId {  get; set; }
        [JsonProperty("topic")]
        public string Topic {  get; set; }
        [JsonProperty("value")]
        public TxResultInfo Value { get; set; }
    }
}
