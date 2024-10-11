using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    [Obsolete]
    public interface IGoblinDNA
    {
        [Obsolete]
        BigInteger TokenId { get; set; }
        [Obsolete]
        BigInteger Genes { get; set; }
        [Obsolete]
        BigInteger Mods { get; set; }
        [Obsolete]
        BigInteger Inventory { get; set; }
        [Obsolete]
        BigInteger Bag { get; set; }
        [Obsolete]
        BigInteger BirthTime { get; set; }
        [Obsolete]
        BigInteger LastUpdateTime { get; set; }
        [Obsolete]
        BigInteger FatherId { get; set; }
        [Obsolete]
        BigInteger MotherId { get; set; }
        [Obsolete]
        BigInteger SpouseId { get; set; }
        [Obsolete]
        BigInteger SonsCount { get; set; }
        [Obsolete]
        BigInteger CooldownTime { get; set; }
        [Obsolete]
        BigInteger CursorGob { get; set; }

        [Obsolete]
        Task<IEnumerable<IGoblinDNA>> ListByAddress(string walletAddress, int page, IGoblinDNADomainFactory goblinDNAFactory);
        [Obsolete]
        Task<IGoblinDNA> GetGoblin(BigInteger tokenId, IGoblinDNADomainFactory goblinDNAFactory);
        [Obsolete]
        Task<IEnumerable<IGoblinDNA>> ListSons(IGoblinDNADomainFactory goblinDNAFactory, int page);
        [Obsolete]
        Task LoadGoblinFamily();
        [Obsolete]
        Task<string> GetOwnerAddress();
        Task<IEnumerable<BigInteger>> ListCanBreed(string ownerAddress, IEnumerable<BigInteger> candidates);
        [Obsolete]
        Task<BigInteger> BreedCost(BigInteger spouseId);
        [Obsolete]
        Task<long> SonsBalance();
        [Obsolete]
        Task<IGoblinDNA> LastGoblin(string ownerAddress, IGoblinDNADomainFactory goblinDNAFactory);
    }
}
