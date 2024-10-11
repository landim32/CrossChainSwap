using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Auctions
{
    public interface IAuctionEquipmentFilterDomainFactory
    {
        IAuctionEquipmentFilterModel BuildAuctionEquipmentFilterModel();
    }
}
