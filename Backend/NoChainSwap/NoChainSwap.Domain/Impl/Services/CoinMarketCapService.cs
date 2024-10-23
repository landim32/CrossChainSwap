using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.CoinMarketCap;
using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        //private const string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";
        private const string API_KEY = "7a2f3a1e-dac4-4a5a-8e38-8b535bedbe59";
        private const decimal SPREAD = 0.05M;
        private const string BTC_TO_STX_TEXT = "1 BTC = {0:N0} STX";
        private const string STX_TO_BTC_TEXT = "1 STX = {0:N0} Satoshis";

        private CoinInfo CurrencyToCoin(Currency data)
        {
            return new CoinInfo
            {
                ConvertCurrency = data.ConvertCurrency,
                Id = data.Id,
                LastUpdated = data.LastUpdated,
                MarketCapConvert = data.MarketCapConvert,
                MarketCapUsd = data.MarketCapUsd,
                Name = data.Name,
                PercentChange1h = data.PercentChange1h,
                PercentChange24h = data.PercentChange24h,
                PercentChange7d = data.PercentChange7d,
                Price = data.Price,
                Rank = data.Rank,
                Symbol = data.Symbol,
                Volume24hUsd = data.Volume24hUsd
            };
        }

        public CoinSwapInfo GetCurrentPrice(string slugOrig, string slugDest)
        {
            var slugs = new string[2] { slugOrig, slugDest };
            var client = new CoinmarketcapClient(API_KEY);
            var data = client.GetCurrencyBySlugList(slugs, "USD");
            var btcPrice = data.Where(x => x.Symbol == "BTC").First().Price;
            var stxPrice = data.Where(x => x.Symbol == "STX").First().Price;
            var btcProportion = (btcPrice * (1M - SPREAD)) / (stxPrice * (1M + SPREAD));
            var stxProportion = (stxPrice * (1M - SPREAD)) / (btcPrice * (1M + SPREAD));
            return new CoinSwapInfo
            {
                Spread = SPREAD,
                BtcBuyPrice = btcPrice * (1M - SPREAD),
                BtcSellPrice = btcPrice * (1M + SPREAD),
                StxBuyPrice = stxPrice * (1M - SPREAD),
                StxSellPrice = stxPrice * (1M + SPREAD),
                BtcProportion = btcProportion,
                StxProportion = stxProportion,
                BtcToStxText = string.Format(BTC_TO_STX_TEXT, btcProportion),
                StxToBtcText = string.Format(STX_TO_BTC_TEXT, stxProportion * 100000000),
                Original = CurrencyToCoin(data.First()),
                Destiny = CurrencyToCoin(data.Last())
            };
        }
    }
}
