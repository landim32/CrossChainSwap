using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IGoboxRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser);
        TModel GetGobox(TFactory factory, long idUser, int boxType);
        bool CheckOpenedGoblinBox(long idUser);
        bool CheckBuyGoblinBox(long idUser);
        int GetBoxQtdy(long idUser, int boxType);
        void Insert(TModel md);
        void Update(TModel md);
        void Delete(long idItem);
    }
}