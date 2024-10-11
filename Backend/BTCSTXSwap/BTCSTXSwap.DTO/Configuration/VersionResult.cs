using System;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.Configuration
{
    public class VersionResult : StatusResult
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
