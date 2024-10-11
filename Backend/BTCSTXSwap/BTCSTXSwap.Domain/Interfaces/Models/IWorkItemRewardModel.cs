using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IWorkItemRewardModel
    {
        int ItemKey { get; set; }
        int QtdeMin { get; set; }
        int QtdeMax { get; set; }
        int Percent { get; set; }
    }
}
