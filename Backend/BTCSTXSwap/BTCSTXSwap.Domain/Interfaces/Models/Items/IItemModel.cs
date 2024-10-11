using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Items
{
    public interface IItemModel
    {
        long Key { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        ItemRarityEnum Rarity { get; set; }
        string IconAsset { get; set; }
        bool IsTrash { get; set; }
        bool IsBag { get; set; }
        int Price { get; set; }
        bool IsEquipment { get; set; }
        IEquipmentModel EquipmentInfo { get; set; }
        IDestroyRewardModel DestroyReward { get; set; }
    }
}
