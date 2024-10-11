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
    public class HandCategoryModel : IItemCategoryModel
    {
        public const int COMMON_CLOTH_GLOVES = 15001;
        public const int UNCOMMON_CLOTH_GLOVES = 15002;
        public const int RARE_CLOTH_GLOVES = 15003;
        public const int EPIC_CLOTH_GLOVES = 15004;
        public const int LEGENDARY_CLOTH_GLOVES = 15005;

        public const int COMMON_MAGE_GLOVES = 15011;
        public const int UNCOMMON_MAGE_GLOVES = 15012;
        public const int RARE_MAGE_GLOVES = 15013;
        public const int EPIC_MAGE_GLOVES = 15014;
        public const int LEGENDARY_MAGE_GLOVES = 15015;

        public const int COMMON_LEATHER_GLOVES = 15021;
        public const int UNCOMMON_LEATHER_GLOVES = 15022;
        public const int RARE_LEATHER_GLOVES = 15023;
        public const int EPIC_LEATHER_GLOVES = 15024;
        public const int LEGENDARY_LEATHER_GLOVES = 15025;

        public const int COMMON_BRONZE_GLOVES = 15031;
        public const int UNCOMMON_BRONZE_GLOVES = 15032;
        public const int RARE_BRONZE_GLOVES = 15033;
        public const int EPIC_BRONZE_GLOVES = 15034;
        public const int LEGENDARY_BRONZE_GLOVES = 15035;

        public const int COMMON_BRONZE_GAUNTLETS = 15041;
        public const int UNCOMMON_BRONZE_GAUNTLETS = 15042;
        public const int RARE_BRONZE_GAUNTLETS = 15043;
        public const int EPIC_BRONZE_GAUNTLETS = 15044;
        public const int LEGENDARY_BRONZE_GAUNTLETS = 15045;

        public const int COMMON_IRON_GLOVES = 15051;
        public const int UNCOMMON_IRON_GLOVES = 15052;
        public const int RARE_IRON_GLOVES = 15053;
        public const int EPIC_IRON_GLOVES = 15054;
        public const int LEGENDARY_IRON_GLOVES = 15055;

        public const int COMMON_IRON_GAUNTLETS = 15061;
        public const int UNCOMMON_IRON_GAUNTLETS = 15062;
        public const int RARE_IRON_GAUNTLETS = 15063;
        public const int EPIC_IRON_GAUNTLETS = 15064;
        public const int LEGENDARY_IRON_GAUNTLETS = 15065;

        public const int COMMON_STEEL_GLOVES = 15071;
        public const int UNCOMMON_STEEL_GLOVES = 15072;
        public const int RARE_STEEL_GLOVES = 15073;
        public const int EPIC_STEEL_GLOVES = 15074;
        public const int LEGENDARY_STEEL_GLOVES = 15075;

        public const int COMMON_STEEL_GAUNTLETS = 15081;
        public const int UNCOMMON_STEEL_GAUNTLETS = 15082;
        public const int RARE_STEEL_GAUNTLETS = 15083;
        public const int EPIC_STEEL_GAUNTLETS = 15084;
        public const int LEGENDARY_STEEL_GAUNTLETS = 15085;

        public const int COMMON_MINING = 15091;
        public const int UNCOMMON_MINING = 15092;
        public const int RARE_MINING = 15093;
        public const int EPIC_MINING = 15094;
        public const int LEGENDARY_MINING = 15095;

        private const string GLOVES_CATEGORY = "Gloves";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public HandCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateClothGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_CLOTH_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Cloth Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-cloth",
                ImageMiningStop = "mining-stop-hand-cloth",
                ImageMiningUp = "mining-up-hand-cloth",
                ImageMiningDown = "mining-down-hand-cloth",
                ImageMiningRest = "mining-rest-hand-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Social = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_CLOTH_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Cloth Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-cloth",
                ImageMiningStop = "mining-stop-hand-cloth",
                ImageMiningUp = "mining-up-hand-cloth",
                ImageMiningDown = "mining-down-hand-cloth",
                ImageMiningRest = "mining-rest-hand-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Social = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_CLOTH_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Cloth Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-cloth",
                ImageMiningStop = "mining-stop-hand-cloth",
                ImageMiningUp = "mining-up-hand-cloth",
                ImageMiningDown = "mining-down-hand-cloth",
                ImageMiningRest = "mining-rest-hand-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Social = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_CLOTH_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Cloth Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-cloth",
                ImageMiningStop = "mining-stop-hand-cloth",
                ImageMiningUp = "mining-up-hand-cloth",
                ImageMiningDown = "mining-down-hand-cloth",
                ImageMiningRest = "mining-rest-hand-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Social = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_CLOTH_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Cloth Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-cloth",
                ImageMiningStop = "mining-stop-hand-cloth",
                ImageMiningUp = "mining-up-hand-cloth",
                ImageMiningDown = "mining-down-hand-cloth",
                ImageMiningRest = "mining-rest-hand-cloth",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Social = 20
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateMageGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MAGE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Mage Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-mage",
                ImageMiningStop = "mining-stop-hand-mage",
                ImageMiningUp = "mining-up-hand-mage",
                ImageMiningDown = "mining-down-hand-mage",
                ImageMiningRest = "mining-rest-hand-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Magic = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MAGE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Mage Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-mage",
                ImageMiningStop = "mining-stop-hand-mage",
                ImageMiningUp = "mining-up-hand-mage",
                ImageMiningDown = "mining-down-hand-mage",
                ImageMiningRest = "mining-rest-hand-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Magic = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MAGE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Mage Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-mage",
                ImageMiningStop = "mining-stop-hand-mage",
                ImageMiningUp = "mining-up-hand-mage",
                ImageMiningDown = "mining-down-hand-mage",
                ImageMiningRest = "mining-rest-hand-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Magic = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MAGE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Mage Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-mage",
                ImageMiningStop = "mining-stop-hand-mage",
                ImageMiningUp = "mining-up-hand-mage",
                ImageMiningDown = "mining-down-hand-mage",
                ImageMiningRest = "mining-rest-hand-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Magic = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MAGE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Mage Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-mage",
                ImageMiningStop = "mining-stop-hand-mage",
                ImageMiningUp = "mining-up-hand-mage",
                ImageMiningDown = "mining-down-hand-mage",
                ImageMiningRest = "mining-rest-hand-mage",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Magic = 28
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateLeatherGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_LEATHER_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Leather Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-leather",
                ImageMiningStop = "mining-stop-hand-leather",
                ImageMiningUp = "mining-up-hand-leather",
                ImageMiningDown = "mining-down-hand-leather",
                ImageMiningRest = "mining-rest-hand-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Stealth = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_LEATHER_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Leather Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-leather",
                ImageMiningStop = "mining-stop-hand-leather",
                ImageMiningUp = "mining-up-hand-leather",
                ImageMiningDown = "mining-down-hand-leather",
                ImageMiningRest = "mining-rest-hand-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Stealth = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_LEATHER_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Leather Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-leather",
                ImageMiningStop = "mining-stop-hand-leather",
                ImageMiningUp = "mining-up-hand-leather",
                ImageMiningDown = "mining-down-hand-leather",
                ImageMiningRest = "mining-rest-hand-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Stealth = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_LEATHER_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Leather Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-leather",
                ImageMiningStop = "mining-stop-hand-leather",
                ImageMiningUp = "mining-up-hand-leather",
                ImageMiningDown = "mining-down-hand-leather",
                ImageMiningRest = "mining-rest-hand-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Stealth = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_LEATHER_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Leather Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-leather",
                ImageMiningStop = "mining-stop-hand-leather",
                ImageMiningUp = "mining-up-hand-leather",
                ImageMiningDown = "mining-down-hand-leather",
                ImageMiningRest = "mining-rest-hand-leather",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Stealth = 24
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateBronzeGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 1,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 4,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 6,
                Resistence = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 8,
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 10,
                Resistence = 14
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateBronzeGauntlets()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gauntlets";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gauntlets";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gauntlets";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gauntlets";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Bronze Gauntlets";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 24
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 2,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 4,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 6,
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 8,
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 10,
                Resistence = 18
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronGauntlets()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Iron Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 28
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelGloves()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 2,
                Resistence = 3

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 4,
                Resistence = 7

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 6,
                Resistence = 12

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 8,
                Resistence = 17

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_GLOVES;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-chain",
                ImageMiningStop = "mining-stop-hand-chain",
                ImageMiningUp = "mining-up-hand-chain",
                ImageMiningDown = "mining-down-hand-chain",
                ImageMiningRest = "mining-rest-hand-chain",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Attack = 10,
                Resistence = 22

            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelGauntlets()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 5

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 11

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 18

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 25

            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_GAUNTLETS;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Steel Gloves";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-plate",
                ImageMiningStop = "mining-stop-hand-plate",
                ImageMiningUp = "mining-up-hand-plate",
                ImageMiningDown = "mining-down-hand-plate",
                ImageMiningRest = "mining-rest-hand-plate",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Resistence = 32

            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateMining()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MINING;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Common Mining Hands";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-hand.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-miner",
                ImageMiningStop = "mining-stop-hand-miner",
                ImageMiningUp = "mining-up-hand-miner",
                ImageMiningDown = "mining-down-hand-miner",
                ImageMiningRest = "mining-rest-hand-miner",
                Color = RarityColor.Common,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Mining = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MINING;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Uncommon Mining Hands";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-hand.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-miner",
                ImageMiningStop = "mining-stop-hand-miner",
                ImageMiningUp = "mining-up-hand-miner",
                ImageMiningDown = "mining-down-hand-miner",
                ImageMiningRest = "mining-rest-hand-miner",
                Color = RarityColor.Uncommon,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Mining = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MINING;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Rare Mining Hands";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-hand.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-miner",
                ImageMiningStop = "mining-stop-hand-miner",
                ImageMiningUp = "mining-up-hand-miner",
                ImageMiningDown = "mining-down-hand-miner",
                ImageMiningRest = "mining-rest-hand-miner",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Mining = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MINING;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Epic Mining Hands";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-hand.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-miner",
                ImageMiningStop = "mining-stop-hand-miner",
                ImageMiningUp = "mining-up-hand-miner",
                ImageMiningDown = "mining-down-hand-miner",
                ImageMiningRest = "mining-rest-hand-miner",
                Color = RarityColor.Epic,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Mining = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MINING;
            md.Category = GLOVES_CATEGORY;
            md.Name = "Legendary Mining Hands";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-hand.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.HandArmor,
                Weight = 1,
                ImageStand = "stand-hand-miner",
                ImageMiningStop = "mining-stop-hand-miner",
                ImageMiningUp = "mining-up-hand-miner",
                ImageMiningDown = "mining-down-hand-miner",
                ImageMiningRest = "mining-rest-hand-miner",
                Color = RarityColor.Legendary,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Gloves },
                Mining = 32
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateClothGloves());
            i.AddRange(GenerateMageGloves());
            i.AddRange(GenerateLeatherGloves());
            i.AddRange(GenerateBronzeGloves());
            i.AddRange(GenerateBronzeGauntlets());
            i.AddRange(GenerateIronGloves());
            i.AddRange(GenerateIronGauntlets());
            i.AddRange(GenerateSteelGloves());
            i.AddRange(GenerateSteelGauntlets());
            i.AddRange(GenerateMining());
            return i;
        }
    }
}
