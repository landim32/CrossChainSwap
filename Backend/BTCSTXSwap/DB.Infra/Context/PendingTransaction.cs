using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class PendingTransaction
    {
        public string TxHash { get; set; }
        public long IdUser { get; set; }
        public DateTime InsertDate { get; set; }
        public decimal Value { get; set; }
    }
}
