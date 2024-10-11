using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Core.Domain;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    [Obsolete]
    public class GoblinDNA : IGoblinDNA
    {
        //private readonly IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> _contractGoblin;
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBornContract _bornContract;

        [Obsolete]
        public BigInteger TokenId { get; set; }
        [Obsolete]
        public BigInteger Genes { get; set; }
        [Obsolete]
        public BigInteger Mods { get; set; }
        [Obsolete]
        public BigInteger Inventory { get; set; }
        [Obsolete]
        public BigInteger Bag { get; set; }
        [Obsolete]
        public BigInteger BirthTime { get; set; }
        [Obsolete]
        public BigInteger LastUpdateTime { get; set; }
        [Obsolete]
        public BigInteger FatherId { get; set; }
        [Obsolete]
        public BigInteger MotherId { get; set; }
        [Obsolete]
        public BigInteger SpouseId { get; set; }
        [Obsolete]
        public BigInteger SonsCount { get; set; }
        [Obsolete]
        public BigInteger CooldownTime { get; set; }

        [Obsolete]
        public BigInteger CursorGob { get; set; }

        //public GoblinDNA(ILogCore log, IUnitOfWork unitOfWork, IBornContract bornContract)
        public GoblinDNA(ILogCore log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            //_contractGoblin = contractGoblin;
            //_bornContract = bornContract;
        }

        [Obsolete]
        public async Task<IEnumerable<IGoblinDNA>> ListByAddress(string walletAddress, int page, IGoblinDNADomainFactory goblinDNAFactory)
        {
            //return await _contractGoblin.ListByAddress(walletAddress, page, goblinDNAFactory);
            return await Task.FromResult<IEnumerable<IGoblinDNA>>(new List<IGoblinDNA>());
        }

        [Obsolete]
        public async Task<IGoblinDNA> GetGoblin(BigInteger tokenId, IGoblinDNADomainFactory goblinDNAFactory)
        {
            //return await _contractGoblin.GetGoblin(tokenId, goblinDNAFactory);
            return await Task.FromResult<IGoblinDNA>(null);
        }

        [Obsolete]
        public async Task<IEnumerable<IGoblinDNA>> ListSons(IGoblinDNADomainFactory goblinDNAFactory, int page)
        {
            //return await _contractGoblin.ListGoblinsSons(this.TokenId, page, goblinDNAFactory);
            return await Task.FromResult<IEnumerable<IGoblinDNA>>(null);
        }

        [Obsolete]
        public async Task LoadGoblinFamily()
        {
            /*
            var ret = await _contractGoblin.GetGoblinFamily(this.TokenId, this);
            this.FatherId = ret.FatherId;
            this.MotherId = ret.MotherId;
            this.SonsCount = ret.SonsCount;
            this.SpouseId = ret.SpouseId;
            */
        }

        [Obsolete]
        public async Task<string> GetOwnerAddress()
        {
            //return await _contractGoblin.OwnerOfGoblin(this.TokenId);
            return await Task.FromResult<string>("");
        }

        [Obsolete]
        public async Task<IEnumerable<BigInteger>> ListCanBreed(string ownerAddress, IEnumerable<BigInteger> candidates)
        {
            return await _bornContract.CanBreed(ownerAddress, this.TokenId, candidates);
        }

        [Obsolete]
        public async Task<BigInteger> BreedCost(BigInteger spouseId)
        {
            return await _bornContract.BreedCost(this.TokenId, spouseId);
        }

        [Obsolete]
        public async Task<long> SonsBalance()
        {
            //return await _contractGoblin.GetSonBalance(this.TokenId);
            return await Task.FromResult<long>(0);
        }

        [Obsolete]
        public async Task<IGoblinDNA> LastGoblin(string ownerAddress, IGoblinDNADomainFactory goblinDNAFactory)
        {
            //return await _contractGoblin.LastGoblin(ownerAddress, goblinDNAFactory);
            return await Task.FromResult<IGoblinDNA>(null);
        }
    }
}