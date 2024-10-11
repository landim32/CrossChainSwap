using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Finance
{
    public enum FinanceTransactionStatusEnum
    {
        Start = 0,
        OutOfLimit = 1,
        OutOfBalance = 2,
        InCooldown = 3,
        Processing = 4,
        Confirmed = 5,
        ErrorRunTime = 6,
        ErrorBlockchain = 7,
        ErrorInvalidContract = 8,
        ErrorInvalidSender = 9,
        ErrorInvalidReceiver = 10,
        ErrorInvalidValue = 11,
        ErrorAlreadyProcessed = 12,
        //ErrorOnBalanceReduce,
        //ErrorOnBalanceIncrease
    }
}
