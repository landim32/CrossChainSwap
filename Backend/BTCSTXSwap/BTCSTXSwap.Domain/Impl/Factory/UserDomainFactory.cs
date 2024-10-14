using System;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using Core.Domain;
using Core.Domain.Repository;

namespace BTCSTXSwap.Domain.Impl.Factory
{
    public class UserDomainFactory : IUserDomainFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository<IUserModel, IUserDomainFactory> _repositoryUser;

        public UserDomainFactory(IUnitOfWork unitOfWork, IUserRepository<IUserModel, IUserDomainFactory> repositoryUser)
        {
            _unitOfWork = unitOfWork;
            _repositoryUser = repositoryUser;
        }

        public IUserModel BuildUserModel()
        {
            return new UserModel(_unitOfWork, _repositoryUser);
        }
    }
}
