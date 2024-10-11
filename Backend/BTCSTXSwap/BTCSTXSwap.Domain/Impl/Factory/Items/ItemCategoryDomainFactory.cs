using BTCSTXSwap.Domain.Impl.Models.Equipments.Armor;
using BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class ItemCategoryDomainFactory: IItemCategoryDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;
        private readonly IDestroyRewardDomainFactory _destroyRewardFactory;
        private readonly IItemDestroyRewardDomainFactory _itemDestroyRewardFactory;

        public ItemCategoryDomainFactory(
            ILogCore log, 
            IItemDomainFactory itemFactory,
            IDestroyRewardDomainFactory destroyRewardFactory,
            IItemDestroyRewardDomainFactory itemDestroyRewardFactory
        )
        {
            _log = log;
            _itemFactory = itemFactory;
            _destroyRewardFactory = destroyRewardFactory;
            _itemDestroyRewardFactory = itemDestroyRewardFactory;
        }

        public IItemCategoryModel BuildItemCategoryModel(ItemCategoryEnum s)
        {
            IItemCategoryModel md = null;
            switch (s)
            {
                case ItemCategoryEnum.Animal:
                    md = new AnimalCategoryModel(_log, _itemFactory, _destroyRewardFactory, _itemDestroyRewardFactory);
                    break;
                case ItemCategoryEnum.Farm:
                    md = new FarmCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Minning:
                    md = new MiningCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Tools:
                    md = new ToolCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Wood:
                    md = new WoodCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Chest:
                    md = new ChestCategoryModel(_log, _itemFactory, _destroyRewardFactory, _itemDestroyRewardFactory);
                    break;
                case ItemCategoryEnum.Body:
                    md = new BodyCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Foot:
                    md = new FootCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Hand:
                    md = new HandCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Helmet:
                    md = new HelmetCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Axe:
                    md = new AxeCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Bow:
                    md = new BowCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Crossbow:
                    md = new CrossbowCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Greataxe:
                    md = new GreataxeCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Greatsword:
                    md = new GreatswordCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Hammer:
                    md = new HammerCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Knife:
                    md = new KnifeCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Mace:
                    md = new MaceCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Shield:
                    md = new ShieldCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Spear:
                    md = new SpearCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Staff:
                    md = new StaffCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Sword:
                    md = new SwordCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Pickaxe:
                    md = new PickaxeCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.ItemBox:
                    md = new ItemBoxCategoryModel(_log, _itemFactory);
                    break;
                case ItemCategoryEnum.Jewel:
                    md = new JewelCategoryModel(_log, _itemFactory);
                    break;
            }
            return md;
        }
    }
}
