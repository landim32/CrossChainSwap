using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinListResult : StatusResult
    {
        [JsonPropertyName("goblins")]
        public IEnumerable<GoblinInfo> Goblins { get; set; }
        [JsonPropertyName("page")]
        public long Page { get; set; }
        [JsonPropertyName("totalPages")]
        public long TotalPages { get; set; }
        [JsonPropertyName("cursorGob")]
        public long CursorGob { get; set; }
    }
}
