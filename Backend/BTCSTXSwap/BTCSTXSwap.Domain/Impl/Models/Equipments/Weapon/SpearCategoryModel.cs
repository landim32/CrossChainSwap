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
    public class SpearCategoryModel: IItemCategoryModel
    {
        public const int COMMON_WOOD_SPEAR = 17001;
        public const int UNCOMMON_WOOD_SPEAR = 17002;
        public const int RARE_WOOD_SPEAR = 17003;
        public const int EPIC_WOOD_SPEAR = 17004;
        public const int LEGENDARY_WOOD_SPEAR = 17005;

        public const int COMMON_BRONZE_SPEAR = 17011;
        public const int UNCOMMON_BRONZE_SPEAR = 17012;
        public const int RARE_BRONZE_SPEAR = 17013;
        public const int EPIC_BRONZE_SPEAR = 17014;
        public const int LEGENDARY_BRONZE_SPEAR = 17015;

        public const int COMMON_IRON_SPEAR = 17021;
        public const int UNCOMMON_IRON_SPEAR = 17022;
        public const int RARE_IRON_SPEAR = 17023;
        public const int EPIC_IRON_SPEAR = 17024;
        public const int LEGENDARY_IRON_SPEAR = 17025;

        public const int COMMON_STEEL_SPEAR = 17031;
        public const int UNCOMMON_STEEL_SPEAR = 17032;
        public const int RARE_STEEL_SPEAR = 17033;
        public const int EPIC_STEEL_SPEAR = 17034;
        public const int LEGENDARY_STEEL_SPEAR = 17035;

        private const string CATEGORY = "Spears";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public SpearCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateWoodSpear()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_WOOD_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Wood Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 0,
                Hunting = 0
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_WOOD_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Wood Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 1,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_WOOD_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Wood Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 1,
                Hunting = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_WOOD_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Wood Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2,
                Hunting = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_WOOD_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Wood Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Resistence = 2,
                Hunting = 3
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeSpear()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Bronze Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 0,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Bronze Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 2,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Bronze Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2,
                Hunting = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Bronze Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 3,
                Hunting =3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Bronze Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Resistence = 3,
                Hunting = 4
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronSpear()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Iron Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 0,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Iron Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2,
                Hunting = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Iron Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 2,
                Hunting = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Iron Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 6,
                Resistence = 3,
                Hunting = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Iron Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 8,
                Resistence = 3,
                Hunting = 8
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelSpear()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Steel Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 0,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Steel Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Resistence = 2,
                Hunting = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Steel Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Resistence = 2,
                Hunting = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Steel Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Resistence = 3,
                Hunting = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_SPEAR;
            md.Category = CATEGORY;
            md.Name = "Steel Spear";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/spear.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Spear,
                Weight = 1,
                ImageStand = "spear",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 12,
                Resistence = 3,
                Hunting = 9
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateWoodSpear());
            i.AddRange(GenerateBronzeSpear());
            i.AddRange(GenerateIronSpear());
            i.AddRange(GenerateSteelSpear());
            return i;
        }
    }
}
