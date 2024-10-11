using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class ItemService : IItemService
    {
        private readonly IUserItemDomainFactory _userItemDomainFactory;
        private readonly IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> _equipmentRepository;


        public ItemService(IUserItemDomainFactory userItemDomainFactory, IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> equipmentRepository)
        {
            _userItemDomainFactory = userItemDomainFactory;
            _equipmentRepository = equipmentRepository;
        }

        public ItemInfo GetItemByKey(long key)
        {
            var usrMd = _userItemDomainFactory.BuildUserItemModel();
            usrMd.ItemKey = key;
            var itemMd = usrMd.GetItem();
            
            return new ItemInfo
            {
                Category = itemMd.Category,
                IconAsset = itemMd.IconAsset,
                IsBag = itemMd.IsBag,
                IsTrash = itemMd.IsTrash,
                Key = itemMd.Key,
                Name = itemMd.Name,
                Price = itemMd.Price,
                Rarity = (int)itemMd.Rarity,
                IsEquipment = itemMd.IsEquipment,
                EquipmentInfo = itemMd.EquipmentInfo != null ? new EquipmentInfo
                {
                    ImageStand = itemMd.EquipmentInfo.ImageStand,
                    ImageMiningDown = itemMd.EquipmentInfo.ImageMiningDown,
                    ImageMiningRest = itemMd.EquipmentInfo.ImageMiningRest,
                    ImageMiningStop = itemMd.EquipmentInfo.ImageMiningStop,
                    ImageMiningUp = itemMd.EquipmentInfo.ImageMiningUp,
                    Weight = itemMd.EquipmentInfo.Weight,
                    Color = itemMd.EquipmentInfo.Color,
                    ItemType = (int) itemMd.EquipmentInfo.ItemType,
                    Part = itemMd.EquipmentInfo.Part,
                    IsTwoHanded = itemMd.EquipmentInfo.IsTwoHanded,
                    Binded = itemMd.EquipmentInfo.Binded,
                    //Mining = _equipmentRepository.GetMiningPowerBonus(itemMd.Key).GetValueOrDefault()
                    Mining = itemMd.EquipmentInfo.Mining,
                    Hunting = itemMd.EquipmentInfo.Hunting,
                    Resistence = itemMd.EquipmentInfo.Resistence,
                    Attack = itemMd.EquipmentInfo.Attack,
                    Social = itemMd.EquipmentInfo.Social,
                    Tailoring = itemMd.EquipmentInfo.Tailoring,
                    Blacksmith = itemMd.EquipmentInfo.Blacksmith,
                    Stealth = itemMd.EquipmentInfo.Stealth,
                    Magic = itemMd.EquipmentInfo.Magic
                } : null,
                DestroyInfo = (itemMd.IsBag && itemMd.DestroyReward != null) ? new DestroyRewardInfo
                {
                    GoldMax = itemMd.DestroyReward.GoldMax,
                    GoldMin = itemMd.DestroyReward.GoldMin,
                    GrantedQtdy = itemMd.DestroyReward.Items.Where(x => x.Percent == 100)?.Count() ?? 0,
                    RandomQtdy = itemMd.DestroyReward.Qtdy - (itemMd.DestroyReward.Items.Where(x => x.Percent == 100)?.Count() ?? 0),
                    GrantedReward =
                        itemMd.DestroyReward.Items.Where(x => x.Percent == 100)?
                            .Select(x => new ItemDestroyRewardInfo
                            {
                                Item = GetItemByKey((int)x.ItemKey),
                                Percent = x.Percent,
                                QtdeMax = x.QtdeMax,
                                QtdeMin = x.QtdeMin
                            }) ?? null,
                    RandomReward =
                        itemMd.DestroyReward.Items.Where(x => x.Percent < 100)?
                            .Select(x => new ItemDestroyRewardInfo
                            {
                                Item = GetItemByKey((int)x.ItemKey),
                                Percent = x.Percent,
                                QtdeMax = x.QtdeMax,
                                QtdeMin = x.QtdeMin
                            }) ?? null
                } : null
            };
        }

        public IItemModel GetItemModelByKey(long key)
        {
            var usrMd = _userItemDomainFactory.BuildUserItemModel();
            usrMd.ItemKey = key;
            return usrMd.GetItem();
            
        }

        public IEnumerable<ItemInfo> GetItemChest(long key)
        {
            var commonKey = ChestCategoryModel.CHEST_COMMOM;
            var uncommonKey = ChestCategoryModel.CHEST_UNCOMMOM;
            var rareKey = ChestCategoryModel.CHEST_RARE;
            var epicKey = ChestCategoryModel.CHEST_EPIC;
            var legendaryKey = ChestCategoryModel.CHEST_LEGENDARY;
            var ret = new List<ItemInfo>();

            if (ContainsInChest(commonKey, (int)key))
                ret.Add(GetItemByKey(commonKey));
            if (ContainsInChest(uncommonKey, (int)key))
                ret.Add(GetItemByKey(uncommonKey));
            if (ContainsInChest(rareKey, (int)key))
                ret.Add(GetItemByKey(rareKey));
            if (ContainsInChest(epicKey, (int)key))
                ret.Add(GetItemByKey(commonKey));
            if (ContainsInChest(legendaryKey, (int)key))
                ret.Add(GetItemByKey(legendaryKey));

            return ret;
        }

        private bool ContainsInChest(int chestKey, int key)
        {
            var md = _userItemDomainFactory.BuildUserItemModel();
            md.ItemKey = chestKey;
            var mdItem = md.GetItem();

            if (mdItem.DestroyReward.Items.Where(x => x.ItemKey == key).Any())
                return true;
            return false;
        }
    }
}
