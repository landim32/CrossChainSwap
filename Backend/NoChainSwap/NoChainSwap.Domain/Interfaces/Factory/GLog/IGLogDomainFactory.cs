using NoChainSwap.Domain.Interfaces.Models.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Interfaces.Factory.GLog
{
    public interface IGLogDomainFactory
    {
        IGLogModel BuildGLogModel();
    }
}
