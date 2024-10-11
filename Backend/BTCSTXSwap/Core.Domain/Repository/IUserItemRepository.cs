using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IUserItemRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListByUid(TFactory factory, long idUser);
        TModel GetByKey(TFactory factory, long idUser, long key);
        TModel GetById(TFactory factory, long idItem);
        TModel GetByPosition(TFactory factory, long idUser, int x, int y);
        long Insert(TModel md);
        long Update(TModel md);
        void Delete(long idItem);
    }
}
