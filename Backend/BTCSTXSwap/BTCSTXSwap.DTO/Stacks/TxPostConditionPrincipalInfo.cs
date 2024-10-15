using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Stacks
{
    public class TxPostConditionPrincipalInfo
    {
        [JsonProperty("type_id")]
        public string TypeId {  get; set; }
    }
}
