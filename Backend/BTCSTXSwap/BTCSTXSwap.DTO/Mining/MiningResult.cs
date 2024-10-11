using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningResult: StatusResult
    {
        [JsonPropertyName("mining")]
        public MiningInfo Mining { get; set; }
    }
}
