using System;
using NoChainSwap.Domain.Impl.Core;
using Microsoft.Extensions.Logging;

namespace NoChainSwap.Domain.Interfaces.Core
{
    public interface ILogCore
    {
        void Log(string message, Levels level);
    }
}
