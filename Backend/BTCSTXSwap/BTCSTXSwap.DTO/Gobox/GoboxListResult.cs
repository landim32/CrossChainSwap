using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Gobox
{
    public class GoboxListResult : StatusResult
    {
        [JsonPropertyName("goboxes")]
        public IList<GoboxInfo> Goboxes { get; set; }
    }
}
