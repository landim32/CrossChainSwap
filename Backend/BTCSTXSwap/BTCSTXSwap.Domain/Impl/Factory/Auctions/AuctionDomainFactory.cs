using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Auctions
{
    public class AuctionDomainFactory: IAuctionDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel> _repAuction;

        public AuctionDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel> repAuction
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repAuction = repAuction;
        }

        public IAuctionModel BuildAuctionModel()
        {
            return new AuctionModel(_log, _unitOfWork, this, _repAuction);
        }
    }
}
