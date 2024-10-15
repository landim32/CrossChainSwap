using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Stacks
{
    public class TxResultInfo
    {
        [JsonProperty("hex")]
        public string Hex {  get; set; }
        [JsonProperty("repr")]
        public string Repr { get; set; }
    }
}
