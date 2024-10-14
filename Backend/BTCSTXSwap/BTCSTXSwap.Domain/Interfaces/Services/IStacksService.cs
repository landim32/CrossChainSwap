using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Stacks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IStacksService
    {
        Task<long> GetBalance(string stxAddress);

        Task<string> GetPoolAddress();

        Task<TxHandleInfo> Transfer(TransferParamInfo param);

    }
}
