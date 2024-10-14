using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mempool
{
    public class TxSpendInInfo
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("vout")]
        public long VOut { get; set; }
        [JsonProperty("prevout")]
        public TxSpendOutInfo Prevout { get; set; }
        [JsonProperty("scriptsig")]
        public string ScriptSig { get; set; }
        [JsonProperty("scriptsig_asm")]
        public string ScriptSigAsm { get; set; }
        [JsonProperty("witness")]
        public IList<string> Witness { get; set; }
        [JsonProperty("is_coinbase")]
        public bool IsCoinbase { get; set; }
        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }
}
