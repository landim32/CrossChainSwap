using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningRewardInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("insertdate")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("insertdatestr")]
        public string InsertDateStr { get; set; }
        [JsonPropertyName("claimdate")]
        public DateTime? ClaimDate { get; set; }
        [JsonPropertyName("gobivalue")]
        public decimal GobiValue { get; set; }
        [JsonPropertyName("credit")]
        public decimal Credit { get; set; }
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        [JsonPropertyName("percentfee")]
        public int PercentFee { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
