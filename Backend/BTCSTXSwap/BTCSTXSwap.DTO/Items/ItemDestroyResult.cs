using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Items
{
    public class ItemDestroyResult: StatusResult
    {
        [JsonPropertyName("Gold")]
        public long Gold { get; set; }
        [JsonPropertyName("Gobi")]
        public decimal Gobi { get; set; }
        [JsonPropertyName("items")]
        public IList<UserItemInfo> Items { get; set; }
    }
}
