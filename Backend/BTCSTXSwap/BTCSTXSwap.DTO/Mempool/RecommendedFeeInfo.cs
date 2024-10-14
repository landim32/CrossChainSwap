using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class RecommendedFeeInfo
    {
        [JsonPropertyName("fastestFee")]
        public int FastestFee { get; set; }
        [JsonPropertyName("halfHourFee")]
        public int HalfHourFee { get; set; }
        [JsonPropertyName("hourFee")]
        public int HourFee { get; set; }
        [JsonPropertyName("economyFee")]
        public int EconomyFee { get; set; }
        [JsonPropertyName("minimumFee")]
        public int MinimumFee { get; set; }
    }
}
