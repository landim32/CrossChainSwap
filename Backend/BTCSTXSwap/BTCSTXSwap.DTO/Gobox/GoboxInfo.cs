using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Gobox
{
    public class GoboxInfo: GoboxPriceInfo
    {
        [JsonPropertyName("qtdy")]
        public int Qtdy { get; set; }
    }
}
