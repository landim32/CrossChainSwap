using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BTCSTXSwap.DTO.Stacks
{
    public class TxReasonDataInfo
    {
        [JsonProperty("actual")]
        public string Actual { get; set; }
        [JsonProperty("expected")]
        public string Expected { get; set; }
    }
}
