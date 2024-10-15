using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Stacks
{
    public class TxPostConditionInfo
    {
        [JsonProperty("principal")]
        public TxPostConditionPrincipalInfo Principal {  get; set; }
        [JsonProperty("condition_code")]
        public string ConditionCode { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
