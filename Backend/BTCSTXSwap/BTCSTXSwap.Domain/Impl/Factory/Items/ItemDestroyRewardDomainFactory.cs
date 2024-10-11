using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class ItemDestroyRewardDomainFactory : IItemDestroyRewardDomainFactory
    {
        public IItemDestroyRewardModel BuildItemDestroyRewardModel()
        {
            return new ItemDestroyRewardModel();
        }
    }
}
