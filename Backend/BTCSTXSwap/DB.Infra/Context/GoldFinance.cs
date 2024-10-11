using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoldFinance
    {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public long? IdUser { get; set; }
        public decimal? GobiDebit { get; set; }
        public decimal? GobiCredit { get; set; }
        public decimal? TransactionGobiTax { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal? TransactionGoldTax { get; set; }
        public int Status { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
