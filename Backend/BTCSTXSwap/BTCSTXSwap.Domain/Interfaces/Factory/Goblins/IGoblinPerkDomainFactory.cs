using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Goblins
{
    public interface IGoblinPerkDomainFactory
    {
        IGoblinPerkModel BuildGoblinPerkModel();
    }
}
