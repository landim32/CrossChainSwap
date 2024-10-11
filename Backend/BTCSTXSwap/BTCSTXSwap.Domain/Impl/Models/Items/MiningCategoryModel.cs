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
    public class MiningCategoryModel: IItemCategoryModel
    {
        public const int STONE = 10;
        public const int COAL = 11;
        public const int ORE = 12;
        public const int COPPER_ORE = 13;
        public const int TIN_ORE = 14;
        public const int IRON_ORE = 15;
        public const int SILVER_ORE = 16;
        public const int GOLD_ORE = 17;
        public const int COPPER_BAR = 18;
        public const int TIN_BAR = 19;
        public const int BRONZE_BAR = 20;
        public const int IRON_BAR = 21;
        public const int STEEL_BAR = 22;
        public const int SILVER_BAR = 23;
        public const int GOLD_BAR = 24;

        private const string CATEGORY = "Miner";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public MiningCategoryModel(ILogCore log, IItemDomainFactory itemFactory) {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = STONE;
            md.Category = CATEGORY;
            md.Name = "Rock";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/rock.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = ORE;
            md.Category = CATEGORY;
            md.Name = "Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/silver-ore.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = COAL;
            md.Category = CATEGORY;
            md.Name = "Coal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/coal.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = COPPER_ORE;
            md.Category = CATEGORY;
            md.Name = "Cooper Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/coper-ore.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 2;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = TIN_ORE;
            md.Category = CATEGORY;
            md.Name = "Tin Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/tin-ore.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 2;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = IRON_ORE;
            md.Category = CATEGORY;
            md.Name = "Iron Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/iron-ore.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 3;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = SILVER_ORE;
            md.Category = CATEGORY;
            md.Name = "Silver Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/silver-ore.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 5;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = GOLD_ORE;
            md.Category = CATEGORY;
            md.Name = "Gold Ore";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/gold-ore.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 10;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = COPPER_BAR;
            md.Category = CATEGORY;
            md.Name = "Copper bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/coper-bar.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 15;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = TIN_BAR;
            md.Category = CATEGORY;
            md.Name = "Tin bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/tin-bar.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 15;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = BRONZE_BAR;
            md.Category = CATEGORY;
            md.Name = "Bronze bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/bronze-bar.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 40;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = IRON_BAR;
            md.Category = CATEGORY;
            md.Name = "Iron bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/iron-bar.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 50;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = STEEL_BAR;
            md.Category = CATEGORY;
            md.Name = "Steel bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/steel-bar.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 70;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = SILVER_BAR;
            md.Category = CATEGORY;
            md.Name = "Silver bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/silver-bar.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 100;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = GOLD_BAR;
            md.Category = CATEGORY;
            md.Name = "Gold bar";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/gold-bar.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 200;
            i.Add(md);

            return i;
        }
    }
}
