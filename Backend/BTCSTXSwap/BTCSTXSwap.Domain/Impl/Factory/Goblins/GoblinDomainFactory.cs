using Core.Domain;
using Core.Domain.Repository;
using Core.Domain.Repository.Goblins;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using Microsoft.Extensions.Configuration;

namespace BTCSTXSwap.Domain.Impl.Factory.Goblins
{
    public class GoblinDomainFactory : IGoblinDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IGoblinPerkDomainFactory _perkFactory;
        private readonly IGoblinRepository<IGoblinModel, IGoblinDomainFactory> _repositoryGoblin;
        private readonly IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory> _repPerk;

        public GoblinDomainFactory(
            ILogCore log, 
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IGoblinPerkDomainFactory perkFactory,
            IGoblinRepository<IGoblinModel, IGoblinDomainFactory> repositoryGoblin,
            IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory> repPerk
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _perkFactory = perkFactory;
            _repositoryGoblin = repositoryGoblin;
            _repPerk = repPerk;
        }

        public IBuildGoblinModel BuildGoblinBuildModel()
        {
            return new BuildGoblinModel();
        }

        public IGoblinModel BuildGoblinModel()
        {
            return new GoblinModel(_log, _unitOfWork, _configuration, this, _perkFactory, _repositoryGoblin, _repPerk);
        }
    }
}
