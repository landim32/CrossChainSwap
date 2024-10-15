using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface ITransactionLogModel
    {
        long LogId { get; set; }
        string TxId { get; set; }
        DateTime Date {  get; set; }
        LogTypeEnum LogType { get; set; }
        string Message { get; set; }

        ITransactionLogModel Insert();
        IEnumerable<ITransactionLogModel> GetByBtcTx(string txId, ITransactionLogDomainFactory factory);
        IEnumerable<ITransactionLogModel> GetByStxTx(string txId, ITransactionLogDomainFactory factory);
    }
}
