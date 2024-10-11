using System;
using Auth.Domain.Impl.Models;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Core.Domain;
using Core.Domain.Repository;

namespace Auth.Domain.Impl.Factory
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
