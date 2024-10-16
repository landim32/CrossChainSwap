using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using Core.Domain.Repository;
using DB.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Mock
{
    public class MockUserRepository : IUserRepository<IUserModel, IUserDomainFactory>
    {
        private IList<IUserModel> _mockUsers = new List<IUserModel>();

        private void InitializeMock(IUserDomainFactory factory) { 
            if (_mockUsers.Count() == 0)
            {
                var md = factory.BuildUserModel();
                md.Id = 1;
                md.Hash = "";
                md.BtcAddress = "tb1qsywnh85ns9ry3vq8gxhqu3pqwp9ar7gla74kzl";
                md.StxAddress = "ST15BKW5CNBJ49GH9FRAG642NZYCJ51B74TTEMAD";
                md.CreateAt = DateTime.Now;
                md.UpdateAt = DateTime.Now;
                _mockUsers.Add(md);
            }
        }

        public IUserModel GetById(long userId, IUserDomainFactory factory)
        {
            InitializeMock(factory);
            return _mockUsers.Where(x => x.Id == userId).FirstOrDefault();
        }

        public IUserModel GetOrCreateByAddress(string btcAddress, string StxAddress, IUserDomainFactory factory)
        {
            InitializeMock(factory);
            return _mockUsers.Where(x => x.BtcAddress == btcAddress).FirstOrDefault();
        }

        public IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory)
        {
            InitializeMock(factory);
            return _mockUsers.ToList();
        }

        public IUserModel LoadUser(string btcAddress, IUserDomainFactory factory)
        {
            InitializeMock(factory);
            return _mockUsers.Where(x => x.BtcAddress == btcAddress).FirstOrDefault();
        }

        public IUserModel SaveUser(IUserModel model)
        {
            _mockUsers.Add(model);
            return model;
        }

        public IUserModel UpdateUser(IUserModel model)
        {

            var md = _mockUsers.Where(x => x.Id == model.Id).FirstOrDefault();
            if (md != null)
            {
                _mockUsers.Remove(md);
            }
            _mockUsers.Add(model);
            return model;
        }
    }
}
