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
    public class BodyCategoryModel : IItemCategoryModel
    {
        public const int COMMON_SHIRT = 13001;
        public const int UNCOMMON_SHIRT = 13002;
        public const int RARE_SHIRT = 13003;
        public const int EPIC_SHIRT = 13004;
        public const int LEGENDARY_SHIRT = 13005;

        public const int COMMON_MAGE_DRESS = 13011;
        public const int UNCOMMON_MAGE_DRESS = 13012;
        public const int RARE_MAGE_DRESS = 13013;
        public const int EPIC_MAGE_DRESS = 13014;
        public const int LEGENDARY_MAGE_DRESS = 13015;

        public const int COMMON_LEATHER_JACKET = 13021;
        public const int UNCOMMON_LEATHER_JACKET = 13022;
        public const int RARE_LEATHER_JACKET = 13023;
        public const int EPIC_LEATHER_JACKET = 13024;
        public const int LEGENDARY_LEATHER_JACKET = 13025;

        public const int COMMON_BRONZE_CHAINMAIL = 13031;
        public const int UNCOMMON_BRONZE_CHAINMAIL = 13032;
        public const int RARE_BRONZE_CHAINMAIL = 13033;
        public const int EPIC_BRONZE_CHAINMAIL = 13034;
        public const int LEGENDARY_BRONZE_CHAINMAIL = 13035;

        public const int COMMON_BRONZE_BREASTPLATE = 13041;
        public const int UNCOMMON_BRONZE_BREASTPLATE = 13042;
        public const int RARE_BRONZE_BREASTPLATE = 13043;
        public const int EPIC_BRONZE_BREASTPLATE = 13044;
        public const int LEGENDARY_BRONZE_BREASTPLATE = 13045;

        public const int COMMON_IRON_CHAINMAIL = 13051;
        public const int UNCOMMON_IRON_CHAINMAIL = 13052;
        public const int RARE_IRON_CHAINMAIL = 13053;
        public const int EPIC_IRON_CHAINMAIL = 13054;
        public const int LEGENDARY_IRON_CHAINMAIL = 13055;

        public const int COMMON_IRON_BREASTPLATE = 13061;
        public const int UNCOMMON_IRON_BREASTPLATE = 13062;
        public const int RARE_IRON_BREASTPLATE = 13063;
        public const int EPIC_IRON_BREASTPLATE = 13064;
        public const int LEGENDARY_IRON_BREASTPLATE = 13065;

        public const int COMMON_STEEL_CHAINMAIL = 13071;
        public const int UNCOMMON_STEEL_CHAINMAIL = 13072;
        public const int RARE_STEEL_CHAINMAIL = 13073;
        public const int EPIC_STEEL_CHAINMAIL = 13074;
        public const int LEGENDARY_STEEL_CHAINMAIL = 13075;

        public const int COMMON_STEEL_BREASTPLATE = 13081;
        public const int UNCOMMON_STEEL_BREASTPLATE = 13082;
        public const int RARE_STEEL_BREASTPLATE = 13083;
        public const int EPIC_STEEL_BREASTPLATE = 13084;
        public const int LEGENDARY_STEEL_BREASTPLATE = 13085;

        public const int COMMON_MINING = 13091;
        public const int UNCOMMON_MINING = 13092;
        public const int RARE_MINING = 13093;
        public const int EPIC_MINING = 13094;
        public const int LEGENDARY_MINING = 13095;

        private const string BODYARMOR_CATEGORY = "Body Armor";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public BodyCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateShirt()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_SHIRT;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Shirt";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-cloth-{0}",
                ImageMiningStop = "mining-stop-chest-cloth-{0}",
                ImageMiningUp = "mining-up-chest-cloth-{0}",
                ImageMiningDown = "mining-down-chest-cloth-{0}",
                ImageMiningRest = "mining-rest-chest-cloth-{0}",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Social = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_SHIRT;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Shirt";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-cloth-{0}",
                ImageMiningStop = "mining-stop-chest-cloth-{0}",
                ImageMiningUp = "mining-up-chest-cloth-{0}",
                ImageMiningDown = "mining-down-chest-cloth-{0}",
                ImageMiningRest = "mining-rest-chest-cloth-{0}",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Social = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_SHIRT;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Shirt";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-cloth-{0}",
                ImageMiningStop = "mining-stop-chest-cloth-{0}",
                ImageMiningUp = "mining-up-chest-cloth-{0}",
                ImageMiningDown = "mining-down-chest-cloth-{0}",
                ImageMiningRest = "mining-rest-chest-cloth-{0}",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Social = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_SHIRT;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Shirt";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-cloth-{0}",
                ImageMiningStop = "mining-stop-chest-cloth-{0}",
                ImageMiningUp = "mining-up-chest-cloth-{0}",
                ImageMiningDown = "mining-down-chest-cloth-{0}",
                ImageMiningRest = "mining-rest-chest-cloth-{0}",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_SHIRT;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Shirt";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/cloth-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-cloth-{0}",
                ImageMiningStop = "mining-stop-chest-cloth-{0}",
                ImageMiningUp = "mining-up-chest-cloth-{0}",
                ImageMiningDown = "mining-down-chest-cloth-{0}",
                ImageMiningRest = "mining-rest-chest-cloth-{0}",
                Color = MaterialColor.CLOTH,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Social = 20
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateMageDress()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_MAGE_DRESS;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mage Dress";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-mage-{0}",
                ImageMiningStop = "mining-stop-chest-mage-{0}",
                ImageMiningUp = "mining-up-chest-mage-{0}",
                ImageMiningDown = "mining-down-chest-mage-{0}",
                ImageMiningRest = "mining-rest-chest-mage-{0}",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Magic = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MAGE_DRESS;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mage Dress";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-mage-{0}",
                ImageMiningStop = "mining-stop-chest-mage-{0}",
                ImageMiningUp = "mining-up-chest-mage-{0}",
                ImageMiningDown = "mining-down-chest-mage-{0}",
                ImageMiningRest = "mining-rest-chest-mage-{0}",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Magic = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MAGE_DRESS;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mage Dress";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-mage-{0}",
                ImageMiningStop = "mining-stop-chest-mage-{0}",
                ImageMiningUp = "mining-up-chest-mage-{0}",
                ImageMiningDown = "mining-down-chest-mage-{0}",
                ImageMiningRest = "mining-rest-chest-mage-{0}",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Magic = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MAGE_DRESS;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mage Dress";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-mage-{0}",
                ImageMiningStop = "mining-stop-chest-mage-{0}",
                ImageMiningUp = "mining-up-chest-mage-{0}",
                ImageMiningDown = "mining-down-chest-mage-{0}",
                ImageMiningRest = "mining-rest-chest-mage-{0}",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Magic = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MAGE_DRESS;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mage Dress";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mage-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-mage-{0}",
                ImageMiningStop = "mining-stop-chest-mage-{0}",
                ImageMiningUp = "mining-up-chest-mage-{0}",
                ImageMiningDown = "mining-down-chest-mage-{0}",
                ImageMiningRest = "mining-rest-chest-mage-{0}",
                Color = MaterialColor.MAGE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Magic = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateLeatherJacket()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_LEATHER_JACKET;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Leather Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-leather-{0}",
                ImageMiningStop = "mining-stop-chest-leather-{0}",
                ImageMiningUp = "mining-up-chest-leather-{0}",
                ImageMiningDown = "mining-down-chest-leather-{0}",
                ImageMiningRest = "mining-rest-chest-leather-{0}",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_LEATHER_JACKET;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Leather Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-leather-{0}",
                ImageMiningStop = "mining-stop-chest-leather-{0}",
                ImageMiningUp = "mining-up-chest-leather-{0}",
                ImageMiningDown = "mining-down-chest-leather-{0}",
                ImageMiningRest = "mining-rest-chest-leather-{0}",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_LEATHER_JACKET;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Leather Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-leather-{0}",
                ImageMiningStop = "mining-stop-chest-leather-{0}",
                ImageMiningUp = "mining-up-chest-leather-{0}",
                ImageMiningDown = "mining-down-chest-leather-{0}",
                ImageMiningRest = "mining-rest-chest-leather-{0}",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_LEATHER_JACKET;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Leather Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-leather-{0}",
                ImageMiningStop = "mining-stop-chest-leather-{0}",
                ImageMiningUp = "mining-up-chest-leather-{0}",
                ImageMiningDown = "mining-down-chest-leather-{0}",
                ImageMiningRest = "mining-rest-chest-leather-{0}",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_LEATHER_JACKET;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Leather Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/leather-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-leather-{0}",
                ImageMiningStop = "mining-stop-chest-leather-{0}",
                ImageMiningUp = "mining-up-chest-leather-{0}",
                ImageMiningDown = "mining-down-chest-leather-{0}",
                ImageMiningRest = "mining-rest-chest-leather-{0}",
                Color = MaterialColor.LEATHER,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Stealth = 24
            };
            i.Add(md);
            return i;
        }

        private IList<IItemModel> GenerateBronzeChainmail()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Bronze Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 2,
                Attack = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Bronze Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 5,
                Attack = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Bronze Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 8,
                Attack = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Bronze Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 11,
                Attack = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Bronze Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 14,
                Attack = 10
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeBreastplate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Common Bronze Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Uncommon Bronze Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Rare Bronze Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Epic Bronze Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Legendary Bronze Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 24
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronChainmail()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Common Iron Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 3,
                Attack = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Uncommon Iron Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 6,
                Attack = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Rare Iron Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 10,
                Attack = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Epic Iron Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 14,
                Attack = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Legendary Iron Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 18,
                Attack = 10
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronBreastplate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Common Iron Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Uncommon Iron Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Rare Iron Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Epic Iron Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Legendary Iron Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelChainmail()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Common Steal Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Attack = 2,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Uncommon Steal Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Attack = 4,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Rare Steal Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Attack = 6,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Epic Steal Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Attack = 8,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_CHAINMAIL;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Legendary Steal Chainmail";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/chain-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-chain-{0}",
                ImageMiningStop = "mining-stop-chest-chain-{0}",
                ImageMiningUp = "mining-up-chest-chain-{0}",
                ImageMiningDown = "mining-down-chest-chain-{0}",
                ImageMiningRest = "mining-rest-chest-chain-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Attack = 10,
                Resistence = 22
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelBreastplate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Common Steal Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Uncommon Steal Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Rare Steal Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Epic Steal Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Resistence = 25
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_BREASTPLATE;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Legendary Steal Breastplate";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/plate-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-plate-{0}",
                ImageMiningStop = "mining-stop-chest-plate-{0}",
                ImageMiningUp = "mining-up-chest-plate-{0}",
                ImageMiningDown = "mining-down-chest-plate-{0}",
                ImageMiningRest = "mining-rest-chest-plate-{0}",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
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
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mining Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-chest.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-miner-{0}",
                ImageMiningStop = "mining-stop-chest-miner-{0}",
                ImageMiningUp = "mining-up-chest-miner-{0}",
                ImageMiningDown = "mining-down-chest-miner-{0}",
                ImageMiningRest = "mining-rest-chest-miner-{0}",
                Color = RarityColor.Common,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Mining = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_MINING;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mining Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-chest.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-miner-{0}",
                ImageMiningStop = "mining-stop-chest-miner-{0}",
                ImageMiningUp = "mining-up-chest-miner-{0}",
                ImageMiningDown = "mining-down-chest-miner-{0}",
                ImageMiningRest = "mining-rest-chest-miner-{0}",
                Color = RarityColor.Uncommon,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Mining = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_MINING;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mining Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-chest.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-miner-{0}",
                ImageMiningStop = "mining-stop-chest-miner-{0}",
                ImageMiningUp = "mining-up-chest-miner-{0}",
                ImageMiningDown = "mining-down-chest-miner-{0}",
                ImageMiningRest = "mining-rest-chest-miner-{0}",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Mining = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_MINING;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mining Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-chest.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-miner-{0}",
                ImageMiningStop = "mining-stop-chest-miner-{0}",
                ImageMiningUp = "mining-up-chest-miner-{0}",
                ImageMiningDown = "mining-down-chest-miner-{0}",
                ImageMiningRest = "mining-rest-chest-miner-{0}",
                Color = RarityColor.Epic,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Mining = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_MINING;
            md.Category = BODYARMOR_CATEGORY;
            md.Name = "Mining Jacket";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor/mining-chest.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.BodyArmor,
                Weight = 1,
                ImageStand = "stand-chest-miner-{0}",
                ImageMiningStop = "mining-stop-chest-miner-{0}",
                ImageMiningUp = "mining-up-chest-miner-{0}",
                ImageMiningDown = "mining-down-chest-miner-{0}",
                ImageMiningRest = "mining-rest-chest-miner-{0}",
                Color = RarityColor.Legendary,
                Part = new List<BodyPartEnum>() { BodyPartEnum.Chest },
                Mining = 32
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();

            i.AddRange(GenerateShirt());
            i.AddRange(GenerateMageDress());
            i.AddRange(GenerateLeatherJacket());

            i.AddRange(GenerateBronzeChainmail());
            i.AddRange(GenerateBronzeBreastplate());

            i.AddRange(GenerateIronChainmail());
            i.AddRange(GenerateIronBreastplate());

            i.AddRange(GenerateSteelChainmail());
            i.AddRange(GenerateSteelBreastplate());

            i.AddRange(GenerateMining());

            return i;
        }
    }
}
