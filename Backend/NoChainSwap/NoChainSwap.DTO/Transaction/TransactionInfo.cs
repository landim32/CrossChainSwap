using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Transaction
{
    public class TransactionInfo
    {
        public long TxId { get; set; }
        public TransactionEnum Type { get; set; }
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public TransactionStatusEnum Status { get; set; }
        public string BtcTxid { get; set; }
        public string StxTxid { get; set; }
        public int? BtcFee { get; set; }
        public int? StxFee { get; set; }
        public long? BtcAmount { get; set; }
        public long? StxAmount { get; set; }
    }
}
