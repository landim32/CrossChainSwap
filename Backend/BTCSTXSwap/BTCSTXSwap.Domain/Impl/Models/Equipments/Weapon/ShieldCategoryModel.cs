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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon
{
    public class ShieldCategoryModel: IItemCategoryModel
    {
        public const int COMMON_WOOD_SHIELD = 16901;
        public const int UNCOMMON_WOOD_SHIELD = 16902;
        public const int RARE_WOOD_SHIELD = 16903;
        public const int EPIC_WOOD_SHIELD = 16904;
        public const int LEGENDARY_WOOD_SHIELD = 16905;

        public const int COMMON_BRONZE_SHIELD = 16911;
        public const int UNCOMMON_BRONZE_SHIELD = 16912;
        public const int RARE_BRONZE_SHIELD = 16913;
        public const int EPIC_BRONZE_SHIELD = 16914;
        public const int LEGENDARY_BRONZE_SHIELD = 16915;

        public const int COMMON_IRON_SHIELD = 16921;
        public const int UNCOMMON_IRON_SHIELD = 16922;
        public const int RARE_IRON_SHIELD = 16923;
        public const int EPIC_IRON_SHIELD = 16924;
        public const int LEGENDARY_IRON_SHIELD = 16925;

        public const int COMMON_STEEL_SHIELD = 16931;
        public const int UNCOMMON_STEEL_SHIELD = 16932;
        public const int RARE_STEEL_SHIELD = 16933;
        public const int EPIC_STEEL_SHIELD = 16934;
        public const int LEGENDARY_STEEL_SHIELD = 16935;

        private const string CATEGORY = "Shields";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public ShieldCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateWoodShield()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_WOOD_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Wood Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/wood-shield.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 1,
                ImageStand = "woodshield",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_WOOD_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Wood Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/wood-shield.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 1,
                ImageStand = "woodshield",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_WOOD_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Wood Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/wood-shield.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 1,
                ImageStand = "woodshield",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_WOOD_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Wood Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/wood-shield.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 1,
                ImageStand = "woodshield",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_WOOD_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Wood Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/wood-shield.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 1,
                ImageStand = "woodshield",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 9
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeShield()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Bronze Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 5,
                ImageStand = "shield",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Bronze Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 5,
                ImageStand = "shield",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Bronze Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 5,
                ImageStand = "shield",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Bronze Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 5,
                ImageStand = "shield",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Bronze Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 5,
                ImageStand = "shield",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 14
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronShield()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Iron Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 4,
                ImageStand = "shield",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Iron Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 4,
                ImageStand = "shield",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Iron Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 4,
                ImageStand = "shield",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Iron Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 4,
                ImageStand = "shield",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Iron Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 4,
                ImageStand = "shield",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 19
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelShield()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Steel Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 3,
                ImageStand = "shield",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Steel Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 3,
                ImageStand = "shield",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Steel Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 3,
                ImageStand = "shield",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Steel Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 3,
                ImageStand = "shield",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_SHIELD;
            md.Category = CATEGORY;
            md.Name = "Steel Shield";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/metal-shield.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Shield,
                Weight = 3,
                ImageStand = "shield",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand },
                IsTwoHanded = false,
                Resistence = 24
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();

            i.AddRange(GenerateWoodShield());
            i.AddRange(GenerateBronzeShield());
            i.AddRange(GenerateIronShield());
            i.AddRange(GenerateSteelShield());

            return i;
        }
    }
}
