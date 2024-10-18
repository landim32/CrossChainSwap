using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface ITransactionLogRepository<TModel, TFactory>
    {
        TModel Insert(TModel model);
        IEnumerable<TModel> ListById(long logId, TFactory factory);
        IEnumerable<TModel> ListByBtcTx(string btcTx, TFactory factory);
        IEnumerable<TModel> ListByStxTx(string StxTx, TFactory factory);

    }
}
