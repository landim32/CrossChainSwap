using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinFeature
    {
        public long IdGoblin { get; set; }
        public int FeatureType { get; set; }
        public string Description { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
