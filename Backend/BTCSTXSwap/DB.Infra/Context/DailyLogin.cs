using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class DailyLogin
    {
        public DailyLogin()
        {
            DailyLoginDays = new HashSet<DailyLoginDay>();
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DailyLoginDay> DailyLoginDays { get; set; }
    }
}
