using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.GLog
{
    public class GlogInfo
    {
        [JsonPropertyName("idlog")]
        public long IdLog { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
        [JsonPropertyName("insertdate")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("logtype")]
        public string LogType { get; set; }
    }
}
