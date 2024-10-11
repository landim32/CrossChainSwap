using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class ItemBoxCategoryModel : IItemCategoryModel
    {
        public const int ITEM_COMMON = 9801;
        public const int ITEM_UNCOMMON = 9802;
        public const int ITEM_RARE = 9803;
        public const int ITEM_EPIC = 9804;
        public const int ITEM_LEGENDARY = 9805;

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public ItemBoxCategoryModel(ILogCore log, IItemDomainFactory itemFactory)
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;


            md = _itemFactory.BuildItemModel();
            md.Key = ITEM_COMMON;
            md.Category = "ItemBox";
            md.Name = "Common Item Box";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/item-common.png";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            md.IsBag = true;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = ITEM_UNCOMMON;
            md.Category = "ItemBox";
            md.Name = "Uncommon Item Box";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/item-uncommon.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.Price = 1;
            md.IsBag = true;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = ITEM_RARE;
            md.Category = "ItemBox";
            md.Name = "Rare Item Box";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/item-rare.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.Price = 1;
            md.IsBag = true;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = ITEM_EPIC;
            md.Category = "ItemBox";
            md.Name = "Rare Item Box";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/item-epic.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.Price = 1;
            md.IsBag = true;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = ITEM_LEGENDARY;
            md.Category = "ItemBox";
            md.Name = "Legendary Item Box";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/item-legendary.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.Price = 1;
            md.IsBag = true;
            md.IsTrash = false;
            i.Add(md);

            return i;
        }
    }
}
