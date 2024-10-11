using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinSale
    {
        public long Id { get; set; }
        public long IdGoblin { get; set; }
        public double GoblinValue { get; set; }
        public byte Pending { get; set; }
        public long? BuyingIdUser { get; set; }
        public DateTime DatePublish { get; set; }
        public DateTime? DatePending { get; set; }
        public DateTime? DatePaidOut { get; set; }
        public string TransactionHash { get; set; }

        public virtual User BuyingIdUserNavigation { get; set; }
        public virtual Goblin IdGoblinNavigation { get; set; }
    }
}
