using BTCSTXSwap.Domain.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IRaceModel
    {
        void DoPureRace(IBuildGoblinModel Goblin);
        void Generate(IBuildGoblinModel Goblin);
    }
}
