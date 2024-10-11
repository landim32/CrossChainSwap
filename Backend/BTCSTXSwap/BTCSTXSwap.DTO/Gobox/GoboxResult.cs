using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Gobox
{
    public class GoboxResult : StatusResult
    {
        [JsonPropertyName("gobox")]
        public GoboxInfo Gobox { get; set; }
        [JsonPropertyName("tokenid")]
        public long TokenId { get; set; }
    }
}
