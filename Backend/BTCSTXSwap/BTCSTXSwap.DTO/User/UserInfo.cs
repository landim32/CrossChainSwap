using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.User
{
    public class UserInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("btcAddress")]
        public string BtcAddress { get; set; }
        [JsonPropertyName("stxAddress")]
        public string StxAddress { get; set; }
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
