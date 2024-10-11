using System;
using System.Drawing;
using System.Numerics;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.DTO.Goblin
{
    public class GeneInfo
    {
        public BigInteger Code { get; set; }

        public GenreEnum Genre { get; set; }
        public int Rarity { get; set; }
        public RaceEnum Race { get; set; }
        public RaceEnum Skin { get; set; }
        public RaceEnum SkinR1 { get; set; }
        public RaceEnum SkinR2 { get; set; }
        public RaceEnum Hair { get; set; }
        public RaceEnum HairR1 { get; set; }
        public RaceEnum HairR2 { get; set; }
        public RaceEnum Ear { get; set; }
        public RaceEnum EarR1 { get; set; }
        public RaceEnum EarR2 { get; set; }
        public RaceEnum Eyes { get; set; }
        public RaceEnum EyesR1 { get; set; }
        public RaceEnum EyesR2 { get; set; }
        public RaceEnum Mouth { get; set; }
        public RaceEnum MouthR1 { get; set; }
        public RaceEnum MouthR2 { get; set; }

        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Color EyesColor { get; set; }
    }
}
