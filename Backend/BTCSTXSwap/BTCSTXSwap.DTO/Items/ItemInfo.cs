using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.DTO.Items
{
    public class ItemInfo
    {
        [JsonPropertyName("key")]
        public long Key { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("iconAsset")]
        public string IconAsset { get; set; }
        [JsonPropertyName("isTrash")]
        public bool IsTrash { get; set; }
        [JsonPropertyName("isBag")]
        public bool IsBag { get; set; }
        [JsonPropertyName("price")]
        public int Price { get; set; }
        [JsonPropertyName("isEquipment")]
        public bool IsEquipment { get; set; }
        [JsonPropertyName("equipmentInfo")]
        public EquipmentInfo EquipmentInfo { get; set; }
        [JsonPropertyName("destroyInfo")]
        public DestroyRewardInfo DestroyInfo { get; set; }
    }
}
