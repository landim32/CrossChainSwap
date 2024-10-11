using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class UserQuestsGoblin
    {
        public long Id { get; set; }
        public long IdQuest { get; set; }
        public long GoblinToken { get; set; }

        public virtual UserQuest IdQuestNavigation { get; set; }
    }
}
