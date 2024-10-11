using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IGLogRepository<TModel, TFactory>
    {
        IEnumerable<TModel> List(TFactory factory, long idUser, int page, out int balance);
        void Insert(TModel md);
    }
}
