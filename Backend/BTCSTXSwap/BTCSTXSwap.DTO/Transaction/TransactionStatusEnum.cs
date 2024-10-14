using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Transaction
{
    public enum TransactionStatusEnum
    {
        Initialized = 1,
        BtcNotConfirmed = 2,
        StxNotConfirmed = 3,
        BtcConfirmed = 4,
        StxConfirmed = 5,
        BtcConfirmedStxNotConfirmed = 4,
        StxConfirmedBtcNotConfirmed = 5,
        BtcConfirmedStxConfirmed = 6,
        StxConfirmedBtcConfirmed = 7
    }
}
