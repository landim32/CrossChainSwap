using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Mining
{
    public interface IMiningRewardDomainFactory
    {
        IMiningRewardModel BuildMiningRewardModel();
    }
}
