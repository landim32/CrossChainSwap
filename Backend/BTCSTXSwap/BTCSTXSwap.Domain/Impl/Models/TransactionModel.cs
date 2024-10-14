using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.Transaction;
using Core.Domain;
using Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models
{
    public class TransactionModel : ITransactionModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository<ITransactionModel, ITransactionDomainFactory> _repositoryTx;

        public TransactionModel(IUnitOfWork unitOfWork, ITransactionRepository<ITransactionModel, ITransactionDomainFactory> repositoryTx)
        {
            _unitOfWork = unitOfWork;
            _repositoryTx = repositoryTx;
        }

        public long TxId { get; set; }
        public TransactionEnum Type { get; set; }
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public TransactionStatusEnum Status { get; set; }
        public string BtcTxid { get; set; }
        public string StxTxid { get; set; }
        public int? BtcFee { get; set; }
        public int? StxFee { get; set; }
        public long? BtcAmount { get; set; }
        public long? StxAmount { get; set; }

        public ITransactionModel GetByBtcAddr(string btcAddr, ITransactionDomainFactory factory)
        {
            return _repositoryTx.GetByBtcAddr(btcAddr, factory);
        }

        public ITransactionModel GetById(long txId, ITransactionDomainFactory factory)
        {
            return _repositoryTx.GetById(txId, factory);
        }

        public IEnumerable<ITransactionModel> ListTxByBtcAddr(ITransactionDomainFactory factory)
        {
            return _repositoryTx.ListTxByBtcAddr(factory);
        }

        public ITransactionModel Save()
        {
            return _repositoryTx.SaveTx(this);
        }

        public ITransactionModel Update()
        {
            return _repositoryTx.UpdateTx(this);
        }
    }
}
