using System;
using GoblinWars.DTO.Goblin;

namespace Equipment.API.DTO
{
    public class EquipPartParam
    {
        public long TokenId { get; set; }
        public long GoblinId { get; set; }
        public long ItemKey { get; set; }
        public BodyPartEnum Part { get; set; }
    }
}
