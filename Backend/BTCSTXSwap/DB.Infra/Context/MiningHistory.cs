using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class MiningHistory
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string RewardType { get; set; }
        public DateTime RewardDate { get; set; }
        public int Ranking { get; set; }
        public int GoblinQtde { get; set; }
        public int HashPower { get; set; }
        public long? HashForWeek { get; set; }
        public long? HashForMonth { get; set; }
        public int BoxType { get; set; }
        public bool Claimed { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
