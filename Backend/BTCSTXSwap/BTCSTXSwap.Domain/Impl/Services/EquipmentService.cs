using BTCSTXSwap.Domain.Impl.Models.Equipments.Armor;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class EquipmentService: IEquipmentService
    {
        private readonly IGoblinEquipmentDomainFactory _goblinEquipmentFactory;
        private readonly IItemService _itemService;
        private readonly ILogCore _log;

        public EquipmentService(IGoblinEquipmentDomainFactory goblinEquipmentFactory, ILogCore log, IItemService itemService)
        {
            _goblinEquipmentFactory = goblinEquipmentFactory;
            _log = log;
            _itemService = itemService;
        }

        public void BuildAvatarEquipment(AvatarInfo avatar, long idGoblin)
        {
            var mdGoblinEquip = _goblinEquipmentFactory.BuildGoblinEquipment();
            mdGoblinEquip.IdGoblin = idGoblin;
            mdGoblinEquip = mdGoblinEquip.GetGoblinEquipment(idGoblin, true);
            if (mdGoblinEquip.Head != null)
                avatar.Head = _itemService.GetItemByKey(mdGoblinEquip.Head.Key).EquipmentInfo;

            if (mdGoblinEquip.Chest != null)
                avatar.Chest = _itemService.GetItemByKey(mdGoblinEquip.Chest.Key).EquipmentInfo;
            else
                avatar.Chest = _itemService.GetItemByKey(BodyCategoryModel.COMMON_SHIRT).EquipmentInfo;

            if (mdGoblinEquip.Hand != null)
                avatar.Hand = _itemService.GetItemByKey(mdGoblinEquip.Hand.Key).EquipmentInfo;

            if (mdGoblinEquip.Foot != null)
                avatar.Foot = _itemService.GetItemByKey(mdGoblinEquip.Foot.Key).EquipmentInfo;
            else
                avatar.Foot = _itemService.GetItemByKey(FootCategoryModel.COMMON_SANDAL).EquipmentInfo;

            if (mdGoblinEquip.RightHand != null)
                avatar.MainHand = _itemService.GetItemByKey(mdGoblinEquip.RightHand.Key).EquipmentInfo;

            if (mdGoblinEquip.LeftHand != null)
            {
                avatar.SecondHand = _itemService.GetItemByKey(mdGoblinEquip.LeftHand.Key).EquipmentInfo;
                avatar.SecondHand.IsSecundary = true;
            }

        }

        public void EquipGoblinPart(long idGoblin, IItemModel equipment, BodyPartEnum part, long idUser)
        {
            var mdGoblinEquip = _goblinEquipmentFactory.BuildGoblinEquipment();
            mdGoblinEquip.IdGoblin = idGoblin;
            mdGoblinEquip.IdUser = idUser;
            mdGoblinEquip.EquipPart(equipment.Key, part);
        }


        public GoblinEquipmentInfo GetEquipmentInfo(long idGoblin)
        {
            var ret = new GoblinEquipmentInfo();
            var mdGoblinEquip = _goblinEquipmentFactory.BuildGoblinEquipment();
            mdGoblinEquip.IdGoblin = idGoblin;
            mdGoblinEquip = mdGoblinEquip.GetGoblinEquipment(idGoblin, false);
            if (mdGoblinEquip.Head != null)
            {
                ret.Head = _itemService.GetItemByKey(mdGoblinEquip.Head.Key);
                SumItemBonus(ret, ret.Head);
            }

            if (mdGoblinEquip.Chest != null)
            {
                ret.Chest = _itemService.GetItemByKey(mdGoblinEquip.Chest.Key);
                SumItemBonus(ret, ret.Chest);
            }

            if (mdGoblinEquip.Hand != null)
            {
                ret.Hand = _itemService.GetItemByKey(mdGoblinEquip.Hand.Key);
                SumItemBonus(ret, ret.Hand);
            }

            if (mdGoblinEquip.Foot != null)
            {
                ret.Foot = _itemService.GetItemByKey(mdGoblinEquip.Foot.Key);
                SumItemBonus(ret, ret.Foot);
            }

            if (mdGoblinEquip.RightHand != null)
            {
                ret.RightHand = _itemService.GetItemByKey(mdGoblinEquip.RightHand.Key);
                SumItemBonus(ret, ret.RightHand);
            }

            if (mdGoblinEquip.LeftHand != null)
            {
                ret.LeftHand = _itemService.GetItemByKey(mdGoblinEquip.LeftHand.Key);
                SumItemBonus(ret, ret.LeftHand);
            }

            ret.GoblinBag = mdGoblinEquip.CanEquip.Select(x => _itemService.GetItemByKey(x.Key)).ToList();

            return ret;
        }

        private void SumItemBonus(GoblinEquipmentInfo geInfo, ItemInfo item)
        {
            geInfo.AttackBonus += item.EquipmentInfo.Attack;
            geInfo.BlacksmithBonus += item.EquipmentInfo.Blacksmith;
            geInfo.HuntingBonus += item.EquipmentInfo.Hunting;
            geInfo.MagicBonus +=  item.EquipmentInfo.Magic;
            geInfo.MiningBonus += item.EquipmentInfo.Mining;
            geInfo.ResistenceBonus += item.EquipmentInfo.Resistence;
            geInfo.SocialBonus += item.EquipmentInfo.Social;
            geInfo.SteathBonus += item.EquipmentInfo.Stealth;
            geInfo.TailoringBonus += item.EquipmentInfo.Tailoring;
        }

        public GoblinEquipmentInfo GetSimpleEquipmentInfo(long idGoblin)
        {
            var ret = new GoblinEquipmentInfo();
            var mdGoblinEquip = _goblinEquipmentFactory.BuildGoblinEquipment();
            mdGoblinEquip.IdGoblin = idGoblin;
            mdGoblinEquip = mdGoblinEquip.GetGoblinEquipment(idGoblin, true);
            if (mdGoblinEquip.Head != null)
            {
                ret.Head = _itemService.GetItemByKey(mdGoblinEquip.Head.Key);
                SumItemBonus(ret, ret.Head);
            }

            if (mdGoblinEquip.Chest != null)
            {
                ret.Chest = _itemService.GetItemByKey(mdGoblinEquip.Chest.Key);
                SumItemBonus(ret, ret.Chest);
            }

            if (mdGoblinEquip.Hand != null)
            {
                ret.Hand = _itemService.GetItemByKey(mdGoblinEquip.Hand.Key);
                SumItemBonus(ret, ret.Hand);
            }
                
            if (mdGoblinEquip.Foot != null)
            {
                ret.Foot = _itemService.GetItemByKey(mdGoblinEquip.Foot.Key);
                SumItemBonus(ret, ret.Foot);
            }

            if (mdGoblinEquip.RightHand != null)
            {
                ret.RightHand = _itemService.GetItemByKey(mdGoblinEquip.RightHand.Key);
                SumItemBonus(ret, ret.RightHand);
            }
                
            if (mdGoblinEquip.LeftHand != null)
            {
                ret.LeftHand = _itemService.GetItemByKey(mdGoblinEquip.LeftHand.Key);
                SumItemBonus(ret, ret.LeftHand);
            }

            ret.GoblinBag = new List<ItemInfo>();

            return ret;
        }
    }
}
