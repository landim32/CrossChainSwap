using System;
using BTCSTXSwap.Domain.Interfaces.Models;

namespace BTCSTXSwap.Domain.Interfaces.Factory
{
    public interface IUserDomainFactory
    {
        IUserModel BuildUserModel();
    }
}
