using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.GLog
{
    public class GLogListResult : StatusResult
    {
        [JsonPropertyName("logs")]
        public IList<GlogInfo> Logs { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("totalpages")]
        public int TotalPages { get; set; }
    }
}
