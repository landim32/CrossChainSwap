using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.CoinMarketCap
{
    public class CoinSwapInfo
    {
        public decimal Spread { get; set; }

        public decimal BtcBuyPrice { get; set; }
        public decimal BtcSellPrice { get; set; }
        public decimal StxBuyPrice { get; set; }
        public decimal StxSellPrice { get; set; }
        public decimal BtcProportion { get; set; }
        public decimal StxProportion { get; set; }
        public string BtcToStxText { get; set; }
        public string StxToBtcText { get; set; }
        public CoinInfo Original { get; set; }
        public CoinInfo Destiny { get; set; }
    }
}
