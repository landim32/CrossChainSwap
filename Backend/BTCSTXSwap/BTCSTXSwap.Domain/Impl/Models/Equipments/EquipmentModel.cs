using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Equipments
{
    public class EquipmentModel: IEquipmentModel
    {
        public EquipmentTypeEnum ItemType { get; set; }
        public double Weight { get; set; }
        public string ImageStand { get; set; }
        public string ImageMiningStop { get; set; }
        public string ImageMiningUp { get; set; }
        public string ImageMiningDown { get; set; }
        public string ImageMiningRest { get; set; }
        public Color Color { get; set; }
        public IList<BodyPartEnum> Part { get; set; }
        public bool IsTwoHanded { get; set; }
        public bool Binded { get; set; }
        public long Mining { get; set; } = 0;
        public long Hunting { get; set; } = 0;
        public long Resistence { get; set; } = 0;
        public long Attack { get; set; } = 0;
        public long Social { get; set; } = 0;
        public long Tailoring { get; set; } = 0;
        public long Blacksmith { get; set; } = 0;
        public long Stealth { get; set; } = 0;
        public long Magic { get; set; } = 0;
    }
}
