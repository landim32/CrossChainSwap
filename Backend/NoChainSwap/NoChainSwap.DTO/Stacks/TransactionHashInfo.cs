using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Stacks
{
    public class TransactionHashInfo
    {
        [JsonProperty("transactionHash")]
        public TxHandleInfo TransactionHash { get; set; }
    }
}
