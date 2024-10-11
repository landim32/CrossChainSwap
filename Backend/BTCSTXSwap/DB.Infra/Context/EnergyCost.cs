using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class EnergyCost
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public long UserId { get; set; }
        public double? EnergyCost1 { get; set; }
        public int Exhausted { get; set; }
        public decimal? EnergyPercent { get; set; }
        public int HasCost { get; set; }
        public double? EnergyCostDay { get; set; }
        public double? PartialRecharge { get; set; }
    }
}
