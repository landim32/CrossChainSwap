using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class GoblinEnergyMiningResult : StatusResult
    {
        [JsonPropertyName("goblinEnergy")]
        public GoblinEnergyMiningInfo GoblinEnergy { get; set; }
    }
}
