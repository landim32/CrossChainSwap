using BTCSTXSwap.DTO.Mempool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IBitcoinService
    {
        string GetPoolAddress();
        string GetAddressUrl(string address);
        string GetTransactionUrl(string txid);
        string ConvertToString(long coin);
        void RegisterTx(string txid);
    }
}
