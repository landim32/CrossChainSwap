using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Items
{
    public class UserItemInfo
    {
        [JsonPropertyName("id")]
        public long IdItem { get; set; }
        [JsonPropertyName("key")]
        public long ItemKey { get; set; }
        [JsonPropertyName("idUser")]
        public long IdUser { get; set; }
        [JsonPropertyName("qtde")]
        public int Qtde { get; set; }
        [JsonPropertyName("posX")]
        public int PosX { get; set; }
        [JsonPropertyName("posY")]
        public int PosY { get; set; }
        [JsonPropertyName("item")]
        public ItemInfo Item { get; set; }
    }
}
