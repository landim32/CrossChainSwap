using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class MaterialMarket
    {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public long? IdUser { get; set; }
        public long MaterialKey { get; set; }
        public long MaterialCredit { get; set; }
        public long MaterialDebit { get; set; }
        public decimal GoldCredit { get; set; }
        public decimal GoldDebit { get; set; }
        public int Status { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
