using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Referral
{
    public interface IRetweetDomainFactory
    {
        IRetweetModel BuildRetweetModel();
    }
}
