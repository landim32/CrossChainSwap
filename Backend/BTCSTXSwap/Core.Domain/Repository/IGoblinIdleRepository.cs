using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IGoblinIdleRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListIdle(TFactory factory, int idUser);
        //IEnumerable<TModel> ListReadyForWork(string uidUser, IWorkModel w);

    }
}
