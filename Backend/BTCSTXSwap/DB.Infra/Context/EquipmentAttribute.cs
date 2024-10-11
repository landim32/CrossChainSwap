using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class EquipmentAttribute
    {
        public EquipmentAttribute()
        {
            EquipmentAttributeBonus = new HashSet<EquipmentAttributeBonu>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EquipmentAttributeBonu> EquipmentAttributeBonus { get; set; }
    }
}
