using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class ReTweet
    {
        public int Id { get; set; }
        public long IdUser { get; set; }
        public string Tweet { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
