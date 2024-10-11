using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Goblins
{
    public class GoblinSpriteDomainFactory : IGoblinSpriteDomainFactory
    {
        public IGoblinSpriteModel BuildGoblinSpriteModel()
        {
            return new GoblinSpriteModel();
        }
    }
}
