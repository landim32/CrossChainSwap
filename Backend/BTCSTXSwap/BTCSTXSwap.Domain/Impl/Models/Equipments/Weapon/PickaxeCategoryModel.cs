using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon
{
    public class PickaxeCategoryModel : IItemCategoryModel
    {
        public const int COMMON_BRONZE_PICKAXE = 16801;
        public const int UNCOMMON_BRONZE_PICKAXE = 16802;
        public const int RARE_BRONZE_PICKAXE = 16803;
        public const int EPIC_BRONZE_PICKAXE = 16804;
        public const int LEGENDARY_BRONZE_PICKAXE = 16805;

        public const int COMMON_IRON_PICKAXE = 16811;
        public const int UNCOMMON_IRON_PICKAXE = 16812;
        public const int RARE_IRON_PICKAXE = 16813;
        public const int EPIC_IRON_PICKAXE = 16814;
        public const int LEGENDARY_IRON_PICKAXE = 16815;

        public const int COMMON_STEEL_PICKAXE = 16821;
        public const int UNCOMMON_STEEL_PICKAXE = 16822;
        public const int RARE_STEEL_PICKAXE = 16823;
        public const int EPIC_STEEL_PICKAXE = 16824;
        public const int LEGENDARY_STEEL_PICKAXE = 16825;

        private const string CATEGORY = "Pickaxes";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public PickaxeCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateBronzePickaxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 28
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronPickaxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 30
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 38
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelPickaxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = RarityColor.Rare,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 28
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 38
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Pickaxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/pickaxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Pickaxe,
                Weight = 1,
                ImageStand = "pickaxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Mining = 48
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            
            i.AddRange(GenerateBronzePickaxe());
            i.AddRange(GenerateIronPickaxe());
            i.AddRange(GenerateSteelPickaxe());

            return i;
        }
    }
}
