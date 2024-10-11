using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Finance
{
    public class FinanceNumberResult : StatusResult
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
