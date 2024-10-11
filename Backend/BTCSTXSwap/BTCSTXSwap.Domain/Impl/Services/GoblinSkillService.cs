using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinSkillService : IGoblinSkillService
    {
        public GoblinSkillService()
        {

        }
        private long GetBaseRarityMultiplier(long baseValue, RarityEnum rarity)
        {
            switch (rarity)
            {
                case RarityEnum.Common:
                    return baseValue;
                case RarityEnum.Uncommon:
                    return baseValue * 2;
                case RarityEnum.Rare:
                    return baseValue * 4;
                case RarityEnum.Epic:
                    return baseValue * 8;
                case RarityEnum.Legendary:
                    return baseValue * 16;
                default:
                    return baseValue;
            }
        }

        private void SetMiningPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Strength + mdGoblin.Vigor + mdGoblin.Perception);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Mining = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.MiningBonus,
                Total = baseValue + goblinEquipment.MiningBonus
            };
        }

        private void SetHuntingPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Agility + mdGoblin.Intelligence + mdGoblin.Perception);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Hunting = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.HuntingBonus,
                Total = baseValue + goblinEquipment.HuntingBonus
            };
        }

        private void SetResistencePower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Strength + mdGoblin.Vigor);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Resistence = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.ResistenceBonus,
                Total = baseValue + goblinEquipment.ResistenceBonus
            };
        }

        private void SetAttackPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Strength + mdGoblin.Agility);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Attack = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.AttackBonus,
                Total = baseValue + goblinEquipment.AttackBonus
            };
        }

        private void SetSocialPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Charism + mdGoblin.Intelligence);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Social = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.SocialBonus,
                Total = baseValue + goblinEquipment.SocialBonus
            };
        }

        private void SetTailoringPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Charism + mdGoblin.Agility);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Tailoring = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.TailoringBonus,
                Total = baseValue + goblinEquipment.TailoringBonus
            };
        }

        private void SetBlacksmithPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Charism + mdGoblin.Strength);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Blacksmith = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.BlacksmithBonus,
                Total = baseValue + goblinEquipment.BlacksmithBonus
            };
        }

        private void SetStealthPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Agility + mdGoblin.Charism + mdGoblin.Intelligence);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Stealth = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.SteathBonus,
                Total = baseValue + goblinEquipment.SteathBonus
            };
        }

        private void SetMagicPower(GoblinSkillInfo info, IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            long baseValue = (mdGoblin.Intelligence + mdGoblin.Perception);
            baseValue = GetBaseRarityMultiplier(baseValue, mdGoblin.RarityEnum);
            info.Magic = new SkillDetailInfo
            {
                Base = baseValue,
                Bonus = goblinEquipment.MagicBonus,
                Total = baseValue + goblinEquipment.MagicBonus
            };
        }

        public GoblinSkillInfo GetGoblinSkillList(IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment)
        {
            var ret = new GoblinSkillInfo();
            SetMiningPower(ret, mdGoblin, goblinEquipment);
            SetHuntingPower(ret, mdGoblin, goblinEquipment);
            SetResistencePower(ret, mdGoblin, goblinEquipment);
            SetAttackPower(ret, mdGoblin, goblinEquipment);
            SetSocialPower(ret, mdGoblin, goblinEquipment);
            SetTailoringPower(ret, mdGoblin, goblinEquipment);
            SetBlacksmithPower(ret, mdGoblin, goblinEquipment);
            SetStealthPower(ret, mdGoblin, goblinEquipment);
            SetMagicPower(ret, mdGoblin, goblinEquipment);
            return ret;
        }
    }
}
