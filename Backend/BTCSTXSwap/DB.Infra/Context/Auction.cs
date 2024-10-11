using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Auction
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public int AuctionType { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public int Qtdy { get; set; }
        public decimal Price { get; set; }
        public long? IdGoblin { get; set; }
        public int? BoxType { get; set; }
        public long? IdBuyer { get; set; }
        public long? ItemKey { get; set; }

        public virtual User IdBuyerNavigation { get; set; }
        public virtual Goblin IdGoblinNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
