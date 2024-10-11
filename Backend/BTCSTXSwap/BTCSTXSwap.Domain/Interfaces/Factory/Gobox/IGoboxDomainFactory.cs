using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.Gobox
{
    public interface IGoboxDomainFactory
    {
        IGoboxModel BuildGoboxModel();
    }
}
