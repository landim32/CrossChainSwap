using NoChainSwap.Domain.Impl.Models;
using NoChainSwap.Domain.Interfaces.Factory;
using NoChainSwap.Domain.Interfaces.Models;
using Core.Domain;
using Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Factory
{
    public class TransactionDomainFactory : ITransactionDomainFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository<ITransactionModel, ITransactionDomainFactory> _repositoryTx;

        public TransactionDomainFactory(IUnitOfWork unitOfWork, ITransactionRepository<ITransactionModel, ITransactionDomainFactory> repositoryTx)
        {
            _unitOfWork = unitOfWork;
            _repositoryTx = repositoryTx;
        }

        public ITransactionModel BuildTransactionModel()
        {
            return new TransactionModel(_unitOfWork, _repositoryTx);
        }
    }
}
