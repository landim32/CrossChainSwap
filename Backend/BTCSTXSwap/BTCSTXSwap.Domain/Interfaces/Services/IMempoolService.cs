using BTCSTXSwap.DTO.Mempool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IMempoolService
    {
        Task<long> GetBalance(string address);
        Task<RecommendedFeeInfo> GetRecommededFee();
        Task<TxInfo> GetTransaction(string txid);
    }
}
