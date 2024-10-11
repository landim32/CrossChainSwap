using System;
using System.Collections.Generic;
using System.Linq;
using Auth.Domain.Impl.Models;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Core.Domain.Repository;
using DB.Infra.Context;

namespace DB.Infra.Repository
{
    public class UserRepository : IUserRepository<IUserModel, IUserDomainFactory>
    {

        private GoblinWarsContext _goblinContext;

        public UserRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        public IUserModel GetById(long userId, IUserDomainFactory factory)
        {
            try
            {
                var row = _goblinContext.Users.Find(userId);
                if (row == null)
                    return null;
                return this.LoadUser(row.PublicAddress, factory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IUserModel DbToModel(IUserDomainFactory factory, User u)
        {
            var md = factory.BuildUserModel();
            md.Id = u.Id;
            md.IdReferral = u.IdReferral.GetValueOrDefault();
            md.ReferralCode = u.ReferralCode;
            md.PublicAddress = u.PublicAddress;
            md.Hash = u.Hash;
            md.Name = u.Name;
            md.Email = u.Email;
            md.GobBlocked = u.Gobblocked;
            md.GobBlockedDate = u.GobblockedDate;
            md.GobLastClaim = u.GoblastClaim;
            md.Gwb = u.Gwb;
            md.GwdLastClaim = u.GwdlastClaim;
            md.GoldLastClaim = u.GoldLastClaim;
            md.Status = (StatusEnum) u.Status;
            return md;
        }

        private void ModelToDb(IUserModel u, User md)
        {
            if (u.IdReferral > 0)
            {
                md.IdReferral = u.IdReferral;
            }
            md.ReferralCode = u.ReferralCode;
            md.PublicAddress = u.PublicAddress;
            md.Hash = u.Hash;
            md.Name = u.Name;
            md.Email = u.Email;
            md.Gobblocked = u.GobBlocked;
            md.GobblockedDate = u.GobBlockedDate;
            md.GoblastClaim = u.GobLastClaim;
            md.Gwb = u.Gwb;
            md.GwdlastClaim = u.GwdLastClaim;
            md.GoldLastClaim = u.GoldLastClaim;
            md.Status = (int)u.Status;
        }

        public IUserModel LoadUser(string publicAddress, IUserDomainFactory factory)
        {
            try
            {
                var row = _goblinContext.Users.Where(x => x.PublicAddress == publicAddress).FirstOrDefault();
                if(row != null)
                {
                    return DbToModel(factory, row);
                }
                return null;  
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IUserModel SaveUser(IUserModel model)
        {
            try
            {
                var u = new User();
                ModelToDb(model, u);

                if (_goblinContext.Users.Where(x => x.Name == u.Name).Count() > 0)
                    throw new Exception("Name already exists. Choose a new one.");
                if (_goblinContext.Users.Where(x => x.Email == u.Email).Count() > 0)
                    throw new Exception("Email already exists. Choose a new one.");

                _goblinContext.Add(u);
                _goblinContext.SaveChanges();
                model.Id = u.Id;
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel UpdateUser(IUserModel model)
        {
            try
            {
                var row = _goblinContext.Users.Where(x => x.PublicAddress == model.PublicAddress).FirstOrDefault();
                ModelToDb(model, row);
                _goblinContext.Users.Update(row);
                _goblinContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel GetOrCreateByAddress(string publicAddress, IUserDomainFactory factory, string fromReferralCode = null)
        {
            try
            {
                var retUser = LoadUser(publicAddress, factory);
                if(retUser == null)
                {
                    retUser = factory.BuildUserModel();
                    retUser.PublicAddress = publicAddress;
                    if (!string.IsNullOrEmpty(fromReferralCode))
                    {
                        retUser.IdReferral = retUser.GetIdUserByReferralCode(fromReferralCode);
                    }
                    var u = new User();
                    ModelToDb(retUser, u);
                    _goblinContext.Add(u);
                    _goblinContext.SaveChanges();
                    retUser.Id = u.Id;
                    retUser.Name = "Goblin Master " + retUser.Id;
                    retUser = UpdateUser(retUser);
                }
                else if(!String.IsNullOrEmpty(fromReferralCode))
                {
                    retUser.IdReferral = retUser.GetIdUserByReferralCode(fromReferralCode);
                    retUser = UpdateUser(retUser);
                }
                return retUser;
            }
            catch (Exception err)
            {
                throw;
            }
        }

        public long GetIdUserByReferralCode(string refCode)
        {
            return _goblinContext.Users.Where(x => x.ReferralCode == refCode).Select(x => x.Id).FirstOrDefault();
        }

        public IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory)
        {
            var rows = _goblinContext.Users.ToList();
            return rows.Select(x => DbToModel(factory, x));
        }
    }
}
