using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Finance
{
    public class GoldTransactionListResult : StatusResult
    {
        [JsonPropertyName("transactions")]
        public IEnumerable<GoldTransactionInfo> Transactions { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("totalpages")]
        public int TotalPages { get; set; }
    }
}
