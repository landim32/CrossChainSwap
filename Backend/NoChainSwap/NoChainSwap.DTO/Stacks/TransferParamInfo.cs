using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoChainSwap.DTO.Stacks
{
    public class TransferParamInfo
    {
        [JsonProperty("recipientAddress")]
        public string recipientAddress { get; set; }
        [JsonProperty("amount")]
        public long amount { get; set; }
    }
}
