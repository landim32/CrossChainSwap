using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinEquipmentInfo
    {
        [JsonPropertyName("head")]
        public ItemInfo Head { get; set; }
        [JsonPropertyName("chest")]
        public ItemInfo Chest { get; set; }
        [JsonPropertyName("hand")]
        public ItemInfo Hand { get; set; }
        [JsonPropertyName("foot")]
        public ItemInfo Foot { get; set; }
        [JsonPropertyName("rightHand")]
        public ItemInfo RightHand { get; set; }
        [JsonPropertyName("leftHand")]
        public ItemInfo LeftHand { get; set; }
        [JsonPropertyName("miningbonus")]
        public long MiningBonus { get; set; }
        [JsonPropertyName("huntingbonus")]
        public long HuntingBonus { get; set; }
        [JsonPropertyName("resistencebonus")]
        public long ResistenceBonus { get; set; }
        [JsonPropertyName("attackbonus")]
        public long AttackBonus { get; set; }
        [JsonPropertyName("socialbonus")]
        public long SocialBonus { get; set; }
        [JsonPropertyName("tailoringbonus")]
        public long TailoringBonus { get; set; }
        [JsonPropertyName("blacksmithbonus")]
        public long BlacksmithBonus { get; set; }
        [JsonPropertyName("steathbonus")]
        public long SteathBonus { get; set; }
        [JsonPropertyName("magicbonus")]
        public long MagicBonus { get; set; }
        [JsonPropertyName("goblinBag")]
        public IList<ItemInfo> GoblinBag { get; set; }
    }
}
