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
    public class KnifeCategoryModel : IItemCategoryModel
    {
        public const int COMMON_BRONZE_KNIFE = 16601;
        public const int UNCOMMON_BRONZE_KNIFE = 16602;
        public const int RARE_BRONZE_KNIFE = 16603;
        public const int EPIC_BRONZE_KNIFE = 16604;
        public const int LEGENDARY_BRONZE_KNIFE = 16605;


        public const int COMMON_IRON_KNIFE = 16611;
        public const int UNCOMMON_IRON_KNIFE = 16612;
        public const int RARE_IRON_KNIFE = 16613;
        public const int EPIC_IRON_KNIFE = 16614;
        public const int LEGENDARY_IRON_KNIFE = 16615;

        public const int COMMON_STEEL_KNIFE = 16621;
        public const int UNCOMMON_STEEL_KNIFE = 16622;
        public const int RARE_STEEL_KNIFE = 16623;
        public const int EPIC_STEEL_KNIFE = 16624;
        public const int LEGENDARY_STEEL_KNIFE = 16625;

        private const string CATEGORY = "Knifes";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public KnifeCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateBronzeKnife()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Bronze Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Stealth = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Bronze Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Stealth = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Bronze Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Bronze Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 8,
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Bronze Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 10,
                Stealth = 4
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronKnife()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Iron Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Stealth = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Iron Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Stealth = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Iron Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Stealth = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Iron Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Stealth = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Iron Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 11,
                Stealth = 8
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelKnife()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Steel Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Stealth = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Steel Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 6,
                Stealth = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Steel Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Stealth = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Steel Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 12,
                Stealth = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_KNIFE;
            md.Category = CATEGORY;
            md.Name = "Steel Knife";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/knife.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "knife",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 15,
                Stealth = 9
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeKnife());
            i.AddRange(GenerateIronKnife());
            i.AddRange(GenerateSteelKnife());
            return i;
        }
    }
}
