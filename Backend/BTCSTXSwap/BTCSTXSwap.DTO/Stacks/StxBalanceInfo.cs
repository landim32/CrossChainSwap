using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BTCSTXSwap.DTO.Stacks
{
    public class StxBalanceInfo
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
