using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.DTO.Gobox
{
    public class ItemBoxResult : StatusResult
    {
        [JsonPropertyName("itens")]
        public IList<ItemInfo> Itens { get; set; }
    }
}
