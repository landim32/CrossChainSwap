using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.DTO.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IFinanceService
    {
        void ActiveWithdrawal(long idUser);
        Task CheckContracts();
        void CreditGobi(long idUser, decimal gobiValue, decimal? fee, string msg, LogType logType);
        void DebitGobi(long idUser, decimal gobiValue, decimal? fee, string msg, LogType logType);
        Task<decimal> GetGobiOnMetamask(string publicAddress);
        decimal GetGobiOnCloud(long idUser);
        Task<FinanceInfo> GetFinance(long idUser);
        FinanceListResult List(long idUser, int page);
        Task<FinanceTransacionInfo> ConfirmDeposit(DepositInfo deposit);
        decimal CalculateFee(FinanceTokenEnum token, long idUser, decimal value);
        Task<FinanceTransacionInfo> Withdrawl(FinanceRequestInfo request);
    }
}
