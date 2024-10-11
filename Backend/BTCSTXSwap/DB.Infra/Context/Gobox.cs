using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Gobox
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public int BoxType { get; set; }
        public int Qtdy { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
