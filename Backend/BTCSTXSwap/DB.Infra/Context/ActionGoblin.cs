using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class ActionGoblin
    {
        public int IdAction { get; set; }
        public long IdGoblin { get; set; }

        public virtual Action IdActionNavigation { get; set; }
        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
