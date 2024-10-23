using NoChainSwap.Domain.Interfaces.Services;
using NoChainSwap.DTO.Mempool;
using NBitcoin;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Services
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

        public string GetAddressUrl(string address)
        {
            return $"https://mempool.space/testnet/address/{address}";
        }

        public string GetTransactionUrl(string txid)
        {
            return $"https://mempool.space/testnet/tx/{txid}";
        }

        public string ConvertToString(long coin)
        {
            return ((decimal)coin / 100000000M).ToString("N5") + " BTC";
        }

        public void RegisterTx(string txid)
        {
            throw new NotImplementedException();
        }
    }
}
