using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.CoinMarketCap
{
    public class CoinSwapInfo
    {
        [JsonProperty("spread")]
        public decimal Spread { get; set; }
        [JsonProperty("btcbuyprice")]
        public decimal BtcBuyPrice { get; set; }
        [JsonProperty("btcsellprice")]
        public decimal BtcSellPrice { get; set; }
        [JsonProperty("stxbuyprice")]
        public decimal StxBuyPrice { get; set; }
        [JsonProperty("stxsellprice")]
        public decimal StxSellPrice { get; set; }
        [JsonProperty("btcproportion")]
        public decimal BtcProportion { get; set; }
        [JsonProperty("stxproportion")]
        public decimal StxProportion { get; set; }
        [JsonProperty("btctostxtext")]
        public string BtcToStxText { get; set; }
        [JsonProperty("stxtobtctext")]
        public string StxToBtcText { get; set; }
        [JsonProperty("original")]
        public CoinInfo Original { get; set; }
        [JsonProperty("destiny")]
        public CoinInfo Destiny { get; set; }
    }
}
