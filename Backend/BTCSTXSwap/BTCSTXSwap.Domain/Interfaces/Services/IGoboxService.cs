using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.DTO.Gobox;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoboxService
    {
        IList<GoboxInfo> ListByUser(long idUser);
        void Credit(long idUser, GoboxEnum boxType, int Qtdy, bool auction);
        void Debit(long idUser, GoboxEnum boxType, int Qtdy, bool auction);
        int GetBoxQtdy(long idUser, GoboxEnum boxType);
        GoboxInfo GetByGobox(long idUser, GoboxEnum boxType);
        void BuyBox(long idUser, GoboxEnum boxType, int qtdy);
        long OpenBox(long idUser, GoboxEnum boxType);
        IList<ItemInfo> OpenItemBox(long idUser, GoboxEnum boxType);
    }
}
