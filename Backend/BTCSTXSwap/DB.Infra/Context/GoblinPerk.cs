using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinPerk
    {
        public long Id { get; set; }
        public long IdGoblin { get; set; }
        public int PerkKey { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
