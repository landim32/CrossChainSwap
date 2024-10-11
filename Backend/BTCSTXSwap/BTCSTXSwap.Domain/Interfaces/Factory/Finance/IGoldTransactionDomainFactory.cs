using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Finance
{
    public interface IGoldTransactionDomainFactory
    {
        IGoldTransactionModel BuildGoldTransactionModel();
    }
}
