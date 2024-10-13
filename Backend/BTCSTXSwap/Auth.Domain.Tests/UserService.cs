using System;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.User;
using Moq;
using Xunit;

namespace Auth.Domain.Tests
{
    public class UserService
    {
        private const string _btcAddress = "0x17862312jhaghdbsSFWS";
        private const int _userId = 15;

        [Fact]
        public void CreateNewUserTest()
        {
            Mock<IUserModel> model = new Mock<IUserModel>();
            model.SetupGet(x => x.Id).Returns(_userId);
            model.Setup(x => x.Save()).Returns(model.Object);

            Mock<IUserDomainFactory> factory = new Mock<IUserDomainFactory>();
            factory.Setup(x => x.BuildUserModel()).Returns(model.Object);

            var userService = new Auth.Domain.Impl.Services.UserService(factory.Object);

            // Act:
            IUserModel modelReturn = userService.CreateNewUser(new UserInfo
            {
                BtcAddress = _btcAddress
            });

            Assert.Equal(modelReturn.Id, _userId);
        }
    }
}
