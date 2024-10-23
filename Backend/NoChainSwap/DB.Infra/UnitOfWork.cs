using System;
using Core.Domain;
using DB.Infra.Context;
using NoChainSwap.Domain.Impl.Core;
using NoChainSwap.Domain.Interfaces.Core;

namespace DB.Infra
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly NoChainSwapContext _goblinContext;
        private readonly ILogCore _log;

        public UnitOfWork(ILogCore log, NoChainSwapContext goblinContext)
        {
            this._goblinContext = goblinContext;
            _log = log;
        }

        public ITransaction BeginTransaction()
        {
            try
            {
                _log.Log("Iniciando bloco de transação.", Levels.Trace);
                return new TransactionDisposable(_log, _goblinContext.Database.BeginTransaction());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
