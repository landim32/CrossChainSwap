using System;
using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Items;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class MaterialTradeDomainFactory : IMaterialTradeDomainFactory
    {

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory> _materialMarketRepository;

        public MaterialTradeDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory> materialMarketRepository
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _materialMarketRepository = materialMarketRepository;
        }

        public IMaterialTradeModel BuildMaterialTradeModel()
        {
            return new MaterialTradeModel(this, _materialMarketRepository);
        }
    }
}
