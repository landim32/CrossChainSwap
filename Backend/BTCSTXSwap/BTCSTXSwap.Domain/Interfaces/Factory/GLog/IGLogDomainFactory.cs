using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory.GLog
{
    public interface IGLogDomainFactory
    {
        IGLogModel BuildGLogModel();
    }
}
