using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IUserQuestRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser);
        IEnumerable<TModel> ListActiveJobsByUser(TFactory factory, long idUser);
        TModel GetById(TFactory factory, long idQuest);
        long Save(TModel quest);
        void Delete(TModel quest);
    }
}
