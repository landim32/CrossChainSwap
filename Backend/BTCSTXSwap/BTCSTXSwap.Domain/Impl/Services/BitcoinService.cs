using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Mempool;
using NBitcoin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class BitcoinService: IBitcoinService
    {
        private const string MNEMONIC = "aunt federal magic they culture car primary maple snack misery dumb force three erosion vendor chair just twice blade front unhappy miss inject under";

        public string GetPoolAddress()
        {
            Mnemonic mnemo = new Mnemonic(MNEMONIC);
            var extKey = mnemo.DeriveExtKey();
            var bitcoinSecret = extKey.PrivateKey.GetBitcoinSecret(Network.TestNet);
            var address = bitcoinSecret.GetAddress(ScriptPubKeyType.Segwit);
            return address.ToString();
        }

        public async Task<long> GetBalance(string address)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://mempool.space/testnet/api/address/{address}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var addr = JsonConvert.DeserializeObject<AddressInfo>(responseBody);

                long balance = addr.ChainStats.FundedTXOSum - addr.ChainStats.SpentTXOSum;
                return balance;
            }
        }

        public async Task<RecommendedFeeInfo> GetRecommededFee()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://mempool.space/testnet/api/v1/fees/recommended";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RecommendedFeeInfo>(responseBody);
            }
        }

        public void RegisterTx(string txid)
        {
            throw new NotImplementedException();
        }
    }
}
