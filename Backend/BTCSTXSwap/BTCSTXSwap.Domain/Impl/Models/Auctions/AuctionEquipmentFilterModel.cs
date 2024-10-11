using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Auctions
{
    public class AuctionEquipmentFilterModel: IAuctionEquipmentFilterModel
    {
        public ItemRarityEnum Rarity { get; set; }
        public EquipmentTypeEnum EquipmentType { get; set; }
        public IList<long> ItemKeys { get; set; } = new List<long>();
        public int? Page { get; set; }
    }
}
