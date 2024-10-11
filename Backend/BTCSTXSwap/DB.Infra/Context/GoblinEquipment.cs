using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinEquipment
    {
        public long Id { get; set; }
        public long IdGoblin { get; set; }
        public long ItemKey { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string ItemCategory { get; set; }
        public int EquipmentType { get; set; }
        public int BodyPart { get; set; }
        public byte Equiped { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
