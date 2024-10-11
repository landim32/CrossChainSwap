using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IMaterialMarketRepository<TModel, TFactory>
    {
        void Insert(TModel model);
        long GetTotalMaterial(long keyMaterial);
        decimal GetTotalGoldMaterial(long keyMaterial);
    }
}
