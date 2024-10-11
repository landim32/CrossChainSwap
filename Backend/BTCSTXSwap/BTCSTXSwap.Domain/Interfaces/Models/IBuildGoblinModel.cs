using System;
using System.Collections.Generic;
using System.Drawing;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IBuildGoblinModel
    {
        GenreEnum Genre { get; set; }
        RaceEnum Race { get; set; }
        RaceEnum Hair { get; set; }
        RaceEnum Ear { get; set; }
        RaceEnum Eye { get; set; }
        RaceEnum Mount { get; set; }
        RaceEnum Skin { get; set; }
        Color HairColor { get; set; }
        Color SkinColor { get; set; }
        Color EyeColor { get; set; }
        int Strength { get; set; }
        int Agility { get; set; }
        int Vigor { get; set; }
        int Intelligence { get; set; }
        int Charism { get; set; }
        int Perception { get; set; }
        int Rarity { get; set; }
        void DoBasic();
    }
}
