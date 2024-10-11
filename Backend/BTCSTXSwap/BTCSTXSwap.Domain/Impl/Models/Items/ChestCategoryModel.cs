using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class ChestCategoryModel: IItemCategoryModel
    {
        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;
        private readonly IDestroyRewardDomainFactory _destroyRewardFactory;
        private readonly IItemDestroyRewardDomainFactory _itemDestroyRewardFactory;

        public const int CHEST_COMMOM = 811;
        public const int CHEST_UNCOMMOM = 812;
        public const int CHEST_RARE = 813;
        public const int CHEST_EPIC = 814;
        public const int CHEST_LEGENDARY = 815;

        public ChestCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory,
            IDestroyRewardDomainFactory destroyRewardFactory,
            IItemDestroyRewardDomainFactory itemDestroyRewardFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
            _destroyRewardFactory = destroyRewardFactory;
            _itemDestroyRewardFactory = itemDestroyRewardFactory;
        }

        private void AddChestReward(IItemModel md, int qtdy, int goldMin, int goldMax)
        {
            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Qtdy = qtdy;
            md.DestroyReward.GoldMin = goldMin;
            md.DestroyReward.GoldMax = goldMax;
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = ToolCategoryModel.TRASH;
            item.Percent = 90;
            item.QtdeMin = 1;
            item.QtdeMax = 10;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = FarmCategoryModel.CLOTH;
            item.Percent = 60;
            item.QtdeMin = 1;
            item.QtdeMax = 5;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.STONE;
            item.Percent = 70;
            item.QtdeMin = 1;
            item.QtdeMax = 10;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.COAL;
            item.Percent = 60;
            item.QtdeMin = 1;
            item.QtdeMax = 8;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.ORE;
            item.Percent = 60;
            item.QtdeMin = 1;
            item.QtdeMax = 10;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.COPPER_BAR;
            item.Percent = 35;
            item.QtdeMin = 1;
            item.QtdeMax = 3;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.TIN_BAR;
            item.Percent = 35;
            item.QtdeMin = 1;
            item.QtdeMax = 3;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.BRONZE_BAR;
            item.Percent = 30;
            item.QtdeMin = 2;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.IRON_BAR;
            item.Percent = 20;
            item.QtdeMin = 2;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.SILVER_BAR;
            item.Percent = 15;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MiningCategoryModel.GOLD_BAR;
            item.Percent = 10;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = AnimalCategoryModel.BONE;
            item.Percent = 70;
            item.QtdeMin = 1;
            item.QtdeMax = 10;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = AnimalCategoryModel.LEATHER;
            item.Percent = 60;
            item.QtdeMin = 1;
            item.QtdeMax = 4;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = JewelCategoryModel.PEARL;
            item.Percent = 30;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = JewelCategoryModel.DIAMOND;
            item.Percent = 5;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = JewelCategoryModel.JADE;
            item.Percent = 10;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = JewelCategoryModel.RUBI;
            item.Percent = 10;
            item.QtdeMin = 1;
            item.QtdeMax = 1;
            md.DestroyReward.Items.Add(item);
        }

        private IItemModel ChestCommon()
        {
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = CHEST_COMMOM;
            md.Category = "Chests";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/chest.png";
            md.Name = "Common Chest";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            AddChestReward(md, 2, 1, 10);

            return md;
        }

        private IItemModel ChestUncommon()
        {
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = CHEST_UNCOMMOM;
            md.Category = "Chests";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/chest-uncommon.png";
            md.Name = "Uncommon Chest";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            AddChestReward(md, 3, 10, 20);

            return md;
        }

        private IItemModel ChestRare()
        {
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = CHEST_RARE;
            md.Category = "Chests";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/chest-rare.png";
            md.Name = "Rare Chest";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            AddChestReward(md, 4, 20, 40);

            return md;
        }

        private IItemModel ChestEpic()
        {
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = CHEST_EPIC;
            md.Category = "Chests";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/chest-epic.png";
            md.Name = "Epic Chest";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            AddChestReward(md, 5, 40, 60);

            return md;
        }

        private IItemModel ChestLegendary()
        {
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = CHEST_LEGENDARY;
            md.Category = "Chests";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/chest-legendary.png";
            md.Name = "Legendary Chest";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            AddChestReward(md, 5, 60, 100);

            return md;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.Add(ChestCommon());
            i.Add(ChestUncommon());
            i.Add(ChestRare());
            i.Add(ChestEpic());
            i.Add(ChestLegendary());

            return i;
        }
    }
}
