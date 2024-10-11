using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class UserMiningEstimativeReward
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Common { get; set; }
        public int? Uncommon { get; set; }
        public int? Rare { get; set; }
        public int? Epic { get; set; }
        public int? Legendary { get; set; }
        public decimal? HashPower { get; set; }
        public decimal? DailyReward { get; set; }
        public decimal? DailyRecharge { get; set; }
        public decimal? RealDailyReward { get; set; }
    }
}
