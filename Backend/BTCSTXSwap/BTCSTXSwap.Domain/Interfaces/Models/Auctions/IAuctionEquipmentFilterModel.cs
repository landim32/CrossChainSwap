using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Auctions
{
    public interface IAuctionEquipmentFilterModel
    {
        ItemRarityEnum Rarity { get; set; }
        EquipmentTypeEnum EquipmentType { get; set; }
        IList<long> ItemKeys { get; set; }
        int? Page { get; set; }
    }
}
