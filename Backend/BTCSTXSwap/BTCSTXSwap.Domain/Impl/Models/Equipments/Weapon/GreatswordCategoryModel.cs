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
    public class GreatswordCategoryModel : IItemCategoryModel
    {
        public const int COMMON_BRONZE_GREATSWORD = 16401;
        public const int UNCOMMON_BRONZE_GREATSWORD = 16402;
        public const int RARE_BRONZE_GREATSWORD = 16403;
        public const int EPIC_BRONZE_GREATSWORD = 16404;
        public const int LEGENDARY_BRONZE_GREATSWORD = 16405;

        public const int COMMON_IRON_GREATSWORD = 16411;
        public const int UNCOMMON_IRON_GREATSWORD = 16412;
        public const int RARE_IRON_GREATSWORD = 16413;
        public const int EPIC_IRON_GREATSWORD = 16414;
        public const int LEGENDARY_IRON_GREATSWORD = 16415;

        public const int COMMON_STEEL_GREATSWORD = 16421;
        public const int UNCOMMON_STEEL_GREATSWORD = 16422;
        public const int RARE_STEEL_GREATSWORD = 16423;
        public const int EPIC_STEEL_GREATSWORD = 16424;
        public const int LEGENDARY_STEEL_GREATSWORD = 16425;

        private const string CATEGORY = "Greatsword";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public GreatswordCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateBronzeGreatsword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_BRONZE_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 1,
                Resistence = 1
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_BRONZE_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 4,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_BRONZE_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 6,
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_BRONZE_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 10,
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_BRONZE_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Bronze Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.BRONZE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 12,
                Resistence = 6
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateIronGreatsword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_IRON_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 2,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_IRON_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 8,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_IRON_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 10,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_IRON_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 16,
                Resistence = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_IRON_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Iron Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.IRON,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 20,
                Resistence = 8
            };
            i.Add(md);

            return i;
        }

        private IList<IItemModel> GenerateSteelGreatsword()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_STEEL_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Steel Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 4,
                Resistence = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_STEEL_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Steel Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 10,
                Resistence = 4
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_STEEL_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Steel Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 14,
                Resistence = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_STEEL_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Steel Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 18,
                Resistence = 12
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_STEEL_GREATSWORD;
            md.Category = CATEGORY;
            md.Name = "Steel Greatsword";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/greatsword.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Knife,
                Weight = 1,
                ImageStand = "greatsword",
                Color = MaterialColor.STEEL,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Attack = 22,
                Resistence = 16
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBronzeGreatsword());
            i.AddRange(GenerateIronGreatsword());
            i.AddRange(GenerateSteelGreatsword());

            return i;
        }
    }
}
