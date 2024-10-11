using Core.Domain.Repository.Goblins;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Goblins
{
    public class GoblinPerkRepository : IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public GoblinPerkRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IGoblinPerkModel DbToModel(IGoblinPerkDomainFactory factory, GoblinPerk info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildGoblinPerkModel();
            md.Id = info.Id;
            md.IdGoblin = info.IdGoblin;
            md.Perk = (GoblinPerkEnum) info.PerkKey;
            return md;
        }

        private void ModelToDb(GoblinPerk info, IGoblinPerkModel md)
        {
            info.Id = md.Id;
            info.IdGoblin = md.IdGoblin;
            info.PerkKey = (int) md.Perk;
        }

        public IEnumerable<IGoblinPerkModel> ListByGoblin(IGoblinPerkDomainFactory factory, long idGoblin)
        {
            return _goblinContext.GoblinPerks
                .Where(x => x.IdGoblin == idGoblin)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }

        public void Clear(long idGoblin)
        {
            var perks = _goblinContext.GoblinPerks
                .Where(x => x.IdGoblin == idGoblin)
                .ToList();
            _goblinContext.RemoveRange(perks);
        }

        public void Insert(IGoblinPerkModel md)
        {
            GoblinPerk info = new GoblinPerk();
            ModelToDb(info, md);
            _goblinContext.GoblinPerks.Add(info);
            _goblinContext.SaveChanges();
        }
    }
}
