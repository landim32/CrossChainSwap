using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Goblins
{
    public interface IGoblinPerkRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListByGoblin(TFactory factory, long idGoblin);
        void Insert(TModel perk);
        void Clear(long idGoblin);
    }
}
