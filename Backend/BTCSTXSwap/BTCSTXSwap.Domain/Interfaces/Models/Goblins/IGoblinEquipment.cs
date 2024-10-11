using System;
using System.Collections.Generic;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinEquipment
    {
        IItemModel Head { get; set; }
        IItemModel Chest { get; set; }
        IItemModel Hand { get; set; }
        IItemModel Foot { get; set; }
        IItemModel RightHand { get; set; }
        IItemModel LeftHand { get; set; }
        IList<IItemModel> CanEquip { get; set; }
        long IdGoblin { get; set; }
        long IdUser { get; set; }

        IGoblinEquipment GetGoblinEquipment(long idGoblin, bool simple);
        void EquipPart(long itemKey, BodyPartEnum bodyPart);
        IItemModel BuildItemModel(long itemKey);

    }
}
