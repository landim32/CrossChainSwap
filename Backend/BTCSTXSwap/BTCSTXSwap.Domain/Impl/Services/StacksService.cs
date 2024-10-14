using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCSTXSwap.Domain.Interfaces.Services;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class StacksService: IStacksService
    {
        private const string WALLET_API = "http://localhost:3000";
        private const string STACKS_API = "https://api.testnet.hiro.so/extended";

        public Task<long> GetBalance(string stxAddress)
        {
            using (var client = new HttpClient())
            {
                string url = $"{STACKS_API}//v1/address/{stxAddress}/stx";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var balance = JsonConvert.DeserializeObject<StxBalanceInfo>(responseBody);
                return balance.Balance;
            }
        }

        public Task<string> GetPoolAddress() {
            using (var client = new HttpClient())
            {
                string url = $"{WALLET_API}/get-address";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<string>(responseBody);
            }
        }

        public Task<TxHandleInfo> Transfer(TransferParamInfo param)
        {
            using (var client = new HttpClient())
            {
                string url = $"{WALLET_API}/transfer";
                var jsonContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url, jsonContent);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TxHandleInfo>(responseBody);
            }
        }
    }
}
