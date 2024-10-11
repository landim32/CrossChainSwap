using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Withdraw
{
    public interface ITransactionStatusModel
    {
        string TransactionHash { get; set; }
        string ContractAddress { get; set; }
        string FromAddress { get; set; }
        string ToAddress { get; set; }
        BigInteger Value { get; set; }
        TransactionStatusEnum Status { get; set; }
        string MessageError { get; set; }
        decimal? GasUsed { get; set; }
    }
}
