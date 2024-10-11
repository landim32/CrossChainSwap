using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Finance
{
    public class FinanceDomainFactory : IFinanceDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory> _repWithdrawToken;

        public FinanceDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory> repWithdrawToken
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repWithdrawToken = repWithdrawToken;
        }

        public IFinanceTransactionModel BuildFinanceModel()
        {
            return new FinanceTransactionModel(_log, _unitOfWork, this, _repWithdrawToken);
        }
    }
}