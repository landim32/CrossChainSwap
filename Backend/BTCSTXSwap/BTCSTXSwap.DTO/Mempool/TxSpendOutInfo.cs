using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class TxSpendOutInfo
    {
        [JsonProperty("scriptpubkey")]
        public string ScriptPubKey { get; set; }
        [JsonProperty("scriptpubkey_asm")]
        public string ScriptPubKeyAsm { get; set; }
        [JsonProperty("scriptpubkey_type")]
        public string ScriptPubKeyType { get; set; }
        [JsonProperty("scriptpubkey_address")]
        public string ScriptPubKeyAddress { get; set; }
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
