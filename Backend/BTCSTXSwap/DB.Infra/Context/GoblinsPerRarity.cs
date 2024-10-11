using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinsPerRarity
    {
        public int? Common { get; set; }
        public int? Uncommon { get; set; }
        public int? Rare { get; set; }
        public int? Epic { get; set; }
        public int? Legendary { get; set; }
    }
}
