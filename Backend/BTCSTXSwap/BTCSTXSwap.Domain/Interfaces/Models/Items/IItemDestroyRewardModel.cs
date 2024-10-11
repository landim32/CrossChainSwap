using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Items
{
    public interface IItemDestroyRewardModel
    {
        long ItemKey { get; set; }
        int Percent { get; set; }
        int QtdeMin { get; set; }
        int QtdeMax { get; set; }
    }
}
