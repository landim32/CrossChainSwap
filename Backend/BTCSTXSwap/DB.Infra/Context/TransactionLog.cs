﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class TransactionLog
    {
        public long LogId { get; set; }
        public long TxId { get; set; }
        public DateTime Date { get; set; }
        public int LogType { get; set; }
        public string Message { get; set; }

        public virtual Transaction Tx { get; set; }
    }
}
