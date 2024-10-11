using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class DailyLoginDay
    {
        public long IdDay { get; set; }
        public long IdDaily { get; set; }
        public DateTime LimitDate { get; set; }
        public int Day { get; set; }
        public int ItemKey { get; set; }
        public bool Success { get; set; }

        public virtual DailyLogin IdDailyNavigation { get; set; }
    }
}
