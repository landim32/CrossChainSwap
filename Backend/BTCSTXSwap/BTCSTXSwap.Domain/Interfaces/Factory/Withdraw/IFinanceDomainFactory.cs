using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Withdraw
{
    public interface IFinanceDomainFactory
    {
        IFinanceTransactionModel BuildFinanceModel();
    }
}
