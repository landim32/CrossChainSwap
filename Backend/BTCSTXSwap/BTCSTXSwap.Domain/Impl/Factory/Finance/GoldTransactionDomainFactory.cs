using System;
using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;

namespace BTCSTXSwap.Domain.Impl.Factory.Finance
{
    public class GoldTransactionDomainFactory : IGoldTransactionDomainFactory
    {

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory> _goldFinanceRepository;

        public GoldTransactionDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory> goldFinanceRepository
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goldFinanceRepository = goldFinanceRepository;
        }

        public IGoldTransactionModel BuildGoldTransactionModel()
        {
            return new GoldTransactionModel(this, _goldFinanceRepository);
        }
    }
}
