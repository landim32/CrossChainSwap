using System.Text.Json.Serialization;

namespace NoChainSwap.API.DTO
{
    public class TxResult
    {
        [JsonPropertyName("txid")]
        public long TxId { get; set; }
        [JsonPropertyName("inttype")]
        public int IntType { get; set; }
        [JsonPropertyName("txtype")]
        public string TxType { get; set; }
        [JsonPropertyName("btcaddress")]
        public string BtcAddress { get; set; }
        [JsonPropertyName("btcaddressurl")]
        public string BtcAddressUrl { get; set; }
        [JsonPropertyName("stxaddress")]
        public string StxAddress { get; set; }
        [JsonPropertyName("stxaddressurl")]
        public string StxAddressUrl { get; set; }
        [JsonPropertyName("createat")]
        public string CreateAt { get; set; }
        [JsonPropertyName("updateat")]
        public string UpdateAt { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("btctxid")]
        public string BtcTxid { get; set; }
        [JsonPropertyName("btctxidurl")]
        public string BtcTxidUrl { get; set; }
        [JsonPropertyName("stxtxid")]
        public string StxTxid { get; set; }
        [JsonPropertyName("stxtxidurl")]
        public string StxTxidUrl { get; set; }
        [JsonPropertyName("btcfee")]
        public string BtcFee { get; set; }
        [JsonPropertyName("stxfee")]
        public string StxFee { get; set; }
        [JsonPropertyName("btcamount")]
        public string BtcAmount { get; set; }
        [JsonPropertyName("stxamount")]
        public string StxAmount { get; set; }
    }
}
