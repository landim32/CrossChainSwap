using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionLogs = new HashSet<TransactionLog>();
        }

        public long TxId { get; set; }
        public int Type { get; set; }
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }
        public string BtcTxid { get; set; }
        public string StxTxid { get; set; }
        public int? BtcFee { get; set; }
        public int? StxFee { get; set; }
        public long? BtcAmount { get; set; }
        public long? StxAmount { get; set; }

        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
    }
}
