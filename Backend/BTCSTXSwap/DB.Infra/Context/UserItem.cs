using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class UserItem
    {
        public long IdItem { get; set; }
        public long ItemKey { get; set; }
        public long IdUser { get; set; }
        public int Qtde { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
