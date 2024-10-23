using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Stacks;
using Newtonsoft.Json;

namespace NoChainSwap.Domain.Impl.Services
{
    public class StacksService: IStacksService
    {
        //private const string WALLET_API = "http://localhost:3000";
        //private const string WALLET_API = "http://172.18.0.4:3000";
        //private const string STACKS_API = "https://api.testnet.hiro.so/extended";

        public static string WALLET_API { get; set; }
        public static string STACKS_API { get; set; }

        public async Task<long> GetBalance(string stxAddress)
        {
            using (var client = new HttpClient())
            {
                string url = $"{STACKS_API}/v1/address/{stxAddress}/stx";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var balance = JsonConvert.DeserializeObject<StxBalanceInfo>(responseBody);
                long balanceLng = 0;
                if (!long.TryParse(balance.Balance, out balanceLng))
                {
                    throw new Exception(String.Format("Invalid balance ({0}).", balance.Balance));
                }
                return  balanceLng;
            }
        }

        public async Task<TxInfo> GetTransaction(string txId)
        {
            using (var client = new HttpClient())
            {
                string url = $"{STACKS_API}/v1/tx/{txId}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TxInfo>(responseBody);
            }
        }

        public async Task<string> GetPoolAddress() {
            using (var client = new HttpClient())
            {
                string url = $"{WALLET_API}/get-address";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<string>(responseBody);
            }
        }

        public string GetAddressUrl(string address)
        {
            return $"https://explorer.hiro.so/address/{address}?chain=testnet";
        }

        public string GetTransactionUrl(string txid)
        {
            return $"https://explorer.hiro.so/txid/{txid}?chain=testnet";
        }

        public string ConvertToString(long coin)
        {
            return ((decimal)coin / 100000000M).ToString("N5") + " STX";
        }

        public async Task<TxHandleInfo> Transfer(TransferParamInfo param)
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
