using System;
using Core.Domain;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Interfaces.Core;

namespace DB.Infra
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly GoblinWarsContext _goblinContext;
        private readonly ILogCore _log;

        public UnitOfWork(ILogCore log, GoblinWarsContext goblinContext)
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
