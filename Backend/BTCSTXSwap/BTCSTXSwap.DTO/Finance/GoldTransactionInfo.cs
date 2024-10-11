using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.DTO.Finance
{
    public class GoldTransactionInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("insertdate")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("iduser")]
        public long? IdUser { get; set; }
        [JsonPropertyName("gobidebit")]
        public decimal? GobiDebit { get; set; }
        [JsonPropertyName("gobicredit")]
        public decimal? GobiCredit { get; set; }
        [JsonPropertyName("transactiongobitax")]
        public decimal? TransactionGobiTax { get; set; }
        [JsonPropertyName("debit")]
        public decimal Debit { get; set; }
        [JsonPropertyName("credit")]
        public decimal Credit { get; set; }
        [JsonPropertyName("transactiongoldtax")]
        public decimal? TransactionGoldTax { get; set; }
        [JsonPropertyName("status")]
        public GoldTransactionEnum Status { get; set; }
    }
}
