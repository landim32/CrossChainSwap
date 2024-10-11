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
    public class AxeCategoryModel: IItemCategoryModel
    {
        public const int COMMON_BRONZE_AXE = 16001;
        public const int UNCOMMON_BRONZE_AXE = 16002;
        public const int RARE_BRONZE_AXE = 16003;
        public const int EPIC_BRONZE_AXE = 16004;
        public const int LEGENDARY_BRONZE_AXE = 16005;

        public const int COMMON_IRON_AXE = 16011;
        public const int UNCOMMON_IRON_AXE = 16012;
        public const int RARE_IRON_AXE = 16013;
        public const int EPIC_IRON_AXE = 16014;
        public const int LEGENDARY_IRON_AXE = 16015;

        public const int COMMON_STEEL_AXE = 16021;
        public const int UNCOMMON_STEEL_AXE = 16022;
        public const int RARE_STEEL_AXE = 16023;
        public const int EPIC_STEEL_AXE = 16024;
        public const int LEGENDARY_STEEL_AXE = 16025;

        private const string CATEGORY = "Axes";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public AxeCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateBronzeAxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_AXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_AXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_AXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_AXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_AXE;
            md.Category = CATEGORY;
            md.Name = "Bronze Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 14
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateIronAxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_AXE;
            md.Category = CATEGORY;
            md.Name = "Iron Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_AXE;
            md.Category = CATEGORY;
            md.Name = "Iron Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_AXE;
            md.Category = CATEGORY;
            md.Name = "Iron Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 11
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_AXE;
            md.Category = CATEGORY;
            md.Name = "Iron Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 15
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_AXE;
            md.Category = CATEGORY;
            md.Name = "Iron Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 19
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> GenerateSteelAxe()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_AXE;
            md.Category = CATEGORY;
            md.Name = "Steel Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_AXE;
            md.Category = CATEGORY;
            md.Name = "Steel Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 9
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_AXE;
            md.Category = CATEGORY;
            md.Name = "Steel Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_AXE;
            md.Category = CATEGORY;
            md.Name = "Steel Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 19
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_AXE;
            md.Category = CATEGORY;
            md.Name = "Steel Axe";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/axe.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Axe,
                Weight = 1,
                ImageStand = "axe",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.LHand, BodyPartEnum.RHand },
                IsTwoHanded = false,
                Attack = 24
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;


            i.AddRange(GenerateBronzeAxe());
            i.AddRange(GenerateIronAxe());
            i.AddRange(GenerateSteelAxe());

            return i;
        }
    }
}
