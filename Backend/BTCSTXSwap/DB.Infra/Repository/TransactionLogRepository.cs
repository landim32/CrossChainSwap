using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class TransactionLogRepository : ITransactionLogRepository<ITransactionLogModel, ITransactionLogDomainFactory>
    {
        public ITransactionLogModel Insert(ITransactionLogModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransactionLogModel> ListByBtcTx(string btcTx, ITransactionLogDomainFactory factory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransactionLogModel> ListByStxTx(string StxTx, ITransactionLogDomainFactory factory)
        {
            throw new NotImplementedException();
        }
    }
}
