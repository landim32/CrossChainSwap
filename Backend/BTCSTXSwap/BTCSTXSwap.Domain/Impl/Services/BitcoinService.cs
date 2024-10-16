using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Mempool;
using NBitcoin;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
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

        public void RegisterTx(string txid)
        {
            throw new NotImplementedException();
        }
    }
}
