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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon
{
    public class SwordCategoryModel: IItemCategoryModel
    {
        public const int COMMON_WOOD_SWORD = 17201;
        public const int UNCOMMON_WOOD_SWORD = 17202;
        public const int RARE_WOOD_SWORD = 17203;
        public const int EPIC_WOOD_SWORD = 17204;
        public const int LEGENDARY_WOOD_SWORD = 17205;

        public const int COMMON_BRONZE_SWORD = 17211;
        public const int UNCOMMON_BRONZE_SWORD = 17212;
        public const int RARE_BRONZE_SWORD = 17213;
        public const int EPIC_BRONZE_SWORD = 17214;
        public const int LEGENDARY_BRONZE_SWORD = 17215;

        public const int COMMON_IRON_SWORD = 17221;
        public const int UNCOMMON_IRON_SWORD = 17222;
        public const int RARE_IRON_SWORD = 17223;
        public const int EPIC_IRON_SWORD = 17224;
        public const int LEGENDARY_IRON_SWORD = 17225;

        public const int COMMON_STEEL_SWORD = 17231;
        public const int UNCOMMON_STEEL_SWORD = 17232;
        public const int RARE_STEEL_SWORD = 17233;
        public const int EPIC_STEEL_SWORD = 17234;
        public const int LEGENDARY_STEEL_SWORD = 17235;

        private const string CATEGORY = "Swords";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public SwordCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateWoodSword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_WOOD_SWORD;
            md.Category = CATEGORY;
            md.Name = "Wood Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 0
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_WOOD_SWORD;
            md.Category = CATEGORY;
            md.Name = "Wood Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_WOOD_SWORD;
            md.Category = CATEGORY;
            md.Name = "Wood Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_WOOD_SWORD;
            md.Category = CATEGORY;
            md.Name = "Wood Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_WOOD_SWORD;
            md.Category = CATEGORY;
            md.Name = "Wood Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 6,
                Resistence = 3
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateBronzeSword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_SWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 1,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_SWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 4,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_SWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_SWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 8,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_SWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 10,
                Resistence = 4
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronSword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_SWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 2,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_SWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 5,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_SWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 7,
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_SWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_SWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 11,
                Resistence = 8
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelSword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_SWORD;
            md.Category = CATEGORY;
            md.Name = "Steal Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 3,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_SWORD;
            md.Category = CATEGORY;
            md.Name = "Steal Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 6,
                Resistence = 3
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_SWORD;
            md.Category = CATEGORY;
            md.Name = "Steal Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 9,
                Resistence = 5
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_SWORD;
            md.Category = CATEGORY;
            md.Name = "Steal Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 12,
                Resistence = 7
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_SWORD;
            md.Category = CATEGORY;
            md.Name = "Steal Sword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/sword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Sword,
                Weight = 1,
                ImageStand = "sword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand, BodyPartEnum.LHand },
                IsTwoHanded = false,
                Attack = 15,
                Resistence = 9
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateWoodSword());
            i.AddRange(GenerateBronzeSword());
            i.AddRange(GenerateIronSword());
            i.AddRange(GenerateSteelSword());
            return i;
        }
    }
}
