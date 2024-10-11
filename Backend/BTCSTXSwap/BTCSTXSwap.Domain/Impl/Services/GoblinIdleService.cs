using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinIdleService : IGoblinIdleService
    {
        private readonly IGoblinIdleDomainFactory _goblinIdleFactory;
        private readonly ILogCore _log;

        public GoblinIdleService(IGoblinIdleDomainFactory goblinIdleFactory, ILogCore log)
        {
            _goblinIdleFactory = goblinIdleFactory;
            _log = log;
        }

        public IEnumerable<IGoblinIdleModel> ListIdle(int idUser)
        {
            _log.Log("List goblins idle by user.", Core.Levels.Debug);
            return _goblinIdleFactory.BuildGoblinIdleModel().ListIdle(_goblinIdleFactory, idUser);
        }
    }
}
