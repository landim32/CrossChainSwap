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
    public class MaceCategoryModel: IItemCategoryModel
    {
        public const int COMMON_BRONZE_MACE = 16701;
        public const int UNCOMMON_BRONZE_MACE = 16702;
        public const int RARE_BRONZE_MACE = 16703;
        public const int EPIC_BRONZE_MACE = 16704;
        public const int LEGENDARY_BRONZE_MACE = 16705;

        public const int COMMON_IRON_MACE = 16711;
        public const int UNCOMMON_IRON_MACE = 16712;
        public const int RARE_IRON_MACE = 16713;
        public const int EPIC_IRON_MACE = 16714;
        public const int LEGENDARY_IRON_MACE = 16715;

        public const int COMMON_STEEL_MACE = 16721;
        public const int UNCOMMON_STEEL_MACE = 16722;
        public const int RARE_STEEL_MACE = 16723;
        public const int EPIC_STEEL_MACE = 16724;
        public const int LEGENDARY_STEEL_MACE = 16725;

        private const string CATEGORY = "Maces";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public MaceCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateBronzeMace()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_MACE;
            md.Category = CATEGORY;
            md.Name = "Bronze Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 0,
                Magic = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_MACE;
            md.Category = CATEGORY;
            md.Name = "Bronze Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 2,
                Magic = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_MACE;
            md.Category = CATEGORY;
            md.Name = "Bronze Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2,
                Magic = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_MACE;
            md.Category = CATEGORY;
            md.Name = "Bronze Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 3,
                Magic = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_MACE;
            md.Category = CATEGORY;
            md.Name = "Bronze Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Resistence = 3,
                Magic = 4
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronMace()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_MACE;
            md.Category = CATEGORY;
            md.Name = "Iron Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 0,
                Magic = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_MACE;
            md.Category = CATEGORY;
            md.Name = "Iron Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2,
                Magic = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_MACE;
            md.Category = CATEGORY;
            md.Name = "Iron Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 2,
                Magic = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_MACE;
            md.Category = CATEGORY;
            md.Name = "Iron Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 6,
                Resistence = 3,
                Magic = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_MACE;
            md.Category = CATEGORY;
            md.Name = "Iron Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 8,
                Resistence = 3,
                Magic = 8
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelMace()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_MACE;
            md.Category = CATEGORY;
            md.Name = "Steel Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 0,
                Magic = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_MACE;
            md.Category = CATEGORY;
            md.Name = "Steel Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Resistence = 2,
                Magic = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_MACE;
            md.Category = CATEGORY;
            md.Name = "Steel Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Resistence = 2,
                Magic = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_MACE;
            md.Category = CATEGORY;
            md.Name = "Steel Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Resistence = 2,
                Magic = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_MACE;
            md.Category = CATEGORY;
            md.Name = "Steel Mace";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/mace.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Mace,
                Weight = 1,
                ImageStand = "mace",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Resistence = 3,
                Magic = 7
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeMace());
            i.AddRange(GenerateIronMace());
            i.AddRange(GenerateSteelMace());

            return i;
        }
    }
}
