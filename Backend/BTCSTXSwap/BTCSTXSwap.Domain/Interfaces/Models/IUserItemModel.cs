using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IUserItemModel
    {
        long IdItem { get; set; }
        long ItemKey { get; set; }
        long IdUser { get; set; }
        int Qtde { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }

        IItemModel GetItem();
        IEnumerable<IUserItemModel> ListById(long idUser);
        IList<IUserItemModel> ListTrashByUser(long idUser);
        IUserItemModel GetById(long idItem);
        IUserItemModel GetByKey(long idUser, long key);
        IUserItemModel GetByPosition(long idUser, int x, int y);
        void Save();
        void Delete();
    }
}
