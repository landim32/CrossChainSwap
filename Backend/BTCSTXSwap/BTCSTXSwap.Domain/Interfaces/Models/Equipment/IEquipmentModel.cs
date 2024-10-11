using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Equipment
{
    public interface IEquipmentModel
    {
        EquipmentTypeEnum ItemType { get; set; }
        double Weight { get; set; }
        string ImageStand { get; set; }
        string ImageMiningStop { get; set; }
        string ImageMiningUp { get; set; }
        string ImageMiningDown { get; set; }
        string ImageMiningRest { get; set; }
        Color Color { get; set; }
        IList<BodyPartEnum> Part { get; set; }
        bool IsTwoHanded { get; set; }
        bool Binded { get; set; }
        long Mining { get; set; }
        long Hunting { get; set; }
        long Resistence { get; set; }
        long Attack { get; set; }
        long Social { get; set; }
        long Tailoring { get; set; }
        long Blacksmith { get; set; }
        long Stealth { get; set; }
        long Magic { get; set; }
    }
}
