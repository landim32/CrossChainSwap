using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinIdleModel
    {
        long Id { get; set; }
        string Name { get; set; }
        string Genre { get; set; }
        RaceEnum Race { get; set; }
        //IGoblinModel Goblin { get; set; }
        //bool IsBusy { get; set; }
        string Description { get; }

        IEnumerable<IGoblinIdleModel> ListIdle(IGoblinIdleDomainFactory factory, int IdUser);
    }
}
