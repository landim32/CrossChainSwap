using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments.Armor
{
    public class HelmetCategoryModel: IItemCategoryModel
    {
        public const int COMMON_CLOTH_HAT = 12301;
        public const int UNCOMMON_CLOTH_HAT = 12302;
        public const int RARE_CLOTH_HAT = 12303;
        public const int EPIC_CLOTH_HAT = 12304;
        public const int LEGENDARY_CLOTH_HAT = 12305;

        public const int COMMON_MAGE_HAT = 12311;
        public const int UNCOMMON_MAGE_HAT = 12312;
        public const int RARE_MAGE_HAT = 12313;
        public const int EPIC_MAGE_HAT = 12314;
        public const int LEGENDARY_MAGE_HAT = 12315;

        public const int COMMON_LEATHER_HOOD = 12321;
        public const int UNCOMMON_LEATHER_HOOD = 12322;
        public const int RARE_LEATHER_HOOD = 12323;
        public const int EPIC_LEATHER_HOOD = 12324;
        public const int LEGENDARY_LEATHER_HOOD = 12325;

        //public const int LEATHER_MASK = 12331;

        public const int COMMON_BRONZE_CAP = 12341;
        public const int UNCOMMON_BRONZE_CAP = 12342;
        public const int RARE_BRONZE_CAP = 12343;
        public const int EPIC_BRONZE_CAP = 12344;
        public const int LEGENDARY_BRONZE_CAP = 12345;

        public const int COMMON_BRONZE_HELMET = 12351;
        public const int UNCOMMON_BRONZE_HELMET = 12352;
        public const int RARE_BRONZE_HELMET = 12353;
        public const int EPIC_BRONZE_HELMET = 12354;
        public const int LEGENDARY_BRONZE_HELMET = 12355;

        public const int COMMON_IRON_CAP = 12361;
        public const int UNCOMMON_IRON_CAP = 12362;
        public const int RARE_IRON_CAP = 12363;
        public const int EPIC_IRON_CAP = 12364;
        public const int LEGENDARY_IRON_CAP = 12365;

        public const int COMMON_IRON_HELMET = 12371;
        public const int UNCOMMON_IRON_HELMET = 12372;
        public const int RARE_IRON_HELMET = 12373;
        public const int EPIC_IRON_HELMET = 12374;
        public const int LEGENDARY_IRON_HELMET = 12375;

        public const int COMMON_STEEL_CAP = 12381;
        public const int UNCOMMON_STEEL_CAP = 12382;
        public const int RARE_STEEL_CAP = 12383;
        public const int EPIC_STEEL_CAP = 12384;
        public const int LEGENDARY_STEEL_CAP = 12385;

        public const int COMMON_STEEL_HELMET = 12391;
        public const int UNCOMMON_STEEL_HELMET = 12392;
        public const int RARE_STEEL_HELMET = 12393;
        public const int EPIC_STEEL_HELMET = 12394;
        public const int LEGENDARY_STEEL_HELMET = 12395;

        //public const int IRON_TIARA = 12401;
        //public const int STEEL_TIARA = 12411;
        //public const int SILVER_TIARA = 12421;
        //public const int GOLD_TIARA = 12431;

        public const int COMMON_MINING = 12441;
        public const int UNCOMMON_MINING = 12451;
        public const int RARE_MINING = 12461;
        public const int EPIC_MINING = 12471;
        public const int LEGENDARY_MINING = 12481;

        private const string HELMET_ARMOR_CATEGORY = "Helmet Armor";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public HelmetCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateClothHat()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_CLOTH_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Cloth Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Social = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_CLOTH_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Unommon Cloth Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Social = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_CLOTH_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Cloth Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Social = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_CLOTH_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Cloth Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Social = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_CLOTH_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Cloth Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Social = 20
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateClothMage()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MAGE_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Mage Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Magic = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MAGE_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Uncommon Mage Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Magic = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MAGE_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Mage Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Magic = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MAGE_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Mage Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Magic = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MAGE_HAT;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Mage Hat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Magic = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateLeatherHood()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_LEATHER_HOOD;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Leather Hood";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 2,
                ImageStand = "head-armor-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_LEATHER_HOOD;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Uncommon Leather Hood";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 2,
                ImageStand = "head-armor-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Stealth = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_LEATHER_HOOD;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Leather Hood";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 2,
                ImageStand = "head-armor-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Stealth = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_LEATHER_HOOD;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Leather Hood";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 2,
                ImageStand = "head-armor-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Stealth = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_LEATHER_HOOD;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Leather Hood";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 2,
                ImageStand = "head-armor-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Stealth = 24
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeCap()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Bronze Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 1,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "UnCommon Bronze Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 4,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Bronze Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 6,
                Resistence = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Bronze Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 8,
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Bronze Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 10,
                Resistence = 14
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeHelmet()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Bronze Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Uncommon Bronze Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Bronze Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Bronze Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Bronze Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 24
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronCap()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Iron Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 2,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Uncommon Iron Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 4,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Iron Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 6,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Iron Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 8,
                Resistence = 17
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Iron Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 10,
                Resistence = 22
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronHelmet()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Common Iron Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Uncommon Iron Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Iron Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Iron Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Iron Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelCap()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 2,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 4,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Rare Steel Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 6,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Epic Steel Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 8,
                Resistence = 17
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_CAP;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Legendary Steel Cap";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Attack = 10,
                Resistence = 22
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelHelmet()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 5

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 11

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 18

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 25

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_HELMET;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Steel Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 3,
                ImageStand = "head-armor-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Resistence = 32

            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateMiningHelmet()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MINING;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Mining Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-head.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-miner",
                Color = RarityColor.Common,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Mining = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MINING;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Mining Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-head.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-miner",
                Color = RarityColor.Uncommon,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Mining = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MINING;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Mining Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-head.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-miner",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Mining = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MINING;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Mining Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-head.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-miner",
                Color = RarityColor.Epic,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Mining = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MINING;
            md.Category = HELMET_ARMOR_CATEGORY;
            md.Name = "Mining Helmet";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-head.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Helmet,
                Weight = 1,
                ImageStand = "head-armor-miner",
                Color = RarityColor.Legendary,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Head },
                Mining = 32
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();

            i.AddRange(GenerateClothHat());
            i.AddRange(GenerateClothMage());
            i.AddRange(GenerateLeatherHood());
            i.AddRange(GenerateBronzeCap());
            i.AddRange(GenerateBronzeHelmet());
            i.AddRange(GenerateIronCap());
            i.AddRange(GenerateIronHelmet());
            i.AddRange(GenerateSteelCap());
            i.AddRange(GenerateSteelHelmet());
            i.AddRange(GenerateMiningHelmet());

            return i;
        }
    }
}
