using System;
using System.Drawing;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.DTO.Goblin
{
    public class AvatarInfo
    {
        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Color EyesColor { get; set; }
        public bool FullBody { get; set; } = true;
        public GenreEnum Genre { get; set; }
        public RaceEnum Skin { get; set; }
        public RaceEnum Hair { get; set; }
        public RaceEnum Ear { get; set; }
        public RaceEnum Eyes { get; set; }
        public RaceEnum Mouth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public EquipmentInfo Head { get; set; }
        public EquipmentInfo Chest { get; set; }
        public EquipmentInfo Hand { get; set; }
        public EquipmentInfo Foot { get; set; }
        public EquipmentInfo MainHand { get; set; }
        public EquipmentInfo SecondHand { get; set; }

    }
}
