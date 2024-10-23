using NoChainSwap.Domain.Impl.Models;
using System;
using System.Text.Json.Serialization;

namespace NoChainSwap.API.DTO
{
    public class TxLogResult
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("intlogtype")]
        public int IntLogType { get; set; }
        [JsonPropertyName("logtype")]
        public string LogType { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
