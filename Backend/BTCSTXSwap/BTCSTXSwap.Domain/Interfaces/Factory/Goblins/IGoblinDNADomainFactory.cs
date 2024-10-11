using System;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Goblins
{
    public interface IGoblinDNADomainFactory
    {
        IGoblinDNA BuildGoblinModel();
    }
}
