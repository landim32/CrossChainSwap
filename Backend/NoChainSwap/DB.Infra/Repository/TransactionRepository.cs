using NoChainSwap.Domain.Interfaces.Factory;
using NoChainSwap.Domain.Interfaces.Models;
using NoChainSwap.DTO.Transaction;
using Core.Domain.Repository;
using DB.Infra.Context;
using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class TransactionRepository : ITransactionRepository<ITransactionModel, ITransactionDomainFactory>
    {
        private NoChainSwapContext _ccsContext;

        public TransactionRepository(NoChainSwapContext ccsContext)
        {
            _ccsContext = ccsContext;
        }

        private ITransactionModel DbToModel(ITransactionDomainFactory factory, Transaction u)
        {
            var md = factory.BuildTransactionModel();
            md.TxId = u.TxId;
            md.Type = (TransactionEnum) u.Type;
            md.BtcAddress = u.BtcAddress;
            md.StxAddress = u.StxAddress;
            md.CreateAt = u.CreateAt;
            md.UpdateAt = u.UpdateAt;
            md.Status = (TransactionStatusEnum)u.Status;
            md.BtcTxid = u.BtcTxid;
            md.StxTxid = u.StxTxid;
            md.BtcFee = u.BtcFee;
            md.StxFee = u.StxFee;
            md.BtcAmount = u.BtcAmount;
            md.StxAmount = u.StxAmount;
            return md;
        }

        private void ModelToDb(ITransactionModel u, Transaction md)
        {
            md.TxId = u.TxId;
            md.Type = (int)u.Type;
            md.BtcAddress = u.BtcAddress;
            md.StxAddress = u.StxAddress;
            md.CreateAt = u.CreateAt;
            md.UpdateAt = u.UpdateAt;
            md.Status = (int)u.Status;
            md.BtcTxid = u.BtcTxid;
            md.StxTxid = u.StxTxid;
            md.BtcFee = u.BtcFee;
            md.StxFee = u.StxFee;
            md.BtcAmount = u.BtcAmount;
            md.StxAmount = u.StxAmount;
        }

        public ITransactionModel GetByBtcAddr(string btcAddr, ITransactionDomainFactory factory)
        {
            try
            {
                var row = _ccsContext.Transactions.Where(x => x.BtcAddress == btcAddr).FirstOrDefault();
                if (row != null)
                {
                    return DbToModel(factory, row);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel GetById(long txId, ITransactionDomainFactory factory)
        {
            try
            {
                var row = _ccsContext.Transactions.Where(x => x.TxId == txId).FirstOrDefault();
                if (row != null)
                {
                    return DbToModel(factory, row);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ITransactionModel> ListByBtcAddr(string btcAddr, ITransactionDomainFactory factory)
        {
            var rows = _ccsContext.Transactions.ToList();
            return rows.Select(x => DbToModel(factory, x));
        }

        public IEnumerable<ITransactionModel> ListByStatus(IList<int> status, ITransactionDomainFactory factory)
        {
            var rows = _ccsContext.Transactions.Where(x => status.Contains(x.Status)).OrderBy(x => x.CreateAt).ToList();
            return rows.Select(x => DbToModel(factory, x));
        }

        public IEnumerable<ITransactionModel> ListAll(ITransactionDomainFactory factory)
        {
            var rows = _ccsContext.Transactions.OrderByDescending(x => x.UpdateAt).Take(100).ToList();
            return rows.Select(x => DbToModel(factory, x));
        }

        public ITransactionModel SaveTx(ITransactionModel model)
        {
            try
            {
                var u = new Transaction();
                ModelToDb(model, u);

                _ccsContext.Add(u);
                _ccsContext.SaveChanges();
                model.TxId = u.TxId;
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ITransactionModel UpdateTx(ITransactionModel model)
        {
            try
            {
                var row = _ccsContext.Transactions.Where(x => x.TxId == model.TxId).FirstOrDefault();
                ModelToDb(model, row);
                _ccsContext.Transactions.Update(row);
                _ccsContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
