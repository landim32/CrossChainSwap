using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Auctions
{
    public interface IAuctionModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        long? IdBuyer { get; set; }
        string PublicAddress { get; set; }
        long? IdGoblin { get; set; }
        GoboxEnum? BoxType { get; set; }
        long? ItemKey { get; set; }
        int Qtdy { get; set; }
        DateTime InsertDate { get; set; }
        decimal Price { get; set; }
        AuctionEnum AuctionType { get; set; }
        AuctionStatusEnum Status { get; set; }

        IEnumerable<IAuctionModel> Search(IAuctionFilterModel filter, out int balance);
        IEnumerable<IAuctionModel> SearchEquipment(IAuctionEquipmentFilterModel filter, out int balance);
        IEnumerable<IAuctionModel> ListByAuction(AuctionEnum auction, int page, out int balance);
        IEnumerable<IAuctionModel> ListByUser(long idUser, AuctionEnum auction);
        IEnumerable<IAuctionModel> ListSameEquipment(long idUser, long itemKey);
        IAuctionModel GetById(long idAuction);
        IAuctionModel GetLastActiveByIdGoblin(long idGoblin);
        void Save();
        void Delete();
    }
}
