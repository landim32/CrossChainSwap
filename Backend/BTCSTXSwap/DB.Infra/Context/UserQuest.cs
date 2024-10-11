using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class UserQuest
    {
        public UserQuest()
        {
            UserQuestsGoblins = new HashSet<UserQuestsGoblin>();
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public int QuestKey { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Status { get; set; }
        public decimal? Percent { get; set; }
        public byte IsJob { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<UserQuestsGoblin> UserQuestsGoblins { get; set; }
    }
}
