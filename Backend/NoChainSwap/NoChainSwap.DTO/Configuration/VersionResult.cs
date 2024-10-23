using System;
using System.Text.Json.Serialization;
using NoChainSwap.DTO.Domain;

namespace NoChainSwap.DTO.Configuration
{
    public class VersionResult : StatusResult
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
