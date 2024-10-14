using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionDomainFactory _txFactory;

        public TransactionService(ITransactionDomainFactory txFactory)
        {
            _txFactory = txFactory;
        }

        public ITransactionModel CreateTx(TransactionParamInfo param)
        {
            try
            {
                var model = _txFactory.BuildTransactionModel();
                model.Type = param.BtcToStx ? TransactionEnum.BtcToStx : TransactionEnum.StxToBtc;
                model.BtcAddress = param.BtcAddress;
                model.StxAddress = param.StxAddress; 
                model.CreateAt = DateTime.Now;
                model.UpdateAt = DateTime.Now;
                model.Status = TransactionStatusEnum.Initialized;
                model.BtcAmount = param.BtcAmount;
                model.StxAmount = param.StxAmount;
                model.BtcTxid = param.BtcTxid;
                model.StxTxid = param.StxTxid;
                model.BtcFee = null;
                model.StxFee = null;

                model.Save();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel GetTx(long txId)
        {
            try
            {
                return _txFactory.BuildTransactionModel().GetById(txId, _txFactory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel Update(TransactionInfo tx)
        {
            try
            {
                var model = _txFactory.BuildTransactionModel().GetById(tx.TxId, _txFactory);
                if (model == null)
                {
                    throw new Exception("Transaction not found.");
                }
                model.UpdateAt = DateTime.Now;
                model.Status = tx.Status;
                model.BtcAmount = tx.BtcAmount;
                model.StxAmount = tx.StxAmount;
                model.BtcTxid = tx.BtcTxid;
                model.StxTxid = tx.StxTxid;
                model.BtcFee = tx.BtcFee;
                model.StxFee = tx.StxFee;
                return model.Update();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
