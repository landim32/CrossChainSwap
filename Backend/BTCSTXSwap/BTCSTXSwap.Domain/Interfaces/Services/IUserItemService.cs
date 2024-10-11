using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IUserItemService
    {
        UserItemInfo GetById(long idItem);
        UserItemInfo GetByPosition(long idUser, int x, int y);
        UserItemInfo GetByKey(long idUser, long key, bool forced = false);
        int Add(long idUser, long key, int qtde);
        int Remove(long idUser, long key, int qtde);
        bool Move(long idUser, long idItem, int x, int y);
        IList<UserItemInfo> List(long idUser);
        ItemDestroyResult DestroyItem(long idUser, long idItem, int qtde);
        void SellAllTrash(long idUser);
        void Sell(long idUser, long key, int qtde);
        ItemInfo GetRandomItem(ItemRarityEnum rarity);
    }
}
