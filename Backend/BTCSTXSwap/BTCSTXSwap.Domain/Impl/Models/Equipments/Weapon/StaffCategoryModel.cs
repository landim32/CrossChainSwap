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
    public class StaffCategoryModel: IItemCategoryModel
    {
        public const int COMMON_FIRE_STAFF = 17101;
        public const int UNCOMMON_FIRE_STAFF = 17102;
        public const int RARE_FIRE_STAFF = 17103;
        public const int EPIC_FIRE_STAFF = 17104;
        public const int LEGENDARY_FIRE_STAFF = 17105;

        private const string CATEGORY = "Staffs";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public StaffCategoryModel(
            ILogCore log,
            IItemDomainFactory itemFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        private IList<IItemModel> GenerateFireStaff()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = COMMON_FIRE_STAFF;
            md.Category = CATEGORY;
            md.Name = "Fire Staff";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/staff.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Staff,
                Weight = 1,
                ImageStand = "staff",
                Color = MaterialColor.FIRE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Magic = 8
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = UNCOMMON_FIRE_STAFF;
            md.Category = CATEGORY;
            md.Name = "Fire Staff";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/staff.png";
            md.Rarity = ItemRarityEnum.Uncommon;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Staff,
                Weight = 1,
                ImageStand = "staff",
                Color = MaterialColor.FIRE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Magic = 18
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = RARE_FIRE_STAFF;
            md.Category = CATEGORY;
            md.Name = "Fire Staff";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/staff.png";
            md.Rarity = ItemRarityEnum.Rare;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Staff,
                Weight = 1,
                ImageStand = "staff",
                Color = MaterialColor.FIRE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Magic = 28
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = EPIC_FIRE_STAFF;
            md.Category = CATEGORY;
            md.Name = "Fire Staff";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/staff.png";
            md.Rarity = ItemRarityEnum.Epic;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Staff,
                Weight = 1,
                ImageStand = "staff",
                Color = MaterialColor.FIRE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Magic = 38
            };
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LEGENDARY_FIRE_STAFF;
            md.Category = CATEGORY;
            md.Name = "Fire Staff";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/weapon/staff.png";
            md.Rarity = ItemRarityEnum.Legendary;
            md.IsTrash = false;
            md.Price = 1;
            md.IsEquipment = true;
            md.EquipmentInfo = new EquipmentModel
            {
                ItemType = EquipmentTypeEnum.Staff,
                Weight = 1,
                ImageStand = "staff",
                Color = MaterialColor.FIRE,
                Part = new List<BodyPartEnum>() { BodyPartEnum.RHand },
                IsTwoHanded = true,
                Magic = 48
            };
            i.Add(md);

            return i;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            i.AddRange(GenerateFireStaff());
            return i;
        }
    }
}
