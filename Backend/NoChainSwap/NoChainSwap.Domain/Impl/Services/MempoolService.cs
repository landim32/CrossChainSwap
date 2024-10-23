using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Mempool;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Services
{
    public class MempoolService: IMempoolService
    {
        public async Task<long> GetBalance(string address)
        {
            using (var client = new HttpClient())
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
            using (var client = new HttpClient())
            {
                string url = "https://mempool.space/testnet/api/v1/fees/recommended";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RecommendedFeeInfo>(responseBody);
            }
        }

        public async Task<TxInfo> GetTransaction(string txid)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://mempool.space/testnet/api/tx/{txid}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TxInfo>(responseBody);
            }
        }
    }
}
