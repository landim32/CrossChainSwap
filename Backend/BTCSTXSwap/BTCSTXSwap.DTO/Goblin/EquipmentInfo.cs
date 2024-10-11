using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.DTO.Goblin
{
    public class EquipmentInfo
    {
        [JsonIgnore]
        public bool IsSecundary { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonIgnore]
        public string ImageStand { get; set; }
        [JsonIgnore]
        public string ImageMiningStop { get; set; }
        [JsonIgnore]
        public string ImageMiningUp { get; set; }
        [JsonIgnore]
        public string ImageMiningDown { get; set; }
        [JsonIgnore]
        public string ImageMiningRest { get; set; }
        [JsonIgnore]
        public Color Color { get; set; }
        [JsonPropertyName("itemType")]
        public int ItemType { get; set; }
        [JsonPropertyName("part")]
        public IList<BodyPartEnum> Part { get; set; }
        [JsonPropertyName("isTwoHanded")]
        public bool IsTwoHanded { get; set; }
        [JsonPropertyName("binded")]
        public bool Binded { get; set; }

        [JsonPropertyName("mining")]
        public long Mining { get; set; }
        [JsonPropertyName("hunting")]
        public long Hunting { get; set; }
        [JsonPropertyName("resistence")]
        public long Resistence { get; set; }
        [JsonPropertyName("attack")]
        public long Attack { get; set; }
        [JsonPropertyName("social")]
        public long Social { get; set; }
        [JsonPropertyName("tailoring")]
        public long Tailoring { get; set; }
        [JsonPropertyName("blacksmith")]
        public long Blacksmith { get; set; }
        [JsonPropertyName("stealth")]
        public long Stealth { get; set; }
        [JsonPropertyName("magic")]
        public long Magic { get; set; }
    }
}
