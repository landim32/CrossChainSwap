using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Finance
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Address { get; set; }
        public DateTime InsertDate { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Gas { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string TxHash { get; set; }
        public decimal Balance { get; set; }
        public byte Withdrawal { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
