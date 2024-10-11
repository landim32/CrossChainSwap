using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Auctions
{
    public class AuctionModel: IAuctionModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuctionDomainFactory _auctionFactory;
        private readonly IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel> _repAuction;

        public AuctionModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IAuctionDomainFactory auctionFactory,
            IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel> repAuction
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _auctionFactory = auctionFactory;
            _repAuction = repAuction;
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public long? IdBuyer { get; set; }
        public string PublicAddress { get; set; }
        public long? IdGoblin { get; set; }
        public GoboxEnum? BoxType { get; set; }
        public long? ItemKey { get; set; }
        public int Qtdy { get; set; }
        public DateTime InsertDate { get; set; }
        public decimal Price { get; set; }
        public AuctionEnum AuctionType { get; set; }
        public AuctionStatusEnum Status { get; set; }

        public IEnumerable<IAuctionModel> Search(IAuctionFilterModel filter, out int balance)
        {
            return _repAuction.Search(_auctionFactory, filter, out balance);
        }
        public IEnumerable<IAuctionModel> SearchEquipment(IAuctionEquipmentFilterModel filter, out int balance)
        {
            return _repAuction.SearchEquipment(_auctionFactory, filter, out balance);
        }
        public IEnumerable<IAuctionModel> ListByAuction(AuctionEnum auction, int page, out int balance)
        {
            return _repAuction.ListByAuction(_auctionFactory, (int)auction, page, out balance);
        }
        public IEnumerable<IAuctionModel> ListByUser(long idUser, AuctionEnum auction)
        {
            return _repAuction.ListByUser(_auctionFactory, idUser, (int) auction);
        }
        public IEnumerable<IAuctionModel> ListSameEquipment(long idUser, long itemKey)
        {
            return _repAuction.ListSameEquipment(_auctionFactory, idUser, itemKey);
        }
        public IAuctionModel GetById(long idAuction)
        {
            return _repAuction.GetById(_auctionFactory, idAuction);
        }
        public IAuctionModel GetLastActiveByIdGoblin(long idGoblin)
        {
            return _repAuction.GetLastActiveByIdGoblin(_auctionFactory, idGoblin);
        }
        public void Save()
        {
            if (this.Id > 0)
            {
                _repAuction.Update(this);
            }
            else
            {
                _repAuction.Insert(this);
            }
        }
        public void Delete()
        {
            _repAuction.Delete(this.Id);
        }
    }
}
