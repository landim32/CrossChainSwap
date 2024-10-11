using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.DTO.Items
{
    public class MaterialTradeInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("insertdate")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("iduser")]
        public long? IdUser { get; set; }
        [JsonPropertyName("materialkey")]
        public long MaterialKey { get; set; }
        [JsonPropertyName("materialcredit")]
        public long MaterialCredit { get; set; }
        [JsonPropertyName("materialdebit")]
        public long MaterialDebit { get; set; }
        [JsonPropertyName("goldcredit")]
        public decimal GoldCredit { get; set; }
        [JsonPropertyName("golddebit")]
        public decimal GoldDebit { get; set; }
        [JsonPropertyName("status")]
        public MaterialTradeEnum Status { get; set; }
    }
}
