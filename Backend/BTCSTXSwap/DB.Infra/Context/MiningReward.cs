using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class MiningReward
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal GobiValue { get; set; }
        public decimal Credit { get; set; }
        public decimal Fee { get; set; }
        public int Status { get; set; }
        public long? HashValue { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
