using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
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
    public class FootCategoryModel : IItemCategoryModel
    {
        public const int COMMON_SANDAL = 14011;
        public const int UNCOMMON_SANDAL = 14012;
        public const int RARE_SANDAL = 14013;
        public const int EPIC_SANDAL = 14014;
        public const int LEGENDARY_SANDAL = 14015;

        public const int COMMON_MAGE_SHOES = 14021;
        public const int UNCOMMON_MAGE_SHOES = 14022;
        public const int RARE_MAGE_SHOES = 14023;
        public const int EPIC_MAGE_SHOES = 14024;
        public const int LEGENDARY_MAGE_SHOES = 14025;

        public const int COMMON_LEATHER_BOOTS = 14031;
        public const int UNCOMMON_LEATHER_BOOTS = 14032;
        public const int RARE_LEATHER_BOOTS = 14033;
        public const int EPIC_LEATHER_BOOTS = 14034;
        public const int LEGENDARY_LEATHER_BOOTS = 14035;

        public const int COMMON_BRONZE_SHOES = 14041;
        public const int UNCOMMON_BRONZE_SHOES = 14042;
        public const int RARE_BRONZE_SHOES = 14043;
        public const int EPIC_BRONZE_SHOES = 14044;
        public const int LEGENDARY_BRONZE_SHOES = 14045;

        public const int COMMON_BRONZE_BOOTS = 14051;
        public const int UNCOMMON_BRONZE_BOOTS = 14052;
        public const int RARE_BRONZE_BOOTS = 14053;
        public const int EPIC_BRONZE_BOOTS = 14054;
        public const int LEGENDARY_BRONZE_BOOTS = 14055;

        public const int COMMON_IRON_SHOES = 14061;
        public const int UNCOMMON_IRON_SHOES = 14062;
        public const int RARE_IRON_SHOES = 14063;
        public const int EPIC_IRON_SHOES = 14064;
        public const int LEGENDARY_IRON_SHOES = 14065;

        public const int COMMON_IRON_BOOTS = 14071;
        public const int UNCOMMON_IRON_BOOTS = 14072;
        public const int RARE_IRON_BOOTS = 14073;
        public const int EPIC_IRON_BOOTS = 14074;
        public const int LEGENDARY_IRON_BOOTS = 14075;

        public const int COMMON_STEEL_SHOES = 14081;
        public const int UNCOMMON_STEEL_SHOES = 14082;
        public const int RARE_STEEL_SHOES = 14083;
        public const int EPIC_STEEL_SHOES = 14084;
        public const int LEGENDARY_STEEL_SHOES = 14085;

        public const int COMMON_STEEL_BOOTS = 14091;
        public const int UNCOMMON_STEEL_BOOTS = 14092;
        public const int RARE_STEEL_BOOTS = 14093;
        public const int EPIC_STEEL_BOOTS = 14094;
        public const int LEGENDARY_STEEL_BOOTS = 14095;

        public const int COMMON_MINING = 12107;
        public const int UNCOMMON_MINING = 12108;
        public const int RARE_MINING = 12109;
        public const int EPIC_MINING = 12110;
        public const int LEGENDARY_MINING = 12111;

        private const string FOOTER_CATEGORY = "Footer";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public FootCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateSandal()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_SANDAL;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Sandal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-cloth",
                ImageMiningStop = "mining-stop-foot-cloth",
                ImageMiningUp = "mining-up-foot-cloth",
                ImageMiningDown = "mining-down-foot-cloth",
                ImageMiningRest = "mining-rest-foot-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_SANDAL;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Sandal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-cloth",
                ImageMiningStop = "mining-stop-foot-cloth",
                ImageMiningUp = "mining-up-foot-cloth",
                ImageMiningDown = "mining-down-foot-cloth",
                ImageMiningRest = "mining-rest-foot-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_SANDAL;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Sandal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-cloth",
                ImageMiningStop = "mining-stop-foot-cloth",
                ImageMiningUp = "mining-up-foot-cloth",
                ImageMiningDown = "mining-down-foot-cloth",
                ImageMiningRest = "mining-rest-foot-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_SANDAL;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Sandal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-cloth",
                ImageMiningStop = "mining-stop-foot-cloth",
                ImageMiningUp = "mining-up-foot-cloth",
                ImageMiningDown = "mining-down-foot-cloth",
                ImageMiningRest = "mining-rest-foot-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_SANDAL;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Sandal";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-cloth",
                ImageMiningStop = "mining-stop-foot-cloth",
                ImageMiningUp = "mining-up-foot-cloth",
                ImageMiningDown = "mining-down-foot-cloth",
                ImageMiningRest = "mining-rest-foot-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 20
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateMageShoes()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MAGE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mage Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-mage",
                ImageMiningStop = "mining-stop-foot-mage",
                ImageMiningUp = "mining-up-foot-mage",
                ImageMiningDown = "mining-down-foot-mage",
                ImageMiningRest = "mining-rest-foot-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Magic = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MAGE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mage Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-mage",
                ImageMiningStop = "mining-stop-foot-mage",
                ImageMiningUp = "mining-up-foot-mage",
                ImageMiningDown = "mining-down-foot-mage",
                ImageMiningRest = "mining-rest-foot-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Magic = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MAGE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mage Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-mage",
                ImageMiningStop = "mining-stop-foot-mage",
                ImageMiningUp = "mining-up-foot-mage",
                ImageMiningDown = "mining-down-foot-mage",
                ImageMiningRest = "mining-rest-foot-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Magic = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MAGE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mage Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-mage",
                ImageMiningStop = "mining-stop-foot-mage",
                ImageMiningUp = "mining-up-foot-mage",
                ImageMiningDown = "mining-down-foot-mage",
                ImageMiningRest = "mining-rest-foot-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Magic = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MAGE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mage Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-mage",
                ImageMiningStop = "mining-stop-foot-mage",
                ImageMiningUp = "mining-up-foot-mage",
                ImageMiningDown = "mining-down-foot-mage",
                ImageMiningRest = "mining-rest-foot-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Magic = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateLeatherBoots()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_LEATHER_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Leather Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-leather",
                ImageMiningStop = "mining-stop-foot-leather",
                ImageMiningUp = "mining-up-foot-leather",
                ImageMiningDown = "mining-down-foot-leather",
                ImageMiningRest = "mining-rest-foot-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_LEATHER_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Leather Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-leather",
                ImageMiningStop = "mining-stop-foot-leather",
                ImageMiningUp = "mining-up-foot-leather",
                ImageMiningDown = "mining-down-foot-leather",
                ImageMiningRest = "mining-rest-foot-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_LEATHER_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Leather Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-leather",
                ImageMiningStop = "mining-stop-foot-leather",
                ImageMiningUp = "mining-up-foot-leather",
                ImageMiningDown = "mining-down-foot-leather",
                ImageMiningRest = "mining-rest-foot-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_LEATHER_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Leather Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-leather",
                ImageMiningStop = "mining-stop-foot-leather",
                ImageMiningUp = "mining-up-foot-leather",
                ImageMiningDown = "mining-down-foot-leather",
                ImageMiningRest = "mining-rest-foot-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_LEATHER_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Leather Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-leather",
                ImageMiningStop = "mining-stop-foot-leather",
                ImageMiningUp = "mining-up-foot-leather",
                ImageMiningDown = "mining-down-foot-leather",
                ImageMiningRest = "mining-rest-foot-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Stealth = 24
            };
            i.Add(md);
            return i;
        }

        private IList<IItemModel> GenerateBronzeShoes()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 1,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 4,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 6,
                Resistence = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 8,
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 10,
                Resistence = 14
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeBoots()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Bronze Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 24
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronShoes()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 2,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 4,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 6,
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 8,
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 10,
                Resistence = 18
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronBoots()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Iron Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelShoes()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 2,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 4,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 6,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 8,
                Resistence = 17
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_SHOES;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Shoes";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-chain",
                ImageMiningStop = "mining-stop-foot-chain",
                ImageMiningUp = "mining-up-foot-chain",
                ImageMiningDown = "mining-down-foot-chain",
                ImageMiningRest = "mining-rest-foot-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Attack = 10,
                Resistence = 22
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelBoots()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 25
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_BOOTS;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Steel Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-foot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-plate",
                ImageMiningStop = "mining-stop-foot-plate",
                ImageMiningUp = "mining-up-foot-plate",
                ImageMiningDown = "mining-down-foot-plate",
                ImageMiningRest = "mining-rest-foot-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Resistence = 32
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateMining()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MINING;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mining Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-boot.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-miner",
                ImageMiningStop = "mining-stop-foot-miner",
                ImageMiningUp = "mining-up-foot-miner",
                ImageMiningDown = "mining-down-foot-miner",
                ImageMiningRest = "mining-rest-foot-miner",
                Color = RarityColor.Common,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Mining = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MINING;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mining Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-boot.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-miner",
                ImageMiningStop = "mining-stop-foot-miner",
                ImageMiningUp = "mining-up-foot-miner",
                ImageMiningDown = "mining-down-foot-miner",
                ImageMiningRest = "mining-rest-foot-miner",
                Color = RarityColor.Uncommon,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Mining = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MINING;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mining Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-boot.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-miner",
                ImageMiningStop = "mining-stop-foot-miner",
                ImageMiningUp = "mining-up-foot-miner",
                ImageMiningDown = "mining-down-foot-miner",
                ImageMiningRest = "mining-rest-foot-miner",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Mining = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MINING;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mining Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-boot.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-miner",
                ImageMiningStop = "mining-stop-foot-miner",
                ImageMiningUp = "mining-up-foot-miner",
                ImageMiningDown = "mining-down-foot-miner",
                ImageMiningRest = "mining-rest-foot-miner",
                Color = RarityColor.Epic,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Mining = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MINING;
            md.Category = FOOTER_CATEGORY;
            md.Name = "Mining Boots";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-boot.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.FootArmor,
                Weight = 1,
                ImageStand = "stand-foot-miner",
                ImageMiningStop = "mining-stop-foot-miner",
                ImageMiningUp = "mining-up-foot-miner",
                ImageMiningDown = "mining-down-foot-miner",
                ImageMiningRest = "mining-rest-foot-miner",
                Color = RarityColor.Legendary,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Foot },
                Mining = 32
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();

            i.AddRange(GenerateSandal());
            i.AddRange(GenerateMageShoes());
            i.AddRange(GenerateLeatherBoots());
            i.AddRange(GenerateBronzeShoes());
            i.AddRange(GenerateBronzeBoots());
            i.AddRange(GenerateIronShoes());
            i.AddRange(GenerateIronBoots());
            i.AddRange(GenerateSteelShoes());
            i.AddRange(GenerateSteelBoots());
            i.AddRange(GenerateMining());

            return i;
        }
    }
}
