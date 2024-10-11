using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IDailyLoginRepository<TModel, TFactory>
    {
        TModel GetLastDailyByUser(TFactory factory, long idUser);
        void Delete(long id);
        long Insert(TFactory factory, TModel m);
        void Update(TFactory factory, TModel m);

    }
}
