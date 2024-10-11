using System;
using BTCSTXSwap.Domain.Impl.Models.Goblins;

namespace BTCSTXSwap.Domain.Impl.Core
{
    public static class GoblinUtils
    {
        private const int COMMON_MAX = 128;
        private const int UNCOMMON_MAX = 210;
        private const int RARE_MAX = 242;
        private const int EPIC_MAX = 253;
        private const int LEGENDARY_MAX = 255;

        public static int GetRarityFromEnum(RarityEnum rarity)
        {
            int r = 0;
            switch (rarity)
            {
                case RarityEnum.Uncommon:
                    r = COMMON_MAX + 1;
                    break;
                case RarityEnum.Rare:
                    r = UNCOMMON_MAX + 1;
                    break;
                case RarityEnum.Epic:
                    r = RARE_MAX + 1;
                    break;
                case RarityEnum.Legendary:
                    r = EPIC_MAX + 1;
                    break;
                default:
                    r = 0;
                    break;
            }
            return r;
        }

        public static RarityEnum GetGoblinEnumRarity(int rarityValue)
        {
            if (rarityValue > 0 && rarityValue < COMMON_MAX)
            {
                return RarityEnum.Common;
            }
            else if (rarityValue >= COMMON_MAX && rarityValue < UNCOMMON_MAX)
            {
                return RarityEnum.Uncommon;
            }
            else if (rarityValue >= UNCOMMON_MAX && rarityValue < RARE_MAX)
            {
                return RarityEnum.Rare;
            }
            else if (rarityValue >= RARE_MAX && rarityValue < EPIC_MAX)
            {
                return RarityEnum.Epic;
            }
            else if (rarityValue >= EPIC_MAX && rarityValue < LEGENDARY_MAX)
            {
                return RarityEnum.Legendary;
            }
            else
            {
                return RarityEnum.Common;
            }
        }
    }
}
