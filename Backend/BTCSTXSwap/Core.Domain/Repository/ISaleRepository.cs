using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface ISaleRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListGoblinSale(TFactory factory);
        TModel GetById(long saleId, TFactory factory);
        void UpdateSale(TModel model);
    }
}
