using Core.Domain.Withdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Finance
{
    public class TransactionStatusModel: ITransactionStatusModel
    {
        public string TransactionHash { get; set; }
        public string ContractAddress { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public BigInteger Value { get; set; }
        public TransactionStatusEnum Status { get; set; }
        public string MessageError { get; set; }
        public decimal? GasUsed { get; set; }

    }
}
