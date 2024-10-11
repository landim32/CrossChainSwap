using BTCSTXSwap.Domain.Impl.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Factory.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Auctions
{
    public class AuctionFilterDomainFactory : IAuctionFilterDomainFactory
    {
        public IAuctionFilterModel BuildAuctionFilterModel()
        {
            return new AuctionFilterModel();
        }
    }
}
