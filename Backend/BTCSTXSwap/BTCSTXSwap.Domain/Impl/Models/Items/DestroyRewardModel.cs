using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class DestroyRewardModel: IDestroyRewardModel
    {
        public int GoldMin { get; set; }
        public int GoldMax { get; set; }
        public int Qtdy { get; set; }
        public IList<IItemDestroyRewardModel> Items { get; set; }
    }
}
