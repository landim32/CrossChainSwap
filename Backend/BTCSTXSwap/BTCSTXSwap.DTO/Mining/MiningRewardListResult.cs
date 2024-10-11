using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningRewardListResult: StatusResult
    {
        [JsonPropertyName("rewards")]
        public IList<MiningRewardInfo> Rewards { get; set; }
    }
}
