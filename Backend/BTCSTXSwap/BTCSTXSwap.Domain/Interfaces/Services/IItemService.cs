using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IItemService
    {
        ItemInfo GetItemByKey(long key);
        IItemModel GetItemModelByKey(long key);
        IEnumerable<ItemInfo> GetItemChest(long key);
    }
}
