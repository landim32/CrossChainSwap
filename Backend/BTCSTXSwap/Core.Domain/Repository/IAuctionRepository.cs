using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IAuctionRepository<TFactory, TModel, TFilter, TEquipFilter>
    {
        IEnumerable<TModel> Search(TFactory factory, TFilter filter, out int balance);
        IEnumerable<TModel> SearchEquipment(TFactory factory, TEquipFilter filter, out int balance);
        IEnumerable<TModel> ListByAuction(TFactory factory, int auction, int page, out int balance);
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser, int auction);
        IEnumerable<TModel> ListSameEquipment(TFactory factory, long idUser, long itemKey);
        TModel GetById(TFactory factory, long idAuction);
        TModel GetLastActiveByIdGoblin(TFactory factory, long idGoblin);
        long Insert(TModel md);
        long Update(TModel md);
        void Delete(long idAunction);
    }
}
