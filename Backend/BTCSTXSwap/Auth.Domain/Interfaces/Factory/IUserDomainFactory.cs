using System;
using Auth.Domain.Interfaces.Models;

namespace Auth.Domain.Interfaces.Factory
{
    public interface IUserDomainFactory
    {
        IUserModel BuildUserModel();
    }
}
