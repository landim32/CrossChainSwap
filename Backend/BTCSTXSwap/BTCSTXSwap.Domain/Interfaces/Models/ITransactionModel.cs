using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface ITransactionModel
    {
        long TxId { get; set; }
        TransactionEnum Type { get; set; }
        string BtcAddress { get; set; }
        string StxAddress { get; set; }
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }
        TransactionStatusEnum Status { get; set; }
        string BtcTxid { get; set; }
        string StxTxid { get; set; }
        int? BtcFee { get; set; }
        int? StxFee { get; set; }
        long? BtcAmount { get; set; }
        long? StxAmount { get; set; }

        ITransactionModel Save();
        ITransactionModel Update();
        ITransactionModel GetByBtcAddr(string btcAddr, ITransactionDomainFactory factory);
        ITransactionModel GetById(long txId, ITransactionDomainFactory factory);
        IEnumerable<ITransactionModel> ListByBtcAddr(string btcAddr, ITransactionDomainFactory factory);
        IEnumerable<ITransactionModel> ListByStatus(IList<int> status, ITransactionDomainFactory factory);
        IEnumerable<ITransactionModel> ListAll(ITransactionDomainFactory factory);
    }
}
