using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Finance
{
    public class FinanceTransacionInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("insertdate")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("credit")]
        public decimal Credit { get; set; }
        [JsonPropertyName("debit")]
        public decimal Debit { get; set; }
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonPropertyName("gas")]
        public decimal? Gas { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("txhash")]
        public string TxHash { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("statusmsg")]
        public string StatusMsg { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
