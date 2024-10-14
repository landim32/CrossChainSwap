using System;
using System.Collections.Generic;
using System.Linq;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using Core.Domain.Repository;
using DB.Infra.Context;

namespace DB.Infra.Repository
{
    public class UserRepository : IUserRepository<IUserModel, IUserDomainFactory>
    {

        private CrossChainSwapContext _ccsContext;

        public UserRepository(CrossChainSwapContext ccsContext)
        {
            _ccsContext = ccsContext;
        }

        public IUserModel GetById(long userId, IUserDomainFactory factory)
        {
            try
            {
                var row = _ccsContext.Users.Find(userId);
                if (row == null)
                    return null;
                return this.LoadUser(row.BtcAddress, factory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IUserModel DbToModel(IUserDomainFactory factory, User u)
        {
            var md = factory.BuildUserModel();
            md.Id = u.UserId;
            md.Hash = u.Hash;
            md.BtcAddress = u.BtcAddress;
            md.StxAddress = u.StxAddress;
            md.CreateAt = u.CreateAt;
            md.UpdateAt = u.UpdateAt;
            return md;
        }

        private void ModelToDb(IUserModel u, User md)
        {
            md.UserId = u.Id;
            md.Hash = u.Hash;
            md.BtcAddress = u.BtcAddress;
            md.StxAddress = u.StxAddress;
            md.CreateAt = u.CreateAt;
            md.UpdateAt = u.UpdateAt;
        }

        public IUserModel LoadUser(string btcAddress, IUserDomainFactory factory)
        {
            try
            {
                var row = _ccsContext.Users.Where(x => x.BtcAddress == btcAddress).FirstOrDefault();
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

                /*
                if (_ccsContext.Users.Where(x => x.Name == u.Name).Count() > 0)
                    throw new Exception("Name already exists. Choose a new one.");
                if (_goblinContext.Users.Where(x => x.Email == u.Email).Count() > 0)
                    throw new Exception("Email already exists. Choose a new one.");
                */

                _ccsContext.Add(u);
                _ccsContext.SaveChanges();
                model.Id = u.UserId;
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
                var row = _ccsContext.Users.Where(x => x.BtcAddress == model.BtcAddress).FirstOrDefault();
                ModelToDb(model, row);
                _ccsContext.Users.Update(row);
                _ccsContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserModel GetOrCreateByAddress(string btcAddress, string stxAddress, IUserDomainFactory factory)
        {
            try
            {
                var retUser = LoadUser(btcAddress, factory);
                if(retUser == null)
                {
                    retUser = factory.BuildUserModel();
                    retUser.BtcAddress = btcAddress;
                    retUser.StxAddress = stxAddress;
                    retUser.CreateAt = DateTime.Now;
                    retUser.UpdateAt = DateTime.Now;
                    var u = new User();
                    ModelToDb(retUser, u);
                    _ccsContext.Add(u);
                    _ccsContext.SaveChanges();
                    retUser.Id = u.UserId;
                    retUser = UpdateUser(retUser);
                }
                return retUser;
            }
            catch (Exception err)
            {
                throw;
            }
        }

        public IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory)
        {
            var rows = _ccsContext.Users.ToList();
            return rows.Select(x => DbToModel(factory, x));
        }
    }
}
