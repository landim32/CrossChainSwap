using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Goblins
{
    public interface IGoblinSpriteDomainFactory
    {
        IGoblinSpriteModel BuildGoblinSpriteModel();
    }
}
