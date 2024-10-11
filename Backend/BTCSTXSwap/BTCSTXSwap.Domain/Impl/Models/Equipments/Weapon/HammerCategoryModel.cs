using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon
{
    public class HammerCategoryModel: IItemCategoryModel
    {
        public const int COMMON_BRONZE_HAMMER = 16501;
        public const int UNCOMMON_BRONZE_HAMMER = 16502;
        public const int RARE_BRONZE_HAMMER = 16503;
        public const int EPIC_BRONZE_HAMMER = 16504;
        public const int LEGENDARY_BRONZE_HAMMER = 16505;

        public const int COMMON_IRON_HAMMER = 16511;
        public const int UNCOMMON_IRON_HAMMER = 16512;
        public const int RARE_IRON_HAMMER = 16513;
        public const int EPIC_IRON_HAMMER = 16514;
        public const int LEGENDARY_IRON_HAMMER = 16515;

        public const int COMMON_STEEL_HAMMER = 16521;
        public const int UNCOMMON_STEEL_HAMMER = 16522;
        public const int RARE_STEEL_HAMMER = 16523;
        public const int EPIC_STEEL_HAMMER = 16524;
        public const int LEGENDARY_STEEL_HAMMER = 16525;

        private const string CATEGORY = "Hammers";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public HammerCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateBronzeHammer()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Bronze Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Bronze Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Bronze Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Bronze Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Bronze Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronHammer()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Iron Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Iron Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Iron Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Iron Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 30
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Iron Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 38
            };
            i.Add(md);

            return i;
        }
        private IList<IItemModel> GenerateSteelHammer()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Steel Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Steel Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Steel Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 28
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Steel Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 38
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_HAMMER;
            md.Category = CATEGORY;
            md.Name = "Steel Hammer";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/hammer.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Hammer,
                Weight = 1,
                ImageStand = "hammer",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Blacksmith = 48
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeHammer());
            i.AddRange(GenerateIronHammer());
            i.AddRange(GenerateSteelHammer());

            return i;
        }
    }
}
