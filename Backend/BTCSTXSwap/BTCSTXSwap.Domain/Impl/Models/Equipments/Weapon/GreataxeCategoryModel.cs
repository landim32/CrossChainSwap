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
    public class GreataxeCategoryModel: IItemCategoryModel
    {
        public const int COMMON_BRONZE_GREATAXE = 16301;
        public const int UNCOMMON_BRONZE_GREATAXE = 16302;
        public const int RARE_BRONZE_GREATAXE = 16303;
        public const int EPIC_BRONZE_GREATAXE = 16304;
        public const int LEGENDARY_BRONZE_GREATAXE = 16305;

        public const int COMMON_IRON_GREATAXE = 16311;
        public const int UNCOMMON_IRON_GREATAXE = 16312;
        public const int RARE_IRON_GREATAXE = 16313;
        public const int EPIC_IRON_GREATAXE = 16314;
        public const int LEGENDARY_IRON_GREATAXE = 16315;

        public const int COMMON_STEEL_GREATAXE = 16321;
        public const int UNCOMMON_STEEL_GREATAXE = 16322;
        public const int RARE_STEEL_GREATAXE = 16323;
        public const int EPIC_STEEL_GREATAXE = 16324;
        public const int LEGENDARY_STEEL_GREATAXE = 16325;

        private const string CATEGORY = "Axes";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public GreataxeCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateBronzeGreataxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 16
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 28
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronGreataxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 22
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 30
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Iron Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 38
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelGreataxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 28
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 38
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_GREATAXE;
            md.Category = CATEGORY;
            md.Name = "Steel Greataxe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greataxe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Greataxe,
                Weight = 1,
                ImageStand = "greataxe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 48
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeGreataxe());
            i.AddRange(GenerateIronGreataxe());
            i.AddRange(GenerateSteelGreataxe());

            return i;
        }
    }
}
