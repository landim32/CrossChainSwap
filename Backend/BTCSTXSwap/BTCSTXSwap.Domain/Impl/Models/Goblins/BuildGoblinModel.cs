using System;
using System.Collections.Generic;
using System.Drawing;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class BuildGoblinModel : IBuildGoblinModel
    {
        public GenreEnum Genre { get; set; }
        public RaceEnum Race { get; set; }
        public RaceEnum Hair { get; set; }
        public RaceEnum Ear { get; set; }
        public RaceEnum Eye { get; set; }
        public RaceEnum Mount { get; set; }
        public RaceEnum Skin { get; set; }
        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Color EyeColor { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vigor { get; set; }
        public int Intelligence { get; set; }
        public int Charism { get; set; }
        public int Perception { get; set; }
        public int Rarity { get; set; }
        public void DoBasic()
        {
            //e.UidUser = uidUser;
            // Id = NewUID();
            Strength = 7;
            Agility = 7;
            Vigor = 7;
            Intelligence = 7;
            Charism = 7;
            Perception = 7;
        }
    }
}