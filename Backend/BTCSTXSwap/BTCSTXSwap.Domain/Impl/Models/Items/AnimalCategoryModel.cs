using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class AnimalCategoryModel : IItemCategoryModel
    {
        public const int MEAT = 501;
        public const int BONE = 502;
        public const int LEATHER = 503;
        public const int DEAD_BOAR = 504;
        public const int DEAD_MOOSE = 505;
        public const int DEAD_BISON = 506;
        public const int DEAD_MAMUTE = 507;
        public const int DEAD_REDGRAGON = 508;
        private const string CATEGORY = "Animals";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;
        private readonly IDestroyRewardDomainFactory _destroyRewardFactory;
        private readonly IItemDestroyRewardDomainFactory _itemDestroyRewardFactory;

        public AnimalCategoryModel(
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

        private IItemModel GenerateDeadBoar()
        {
            var md = _itemFactory.BuildItemModel();
            md.Key = DEAD_BOAR;
            md.Category = CATEGORY;
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/javali-dead.png";
            md.Name = "Dead Boar";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;


            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MEAT;
            item.Percent = 100;
            item.QtdeMin = 1;
            item.QtdeMax = 3;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = LEATHER;
            item.Percent = 100;
            item.QtdeMin = 3;
            item.QtdeMax = 6;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = BONE;
            item.Percent = 100;
            item.QtdeMin = 4;
            item.QtdeMax = 8;
            md.DestroyReward.Items.Add(item);

            return md;
        }

        private IItemModel GenerateDeadMoose() {
            var md = _itemFactory.BuildItemModel();
            md.Key = DEAD_MOOSE;
            md.Category = CATEGORY;
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/moose-dead.png";
            md.Name = "Dead Moose";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MEAT;
            item.Percent = 100;
            item.QtdeMin = 3;
            item.QtdeMax = 8;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = LEATHER;
            item.Percent = 100;
            item.QtdeMin = 6;
            item.QtdeMax = 10;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = BONE;
            item.Percent = 100;
            item.QtdeMin = 8;
            item.QtdeMax = 16;
            md.DestroyReward.Items.Add(item);

            return md;
        }

        private IItemModel GenerateDeadBison()
        {
            var md = _itemFactory.BuildItemModel();
            md.Key = DEAD_BISON;
            md.Category = CATEGORY;
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/bison-dead.png";
            md.Name = "Dead Bison";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MEAT;
            item.Percent = 100;
            item.QtdeMin = 6;
            item.QtdeMax = 12;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = LEATHER;
            item.Percent = 100;
            item.QtdeMin = 8;
            item.QtdeMax = 14;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = BONE;
            item.Percent = 100;
            item.QtdeMin = 14;
            item.QtdeMax = 24;
            md.DestroyReward.Items.Add(item);

            return md;
        }

        private IItemModel GenerateDeadMamute()
        {
            var md = _itemFactory.BuildItemModel();
            md.Key = DEAD_MAMUTE;
            md.Category = CATEGORY;
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/mammoth-dead.png";
            md.Name = "Dead Mamute";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MEAT;
            item.Percent = 100;
            item.QtdeMin = 10;
            item.QtdeMax = 16;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = LEATHER;
            item.Percent = 100;
            item.QtdeMin = 12;
            item.QtdeMax = 18;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = BONE;
            item.Percent = 100;
            item.QtdeMin = 20;
            item.QtdeMax = 30;
            md.DestroyReward.Items.Add(item);

            return md;
        }


        private IItemModel GenerateDeadReadDragon()
        {
            var md = _itemFactory.BuildItemModel();
            md.Key = DEAD_REDGRAGON;
            md.Category = CATEGORY;
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/red-dragon-dead.png";
            md.Name = "Dead Red Dragon";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.IsBag = true;
            md.Price = 0;

            md.DestroyReward = _destroyRewardFactory.BuildDestroyRewardModel();
            md.DestroyReward.Items = new List<IItemDestroyRewardModel>();

            IItemDestroyRewardModel item = null;

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = MEAT;
            item.Percent = 100;
            item.QtdeMin = 15;
            item.QtdeMax = 25;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = LEATHER;
            item.Percent = 100;
            item.QtdeMin = 15;
            item.QtdeMax = 25;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = BONE;
            item.Percent = 100;
            item.QtdeMin = 30;
            item.QtdeMax = 40;
            md.DestroyReward.Items.Add(item);

            item = _itemDestroyRewardFactory.BuildItemDestroyRewardModel();
            item.ItemKey = JewelCategoryModel.RUBI;
            item.Percent = 100;
            item.QtdeMin = 1;
            item.QtdeMax = 3;
            md.DestroyReward.Items.Add(item);

            return md;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = MEAT;
            md.Category = CATEGORY;
            md.Name = "Meat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/meat.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = true;
            md.Price = 3;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = BONE;
            md.Category = CATEGORY;
            md.Name = "Bone";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/bone.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = true;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEATHER;
            md.Category = CATEGORY;
            md.Name = "Leather";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/leather.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 2;
            i.Add(md);

            i.Add(GenerateDeadBoar());
            i.Add(GenerateDeadMoose());
            i.Add(GenerateDeadBison());
            i.Add(GenerateDeadMamute());
            i.Add(GenerateDeadReadDragon());

            return i;
        }
    }
}
