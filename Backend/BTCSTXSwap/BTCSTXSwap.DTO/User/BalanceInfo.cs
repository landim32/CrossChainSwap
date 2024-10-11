using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.User
{
    public class BalanceInfo
    {
        [JsonPropertyName("gobiBalance")]
        public decimal GobiBalance { get; set; }
        [JsonPropertyName("cloudWalletGobiBalance")]
        public decimal CloudWalletGobiBalance { get; set; }
        [JsonPropertyName("goblinBalance")]
        public double GoblinBalance { get; set; }
        [JsonPropertyName("goldBalance")]
        public decimal GoldBalance { get; set; }
    }
}
