using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinSon
    {
        public long IdParent { get; set; }
        public long IdSon { get; set; }

        public virtual Goblin IdParentNavigation { get; set; }
        public virtual Goblin IdSonNavigation { get; set; }
    }
}
