using System;
using System.Collections.Generic;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Core.Domain;
using Core.Domain.Repository;

namespace Auth.Domain.Impl.Models
{
    public class UserModel : IUserModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository<IUserModel, IUserDomainFactory> _repositoryUser;

        public UserModel(IUnitOfWork unitOfWork, IUserRepository<IUserModel, IUserDomainFactory> repositoryUser)
        {
            _unitOfWork = unitOfWork;
            _repositoryUser = repositoryUser;
        }

        public long Id { get; set; }
        public string Hash { get; set; }
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public IUserModel GetById(long userId, IUserDomainFactory factory)
        {
            return _repositoryUser.GetById(userId, factory);
        }

        public IUserModel GetUser(string btcAddress, string StxAddress, IUserDomainFactory factory)
        {
            return _repositoryUser.GetOrCreateByAddress(btcAddress, StxAddress, factory);
        }


        public IUserModel Save()
        {
            return _repositoryUser.SaveUser(this);
        }

        public IUserModel Update()
        {
            return _repositoryUser.UpdateUser(this);
        }

        public IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory)
        {
            return _repositoryUser.ListUsers(factory);
        }
    }
}
