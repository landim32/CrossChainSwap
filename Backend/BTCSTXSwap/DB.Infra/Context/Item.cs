using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Item
    {
        public long IdItem { get; set; }
        public long ItemKey { get; set; }
        public long IdUser { get; set; }
        public long? IdGoblin { get; set; }
        public bool Binding { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Qtde { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
