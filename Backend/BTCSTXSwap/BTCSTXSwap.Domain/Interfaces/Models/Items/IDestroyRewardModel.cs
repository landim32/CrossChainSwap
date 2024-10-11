using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Items
{
    public interface IDestroyRewardModel
    {
        int GoldMin { get; set; }
        int GoldMax { get; set; }
        int Qtdy { get; set; }
        public IList<IItemDestroyRewardModel> Items { get; set; }
    }
}
