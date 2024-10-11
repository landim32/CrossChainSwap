using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class MiningRanking
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime LastMining { get; set; }
        public string Name { get; set; }
        public int HashPower { get; set; }
        public int GoblinQtde { get; set; }
        public decimal Percent { get; set; }
        public decimal RewardPerSecond { get; set; }
        public decimal RewardPerMonth { get; set; }
        public long? HashForWeek { get; set; }
        public long? HashForMonth { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
