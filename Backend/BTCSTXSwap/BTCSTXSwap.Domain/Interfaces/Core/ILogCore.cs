using System;
using BTCSTXSwap.Domain.Impl.Core;
using Microsoft.Extensions.Logging;

namespace BTCSTXSwap.Domain.Interfaces.Core
{
    public interface ILogCore
    {
        void Log(string message, Levels level);
    }
}
