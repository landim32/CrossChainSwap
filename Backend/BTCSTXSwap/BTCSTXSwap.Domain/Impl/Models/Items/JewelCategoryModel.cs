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
    public class JewelCategoryModel: IItemCategoryModel
    {
        public const int PEARL = 1311;
        public const int DIAMOND = 1312;
        public const int JADE = 1313;
        public const int RUBI = 1314;
        private const string CATEGORY = "Jewel";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public JewelCategoryModel(ILogCore log, IItemDomainFactory itemFactory) {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = PEARL;
            md.Category = CATEGORY;
            md.Name = "Pearl";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/perl.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 30;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = JADE;
            md.Category = CATEGORY;
            md.Name = "Jade";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/greenStone.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 150;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RUBI;
            md.Category = CATEGORY;
            md.Name = "Rubi";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/redStone.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 150;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = DIAMOND;
            md.Category = CATEGORY;
            md.Name = "Diamond";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/diamond.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 300;
            i.Add(md);

            return i;
        }
    }
}
