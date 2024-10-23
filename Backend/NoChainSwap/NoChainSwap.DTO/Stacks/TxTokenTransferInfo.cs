using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Stacks
{
    public class TxTokenTransferInfo
    {
        [JsonProperty("recipient_address")]
        public string RecipientAddress {  get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("memo")]
        public string Memo { get; set; }
    }
}
