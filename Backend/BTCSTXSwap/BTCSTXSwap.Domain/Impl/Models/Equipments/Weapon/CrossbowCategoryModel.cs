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
    public class CrossbowCategoryModel: IItemCategoryModel
    {
        public const int COMMON_BRONZE_CROSSBOW = 16201;
        public const int UNCOMMON_BRONZE_CROSSBOW = 16202;
        public const int RARE_BRONZE_CROSSBOW = 16203;
        public const int EPIC_BRONZE_CROSSBOW = 16204;
        public const int LEGENDARY_BRONZE_CROSSBOW = 16205;

        public const int COMMON_IRON_CROSSBOW = 16211;
        public const int UNCOMMON_IRON_CROSSBOW = 16212;
        public const int RARE_IRON_CROSSBOW = 16213;
        public const int EPIC_IRON_CROSSBOW = 16214;
        public const int LEGENDARY_IRON_CROSSBOW = 16215;

        public const int COMMON_STEEL_CROSSBOW = 16221;
        public const int UNCOMMON_STEEL_CROSSBOW = 16222;
        public const int RARE_STEEL_CROSSBOW = 16223;
        public const int EPIC_STEEL_CROSSBOW = 16224;
        public const int LEGENDARY_STEEL_CROSSBOW = 16225;

        private const string CATEGORY = "Crossbows";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public CrossbowCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateBronzeCrossbow()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Bronze Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 1,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Bronze Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 4,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Bronze Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 5,
                Hunting = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Bronze Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 8,
                Hunting = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Bronze Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 10,
                Hunting = 4
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronCrossbow()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Iron Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 2,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Iron Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 5,
                Hunting = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Iron Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 7,
                Hunting = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Iron Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 9,
                Hunting = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Iron Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 11,
                Hunting = 8
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelCrossbow()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Steel Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 3,
                Hunting = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Steel Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 6,
                Hunting = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Steel Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 9,
                Hunting = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Steel Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 12,
                Hunting = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_CROSSBOW;
            md.Category = CATEGORY;
            md.Name = "Steel Crossbow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/crossbow.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Crossbow,
                Weight = 1,
                ImageStand = "crossbow",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 15,
                Hunting = 9
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeCrossbow());
            i.AddRange(GenerateIronCrossbow());
            i.AddRange(GenerateSteelCrossbow());

            return i;
        }
    }
}
