using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class ItemDestroyRewardItemModel: IItemDestroyRewardModel
    {
        public long ItemKey { get; set; }
        public int Percent { get; set; }
        public int QtdeMin { get; set; }
        public int QtdeMax { get; set; }
    }
}
