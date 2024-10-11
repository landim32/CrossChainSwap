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
    public class BowCategoryModel: IItemCategoryModel
    {
        public const int COMMON_WOOD_BOW = 16101;
        public const int UNCOMMON_WOOD_BOW = 16102;
        public const int RARE_WOOD_BOW = 16103;
        public const int EPIC_WOOD_BOW = 16104;
        public const int LEGENDARY_WOOD_BOW = 16105;

        private const string CATEGORY = "Bows";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public BowCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> GenerateBow()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_WOOD_BOW;
            md.Category = CATEGORY;
            md.Name = "Bow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/bow.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Bow,
                Weight = 1,
                ImageStand = "bow",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Hunting = 2
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_WOOD_BOW;
            md.Category = CATEGORY;
            md.Name = "Bow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/bow.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Bow,
                Weight = 1,
                ImageStand = "bow",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Hunting = 6
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_WOOD_BOW;
            md.Category = CATEGORY;
            md.Name = "Bow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/bow.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Bow,
                Weight = 1,
                ImageStand = "bow",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Hunting = 10
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_WOOD_BOW;
            md.Category = CATEGORY;
            md.Name = "Bow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/bow.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Bow,
                Weight = 1,
                ImageStand = "bow",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Hunting = 14
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_WOOD_BOW;
            md.Category = CATEGORY;
            md.Name = "Bow";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/bow.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Bow,
                Weight = 1,
                ImageStand = "bow",
                Color = MaterialColor.WOOD,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Hunting = 18
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateBow());

            return i;
        }
    }
}
