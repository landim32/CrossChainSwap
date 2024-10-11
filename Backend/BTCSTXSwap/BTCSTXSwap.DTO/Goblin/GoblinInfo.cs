using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Mining;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GoblinInfo
    {

        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idToken")]
        [Obsolete]
        public long IdToken { get; set; }
        [JsonPropertyName("tokenid")]
        public long tokenId { get; set; }
        [JsonPropertyName("iduser")]
        public long IdUser { get; set; }
        [JsonPropertyName("nameUser")]
        public string NameUser { get; set; }
        [JsonPropertyName("userAddress")]
        public string UserAddress { get; set; }
        [JsonPropertyName("idTokenFather")]
        public long? IdTokenFather { get; set; }
        [JsonPropertyName("idTokenMother")]
        public long? IdTokenMother { get; set; }
        [JsonPropertyName("idTokenSpouse")]
        public long? IdTokenSpouse { get; set; }
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }
        [JsonPropertyName("lastuserchange")]
        public DateTime? LastUserChange { get; set; }
        [JsonPropertyName("cooldownDate")]
        public DateTime? CooldownDate { get; set; }
        [JsonPropertyName("inCooldown")]
        public bool InCooldown { get; set; }
        [JsonPropertyName("level")]
        public double Level { get; set; }
        [JsonPropertyName("xp")]
        public int Xp { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("headImageURL")]
        public string HeadImageURL { get; set; }
        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }
        [JsonPropertyName("busy")]
        public DateTime? Busy { get; set; }
        [JsonPropertyName("genre")]
        public string Genre { get; set; }
        [JsonPropertyName("race")]
        public int Race { get; set; }
        [JsonPropertyName("raceName")]
        public string RaceName { get; set; }
        [JsonPropertyName("hair")]
        public int Hair { get; set; }
        [JsonPropertyName("hairName")]
        public string HairName { get; set; }
        [JsonPropertyName("ear")]
        public int Ear { get; set; }
        [JsonPropertyName("earName")]
        public string EarName { get; set; }
        [JsonPropertyName("eye")]
        public int Eye { get; set; }
        [JsonPropertyName("eyeName")]
        public string EyeName { get; set; }
        [JsonPropertyName("mount")]
        public int Mount { get; set; }
        [JsonPropertyName("mountName")]
        public string MountName { get; set; }
        [JsonPropertyName("skin")]
        public int Skin { get; set; }
        [JsonPropertyName("skinName")]
        public string SkinName { get; set; }
        [JsonPropertyName("haircolor")]
        public string HairColor { get; set; }
        [JsonPropertyName("skincolor")]
        public string SkinColor { get; set; }
        [JsonPropertyName("eyecolor")]
        public string EyeColor { get; set; }
        [JsonPropertyName("strength")]
        public int Strength { get; set; }
        [JsonPropertyName("agility")]
        public int Agility { get; set; }
        [JsonPropertyName("vigor")]
        public int Vigor { get; set; }
        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }
        [JsonPropertyName("charism")]
        public int Charism { get; set; }
        [JsonPropertyName("perception")]
        public int Perception { get; set; }
        [JsonPropertyName("miningpower")]
        public int MiningPower { get; set; }
        [JsonPropertyName("miningpowerbase")]
        public int MiningPowerBase { get; set; }
        [JsonPropertyName("miningpowerbonus")]
        public int MiningPowerBonus { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("rarityenum")]
        public int RarityEnum { get; set; }
        [JsonPropertyName("sonscount")]
        public int SonsCount { get; set; }
        [JsonPropertyName("isavaliable")]
        public bool IsAvaliable { get; set; }
        [JsonPropertyName("hasimagemine")]
        public bool HasImageMine { get; set; }
        [JsonPropertyName("minted")]
        public bool Minted { get; set; }
        [JsonPropertyName("goblinMining")]
        public GoblinEnergyMiningInfo GoblinMining { get; set; }
        [JsonPropertyName("sprite")]
        public string Sprite { get; set; }
        [JsonPropertyName("spritetired")]
        public string SpriteTired { get; set; }
        [JsonPropertyName("perks")]
        public IList<GoblinPerkInfo> Perks { get; set; }
        [JsonPropertyName("goblinEquipment")]
        public GoblinEquipmentInfo GoblinEquipment { get; set; }
        [JsonPropertyName("goblinSkillList")]
        public GoblinSkillInfo GolinSkillList { get; set; }
        [JsonPropertyName("questaffinity")]
        public long QuestAffinity { get; set; }
    }
}
