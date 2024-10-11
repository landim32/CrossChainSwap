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
        public long IdReferral { get; set; }
        public string ReferralCode { get; set; }
        public string PublicAddress { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public decimal Gobi { get; set; }
        public int GobBlocked { get; set; }
        public DateTime? GobBlockedDate { get; set; }
        public DateTime? GobLastClaim { get; set; }
        public int Gwb { get; set; }
        public DateTime? GwdLastClaim { get; set; }
        public DateTime? GoldLastClaim { get; set; }
        public StatusEnum Status { get; set; }

        public long GetIdUserByReferralCode(string refCode)
        {
            return _repositoryUser.GetIdUserByReferralCode(refCode);
        }

        public IUserModel GetById(long userId, IUserDomainFactory factory)
        {
            return _repositoryUser.GetById(userId, factory);
        }

        public IUserModel GetUser(string publicAddress, IUserDomainFactory factory, string fromReferralCode = null)
        {
            return _repositoryUser.GetOrCreateByAddress(publicAddress, factory, fromReferralCode);
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
