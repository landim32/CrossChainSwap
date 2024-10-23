using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoChainSwap.DTO.Stacks;

namespace NoChainSwap.Domain.Interfaces.Services
{
    public interface IStacksService
    {
        Task<long> GetBalance(string stxAddress);
        Task<TxInfo> GetTransaction(string txId);
        Task<string> GetPoolAddress();
        string GetAddressUrl(string address);
        string GetTransactionUrl(string txid);
        string ConvertToString(long coin);
        Task<TxHandleInfo> Transfer(TransferParamInfo param);

    }
}
