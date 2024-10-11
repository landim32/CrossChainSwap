using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Gobox
{
    public class GoboxPriceInfo
    {
        [JsonPropertyName("boxtype")]
        public int BoxType { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("imageurl")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("price")]
        public int Price { get; set; }
    }
}
