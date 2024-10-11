using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class EquipmentAttributeBonu
    {
        public long IdAttribute { get; set; }
        public long ItemKey { get; set; }
        public decimal Value { get; set; }

        public virtual EquipmentAttribute IdAttributeNavigation { get; set; }
    }
}
