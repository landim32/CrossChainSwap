using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Items
{
    public class UserItemListResult: StatusResult
    {
        [JsonPropertyName("itens")]
        public IEnumerable<UserItemInfo> Itens { get; set; }
    }
}
