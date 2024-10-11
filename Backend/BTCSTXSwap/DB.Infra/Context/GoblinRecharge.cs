using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinRecharge
    {
        public long Id { get; set; }
        public long IdGoblin { get; set; }
        public DateTime LastRecharge { get; set; }
        public DateTime TiredDate { get; set; }
        public decimal Cost { get; set; }
        public DateTime? StopDate { get; set; }
        public DateTime? RestartDate { get; set; }
        public DateTime? RestartTiredDate { get; set; }
        public byte? Active { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
