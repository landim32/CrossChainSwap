using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinUserService : IGoblinUserService
    {
        private readonly ILogCore _log;
        private readonly IBalanceDomainFactory _balanceDomainFactory;
        private readonly IUserService _userService;
        private readonly IFinanceService _financeService;
        private readonly IGoldFinanceService _goldFinanceService;

        public GoblinUserService(ILogCore log, IBalanceDomainFactory balanceDomainFactory, IUserService userService, IFinanceService financeService, IGoldFinanceService goldFinanceService)
        {
            _balanceDomainFactory = balanceDomainFactory;
            _log = log;
            _userService = userService;
            _financeService = financeService;
            _goldFinanceService = goldFinanceService;
        }
        public async Task<BalanceInfo> GetBalance(string publicAddress)
        {
            var balanceMd = _balanceDomainFactory.BuildBalanceModel();
            balanceMd.PublicAddress = publicAddress;
            var user = _userService.GetUser(publicAddress);
            balanceMd.Balance.CloudWalletGobiBalance = _financeService.GetGobiOnCloud(user.Id);
            balanceMd.Balance.GobiBalance = balanceMd.Balance.CloudWalletGobiBalance;
            balanceMd.Balance.GoldBalance = _goldFinanceService.GetUserGoldBalance(user.Id);
            return balanceMd.Balance;
        }
    }
}
