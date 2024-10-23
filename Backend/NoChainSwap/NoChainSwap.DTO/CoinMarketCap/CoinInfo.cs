using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.CoinMarketCap
{
    public class CoinInfo
    {
        public string Id { get; set; }
        public string ConvertCurrency { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal MarketCapConvert { get; set; }
        public decimal MarketCapUsd { get; set; }
        public string Name { get; set; }
        public decimal PercentChange1h { get; set; }
        public decimal PercentChange24h { get; set; }
        public decimal PercentChange7d { get; set; }
        public decimal Price { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public decimal Volume24hUsd { get; set; }

    }
}
