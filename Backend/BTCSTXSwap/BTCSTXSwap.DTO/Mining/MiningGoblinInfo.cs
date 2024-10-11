using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningGoblinInfo
    {
        [JsonPropertyName("idtoken")]
        public long IdToken { get; set; }
        [JsonPropertyName("sprite")]
        public string Sprite { get; set; }
    }
}
