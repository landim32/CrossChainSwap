using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface ITransactionRepository<TModel, TFactory>
    {
        TModel SaveTx(TModel model);
        TModel GetByBtcAddr(string btcAddr, TFactory factory);
        TModel GetById(long txId, TFactory factory);
        TModel UpdateTx(TModel model);
        IEnumerable<TModel> ListByBtcAddr(string btcAddr, TFactory factory);
        TModel GetByBtcTxId(string txid, TFactory factory);
        TModel GetByStxTxId(string txid, TFactory factory);
        IEnumerable<TModel> ListByStatus(IList<int> status, TFactory factory);
        IEnumerable<TModel> ListAll(TFactory factory);
    }
}
