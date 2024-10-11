using Core.Domain.Withdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IGoblinContract
    {
        string getWithdrawalAddress();
        Task<BigInteger> BalanceOf(string address);
        Task<string> OwnerOf(BigInteger tokenId);
        Task<BigInteger> TokenOfOwnerByIndex(string address, BigInteger index);
        Task<ITransactionStatusModel> Mint(string owner, BigInteger tokenId);
        Task<ITransactionStatusModel> Transfer(string to, BigInteger tokenId);
        Task<ITransactionStatusModel> GetTransaction(string txnHash);
    }
}
