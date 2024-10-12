using Core.Domain;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models
{
    [Obsolete]
    public class BalanceModel : IBalanceModel
    {
        [Obsolete]
        public BalanceInfo Balance { get; set; }
        [Obsolete]
        public string PublicAddress { get; set; }
        private readonly IGobiContract _gobiContract;
        //private readonly IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> _goblinContract;

        public BalanceModel(IGobiContract gobiContract)
        {
            _gobiContract = gobiContract;
            //_goblinContract = goblinContract;
            Balance = new BalanceInfo();
        }

        [Obsolete]
        public async Task LoadBalance()
        {
            //var balanceOfGoblin = await _goblinContract.GetGoblinBalance(PublicAddress);
            //this.Balance.GoblinBalance = balanceOfGoblin;
        }
        [Obsolete]
        public async Task<long> GetGoblinBalance()
        {
            return await Task.FromResult(0); //_goblinContract.GetGoblinBalance(PublicAddress);
        }
    }
}
