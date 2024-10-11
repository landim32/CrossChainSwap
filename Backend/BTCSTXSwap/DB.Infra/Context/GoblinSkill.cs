using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinSkill
    {
        public long IdGoblin { get; set; }
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int Nivel { get; set; }

        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
