using System;
using NoChainSwap.Domain.Interfaces.Models;

namespace NoChainSwap.Domain.Interfaces.Factory
{
    public interface IUserDomainFactory
    {
        IUserModel BuildUserModel();
    }
}
