using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Withdraw
{
    public interface IGobiWithdraw
    {
        string GetContractAddress();
        Task<BigInteger> GetBalanceOf();
        Task<decimal> GetBalanceBnbOf();
        Task<ITransactionStatusModel> GetTransaction(string txnHash);
        Task<ITransactionStatusModel> Transfer(string to, BigInteger value);
    }
}
