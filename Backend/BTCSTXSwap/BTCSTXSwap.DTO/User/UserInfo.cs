using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.DTO.User
{
    public class UserInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("publicAddress")]
        public string PublicAddress { get; set; }
        [JsonPropertyName("fromreferralcode")]
        public string FromReferralCode { get; set; }
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("imageminedate")]
        public DateTime? ImageMineDate { get; set; }
    }
}
