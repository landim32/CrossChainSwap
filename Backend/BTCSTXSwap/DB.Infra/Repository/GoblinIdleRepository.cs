using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class GoblinIdleRepository : IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public GoblinIdleRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        public IGoblinIdleModel EntityToModel(IGoblinIdleDomainFactory factory, Goblin g)
        {
            var m = factory.BuildGoblinIdleModel();
            m.Id = g.Id;
            m.Name = g.Name;
            m.Genre = g.Genre;
            m.Race = (RaceEnum)g.Race;
            //m.Goblin
            /*
            m.IsBusy = (
                from ag in _goblinContext.ActionGoblins
                join a in _goblinContext.Actions on ag.IdAction equals a.Id
                where a.Status == (int)ActionStatusEnum.Executing
                    && a.DateTerminate > DateTime.UtcNow
                select a
            ).Any();
            */
            return m;
        }

        public IEnumerable<IGoblinIdleModel> ListIdle(IGoblinIdleDomainFactory factory, int idUser)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser)
                .Select(x => EntityToModel(factory, x));
        }
    }
}
