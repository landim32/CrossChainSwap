using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class User
    {
        public long UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Hash { get; set; }
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }
    }
}
