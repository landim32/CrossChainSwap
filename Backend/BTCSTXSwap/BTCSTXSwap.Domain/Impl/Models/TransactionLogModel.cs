    using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using Core.Domain.Repository;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models
{
    public class TransactionLogModel: ITransactionLogModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionLogRepository<ITransactionLogModel, ITransactionLogDomainFactory> _repositoryTxLog;

        public TransactionLogModel(IUnitOfWork unitOfWork, ITransactionLogRepository<ITransactionLogModel, ITransactionLogDomainFactory> repositoryTxLog)
        {
            _unitOfWork = unitOfWork;
            _repositoryTxLog = repositoryTxLog;
        }

        public long LogId { get; set; }
        public long TxId { get; set; }
        public DateTime Date { get; set; }
        public LogTypeEnum LogType { get; set; }
        public string Message { get; set; }

        public ITransactionLogModel Insert()
        {
            return _repositoryTxLog.Insert(this);
        }
        public IEnumerable<ITransactionLogModel> GetByBtcTx(string txId, ITransactionLogDomainFactory factory)
        {
            return _repositoryTxLog.ListByBtcTx(txId, factory);
        }
        public IEnumerable<ITransactionLogModel> GetByStxTx(string txId, ITransactionLogDomainFactory factory)
        {
            return _repositoryTxLog.ListByBtcTx(txId, factory);
        }
    }
}
