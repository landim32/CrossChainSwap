using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Finance
{
    public class DepositInfo
    {
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("token")]
        public int Token { get; set; }
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
        [JsonPropertyName("transactionhash")]
        public string TransactionHash { get; set; }
    }
}
