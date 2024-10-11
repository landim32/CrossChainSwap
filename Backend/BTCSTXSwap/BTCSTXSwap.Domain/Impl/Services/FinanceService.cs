using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using Core.Domain;
using Core.Domain.Withdraw;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Finance;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class FinanceService: IFinanceService
    {
        private readonly ILogCore _log;
        private readonly IGLogService _glogService;
        private readonly IUserService _userService;
        //private readonly IGobiWithdraw _gobiWithdraw;
        //private readonly IGobiContract _gobiContract;
        private readonly IFinanceDomainFactory _financeFactory;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationService _configurationService;
        private readonly IGoboxDomainFactory _goboxFactory;
        private readonly IUnitOfWork _unitOfWork;

        private const int GOBI_WITHDRAWAL_MIN = 40;
        private const int GOBI_WITHDRAWAL_LIMIT = 1000;
        private const int DAYS_FOR_NO_FEE = 15;
        private const decimal MIN_GOBI = 10.0M;
        private const decimal MIN_GOBI_FEE = 10M;
        private const int MAX_FEE_PERCENT = 50;

        private const string TRANSACTION_ALREADY_PROCESSED = "This transaction has already been processed in {0}.";
        private const string ERROR_INVALID_SENDER = "Transaction success but wrong sender ({0}).";
        private const string ERROR_INVALID_RECEIVER = "Transaction success but wrong receiver ({0}).";
        private const string ERROR_INVALID_VALUE = "Transaction success but wrong value ({0}).";
        private const string ERROR_INVALID_CONTRACT = "Transaction success but wrong contract ({0}).";

        public FinanceService (
            ILogCore log,
            IGLogService glogService,
            IUserService userService,
            //IGobiWithdraw gobiWithdraw,
            //IGobiContract gobiContract,
            IFinanceDomainFactory withdrawTokenFactory,
            IConfiguration configuration,
            IConfigurationService configurationService,
            IGoboxDomainFactory goboxFactory,
            IUnitOfWork unitOfWork
        )
        {
            _log = log;
            _glogService = glogService;
            _userService = userService;
            //_gobiWithdraw = gobiWithdraw;
            //_gobiContract = gobiContract;
            _financeFactory = withdrawTokenFactory;
            _configuration = configuration;
            _configurationService = configurationService;
            _goboxFactory = goboxFactory;
            _unitOfWork = unitOfWork;
        }

        public FinanceListResult List(long idUser, int page)
        {
            int balance = 0;
            var transactions = _financeFactory.BuildFinanceModel()
                .ListByUser(idUser, page, out balance)
                .Select(x => ModelToInfo(x))
                .ToList();

            return new FinanceListResult
            {
                Transactions = transactions,
                TotalPages = (int)Math.Ceiling((decimal)balance / int.Parse(_configuration["Contract:ItensForPage"])),
                Page = page
            };
        }

        public async Task<decimal> GetGobiOnMetamask(string publicAddress)
        {
            //var gobi = await _gobiContract.GobiBalance(publicAddress);
            BigInteger gobi = 0;
            var gobiValue = BigInteger.Divide(gobi, new BigInteger(Math.Pow(10, 18)));
            return (decimal)gobiValue;
        }

        public decimal GetGobiOnCloud(long idUser)
        {
            var md = _financeFactory.BuildFinanceModel();
            return md.GetGobi(idUser);
        }

        public void ActiveWithdrawal(long idUser)
        {
            var md = _financeFactory.BuildFinanceModel();
            if(md.GetTotalCredit(idUser) > 400)
            {
                var mdGobox = _goboxFactory.BuildGoboxModel();
                if (mdGobox.CheckBuyGoblinBox(idUser) && mdGobox.CheckOpenedGoblinBox(idUser))
                {
                    md.ActiveWithdrawal(idUser);
                }
            }
            
        }

        private async Task<ITransactionStatusModel> GetTransaction(IFinanceTransactionModel md)
        {
            var _value = new BigInteger((double)md.Credit * Math.Pow(10, 18));
            //return  await _gobiWithdraw.GetTransaction(md.TxHash);
            return await Task.FromResult<ITransactionStatusModel>(null);
        }

        public void CreditGobi(long idUser, decimal gobiValue, decimal? fee, string msg, LogType logType)
        {
            if (gobiValue <= 0)
            {
                throw new Exception("Credit cant be zero or negative.");
            }
            var user = _userService.GetUSerByID(idUser);
            var md = _financeFactory.BuildFinanceModel();
            var gobi = md.GetGobi(idUser);
            md.IdUser = idUser;
            md.Address = user.PublicAddress;
            md.InsertDate = DateTime.Now;
            md.Credit = gobiValue;
            md.Fee = fee;
            md.Balance = gobi + gobiValue;
            //md.Message = msg;
            md.Status = FinanceTransactionStatusEnum.Confirmed;
            md.Save();
            _glogService.AddLog(idUser, msg, logType);
            md.UpdateGobi(idUser, gobiValue);
        }

        public void DebitGobi(long idUser, decimal gobiValue, decimal? fee, string msg, LogType logType)
        {
            if (gobiValue <= 0)
            {
                throw new Exception("Debit cant be zero or negative.");
            }
            var md = _financeFactory.BuildFinanceModel();
            var gobi = md.GetGobi(idUser);
            if (gobiValue > gobi)
            {
                throw new Exception("Dont have enough balance.");
            }
            var user = _userService.GetUSerByID(idUser);
            md.IdUser = idUser;
            md.Address = user.PublicAddress;
            md.InsertDate = DateTime.Now;
            md.Debit = gobiValue;
            md.Fee = fee;
            md.Balance = gobi - gobiValue;
            //md.Message = msg;
            md.Status = FinanceTransactionStatusEnum.Confirmed;
            md.Save();
            _glogService.AddLog(idUser, msg, logType);
            md.UpdateGobi(idUser, -gobiValue);
        }

        private string StatusToText(FinanceTransactionStatusEnum status)
        {
            string msg = "Unknow";
            switch (status)
            {
                case FinanceTransactionStatusEnum.Start:
                    msg = "Start";
                    break;
                case FinanceTransactionStatusEnum.OutOfLimit:
                    msg = "Out of Limit";
                    break;
                case FinanceTransactionStatusEnum.OutOfBalance:
                    msg = "Out of Balance";
                    break;
                case FinanceTransactionStatusEnum.InCooldown:
                    msg = "In Cooldown";
                    break;
                case FinanceTransactionStatusEnum.Processing:
                    msg = "Processing";
                    break;
                case FinanceTransactionStatusEnum.Confirmed:
                    msg = "Confirmed";
                    break;
                case FinanceTransactionStatusEnum.ErrorRunTime:
                    msg = "Runtime Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorBlockchain:
                    msg = "Blockchain Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorInvalidContract:
                    msg = "Invalid Contract Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorInvalidSender:
                    msg = "Invalid Sender Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorInvalidReceiver:
                    msg = "Invalid Receiver Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorInvalidValue:
                    msg = "Invalid Value Error";
                    break;
                case FinanceTransactionStatusEnum.ErrorAlreadyProcessed:
                    msg = "Transaction already processed";
                    break;
            }
            return msg;
        }

        private FinanceTransacionInfo ModelToInfo(IFinanceTransactionModel md)
        {
            return new FinanceTransacionInfo
            {
                Id = md.Id,
                IdUser = md.IdUser,
                Address = md.Address,
                InsertDate = md.InsertDate,
                Credit = md.Credit,
                Debit = md.Debit,
                Fee = md.Fee,
                Balance = md.Balance,
                Gas = md.Gas,
                Status = (int) md.Status,
                Message = md.Message,
                TxHash = md.TxHash,
                StatusMsg = StatusToText(md.Status),
                Success = (md.Status == FinanceTransactionStatusEnum.Confirmed)
            };
        }

        private string GetContractAddress(FinanceTokenEnum token)
        {
            string r = string.Empty;
            switch (token)
            {
                case FinanceTokenEnum.GOBI:
                    //r = _gobiWithdraw.GetContractAddress();
                    break;
            }
            return r;
        }

        public async Task<FinanceInfo> GetFinance(long idUser)
        {
            var md = _financeFactory.BuildFinanceModel();
            md.IdUser = idUser;

            var user = _userService.GetUSerByID(idUser);

            //var gobi = await _gobiWithdraw.GetBalanceOf();
            //var gobiBalance = BigInteger.Divide(gobi, new BigInteger(Math.Pow(10, 18)));
            var gobiBalance = BigInteger.Divide(0, new BigInteger(Math.Pow(10, 18)));

            var lastWithdrawal = md.GetLastWithdrawl();

            return new FinanceInfo
            {
                PublicAddress = user.PublicAddress,
                GobiOnCloudWallet = GetGobiOnCloud(user.Id),
                GobiOnMetamask = await GetGobiOnMetamask(user.PublicAddress),
                DaysForNoFee = DAYS_FOR_NO_FEE,
                LastWithdrawl = lastWithdrawal,
                NextWithdrawlWithoutFee = lastWithdrawal.HasValue ? lastWithdrawal.Value.AddDays(DAYS_FOR_NO_FEE) : null,
                HotWalletGobi = (decimal)gobiBalance,
                //HotWalletBNB = await _gobiWithdraw.GetBalanceBnbOf(),
                MinimalGobi = MIN_GOBI,
                MinimalGobiFee = MIN_GOBI_FEE,
                WithdrawalMin = GOBI_WITHDRAWAL_MIN,
                WithdrawalLimit = GOBI_WITHDRAWAL_LIMIT,
                MaxFeePercent = MAX_FEE_PERCENT,
                CanWithdrawal = md.CanWithdrawal(user.Id)
            };
        }

        private decimal _CalculateFee(DateTime? lastWithdrawal, decimal value)
        {
            if (!lastWithdrawal.HasValue)
            {
                return MIN_GOBI_FEE;
            }
            var withdrawalDate = lastWithdrawal.Value.AddDays(DAYS_FOR_NO_FEE);
            if (withdrawalDate <= DateTime.Now)
            {
                return MIN_GOBI_FEE;
            }
            var inSec = withdrawalDate.Subtract(DateTime.Now).TotalSeconds;
            var totalSec = DAYS_FOR_NO_FEE * (60 * 60 * 24);
            decimal percent = (decimal)MAX_FEE_PERCENT * (decimal)inSec / (decimal)totalSec;
            var fee = Math.Ceiling((value / 100.0M) * percent);
            if (fee < MIN_GOBI_FEE)
            {
                return MIN_GOBI_FEE;
            }
            return fee;
        }

        public decimal CalculateFee(FinanceTokenEnum token, long idUser, decimal value)
        {
            var md = _financeFactory.BuildFinanceModel();
            md.IdUser = idUser;
            var lastWithdrawal = md.GetLastWithdrawl();
            return _CalculateFee(lastWithdrawal, value);
        }

        public async Task CheckContracts()
        {
            var md = _financeFactory.BuildFinanceModel();
            var transactions = md.GetAll();
            var total = transactions.Count();
            var i = 1;
            foreach(var transaction in transactions)
            {
                try
                {
                    Console.WriteLine("Progresso: " + i + "/" + total);
                    var txStatus = await GetTransaction(transaction);
                    if (string.Compare(_configuration["Contract:GobiAddress"].ToLower(), txStatus.ContractAddress) != 0)
                    {
                        Console.WriteLine("Contrato inválido: Usuário: " + transaction.IdUser);
                    }
                }
                catch(Exception err)
                {
                    Console.WriteLine("Erro na consulta: " + err.Message);
                }
                i++;
            }
        }

        public async Task<FinanceTransacionInfo> ConfirmDeposit(DepositInfo deposit)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var user = _userService.GetUSerByID(deposit.IdUser);
                    var md = _financeFactory.BuildFinanceModel();
                    md.SavePendingTransaction(deposit.IdUser, deposit.TransactionHash, deposit.Value);
                    md.IdUser = user.Id;
                    md.Address = user.PublicAddress;
                    md.InsertDate = DateTime.Now;
                    md.TxHash = deposit.TransactionHash;
                    md.Credit = deposit.Value;
                    md.Balance = md.GetGobi(user.Id);
                    var tx = md.GetByConfirmedTransationHash(deposit.TransactionHash);
                    if (tx != null)
                    {
                        md.Message = string.Format(TRANSACTION_ALREADY_PROCESSED, tx.InsertDate);
                        md.Status = FinanceTransactionStatusEnum.ErrorAlreadyProcessed;
                        md.Save();
                        trans.Commit();
                        return ModelToInfo(md);
                    }
                    try
                    {
                        var txStatus = await GetTransaction(md);
                        if (txStatus.GasUsed.HasValue)
                        {
                            md.Gas = txStatus.GasUsed.Value;
                        }
                        switch (txStatus.Status)
                        {
                            case TransactionStatusEnum.Succeesed:
                                var creditValue = new BigInteger(deposit.Value * (decimal)Math.Pow(10, 18));
                                if (string.Compare(user.PublicAddress, txStatus.FromAddress, true) != 0)
                                {
                                    md.Message = string.Format(ERROR_INVALID_SENDER, txStatus.FromAddress);
                                    md.Status = FinanceTransactionStatusEnum.ErrorInvalidSender;
                                    md.Save();
                                }
                                else if (string.Compare(_configurationService.GetWithdrawAddress(), txStatus.ToAddress, true) != 0)
                                {
                                    md.Message = string.Format(ERROR_INVALID_RECEIVER, txStatus.ToAddress);
                                    md.Status = FinanceTransactionStatusEnum.ErrorInvalidReceiver;
                                    md.Save();
                                }
                                else if (creditValue != txStatus.Value)
                                {
                                    md.Message = string.Format(ERROR_INVALID_VALUE, txStatus.Value);
                                    md.Status = FinanceTransactionStatusEnum.ErrorInvalidValue;
                                    md.Save();
                                }
                                else if (string.Compare(_configuration["Contract:GobiAddress"].ToLower(), txStatus.ContractAddress) != 0)
                                {
                                    md.Message = string.Format(ERROR_INVALID_CONTRACT, txStatus.ContractAddress);
                                    md.Status = FinanceTransactionStatusEnum.ErrorInvalidContract;
                                    md.Save();
                                }
                                else
                                {
                                    md.Balance += md.Credit;
                                    md.Status = FinanceTransactionStatusEnum.Confirmed;
                                    md.TxHash = txStatus.TransactionHash;
                                    md.Save();
                                    var msg = string.Format("Amount of __GOBI({0})__ was deposited.", md.Credit);
                                    _glogService.AddLog(user.Id, msg, LogType.Finance);
                                    md.UpdateGobi(user.Id, md.Credit);
                                    ActiveWithdrawal(user.Id);
                                }
                                break;
                            case TransactionStatusEnum.Failed:
                                md.Message = txStatus.MessageError;
                                md.Status = FinanceTransactionStatusEnum.ErrorBlockchain;
                                md.Save();
                                break;
                            case TransactionStatusEnum.Processing:
                                md.Status = FinanceTransactionStatusEnum.Processing;
                                md.Save();
                                break;
                        }

                    }
                    catch (Exception err)
                    {
                        md.Message = err.Message;
                        md.Status = FinanceTransactionStatusEnum.ErrorRunTime;
                        md.Save();
                    }
                    trans.Commit();
                    return ModelToInfo(md);
                }
                catch(Exception err)
                {
                    trans.Rollback();
                    throw;
                }
            }
            
        }

        public async Task<FinanceTransacionInfo> Withdrawl(FinanceRequestInfo request)
        {
            var md = _financeFactory.BuildFinanceModel();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var user = _userService.GetUSerByID(request.IdUser);
                    var finance = await GetFinance(user.Id);

                    if (!finance.CanWithdrawal)
                    {
                        throw new Exception("You are not allowed to make a withdrawal.");
                    }

                    var feeValue = CalculateFee(FinanceTokenEnum.GOBI, user.Id, request.Value);
                    var withdrawalValue = request.Value - feeValue;

                    if (request.Value < finance.WithdrawalMin)
                    {
                        throw new Exception(string.Format("Minimum withdrawal amount is {0}.", finance.WithdrawalMin));
                    }

                    if ((finance.GobiOnCloudWallet - request.Value) < finance.MinimalGobi)
                    {
                        throw new Exception(string.Format("You cannot have a balance lower than {0}.", finance.MinimalGobi));
                    }

                    if (finance.LastWithdrawl >= DateTime.UtcNow.AddHours(-1))
                    {
                        throw new Exception(string.Format("You cannot withdraw in an interval shorter than {0}.", "1 hour"));
                    }

                    md.IdUser = user.Id;
                    md.Address = user.PublicAddress;
                    md.InsertDate = DateTime.Now;
                    md.Debit = withdrawalValue;
                    md.Fee = feeValue;
                    md.Balance = md.GetGobi(user.Id);
                    md.Withdrawal = true;
                    if (md.Debit > finance.WithdrawalLimit)
                    {
                        md.Message = "Withdrawal is out of limit";
                        md.Status = FinanceTransactionStatusEnum.OutOfLimit;
                        md.Save();
                        return ModelToInfo(md);
                    }

                    if (md.Debit >= finance.GobiOnCloudWallet)
                    {
                        md.Status = FinanceTransactionStatusEnum.OutOfBalance;
                        md.Message = string.Format("You dont have {0:N0} GOBI to withdraw!", md.Credit);
                        md.Save();
                        return ModelToInfo(md);
                    }

                    if (request.Value > finance.HotWalletGobi)
                    {
                        md.Message = string.Format("Cashout pool has no balance ({0}).", request.Value);
                        md.Status = FinanceTransactionStatusEnum.InCooldown;
                        md.Save();
                        return ModelToInfo(md);
                    }
                    md.UpdateGobi(md.IdUser, -(decimal)request.Value);
                    var debitValue = new BigInteger((double)withdrawalValue * Math.Pow(10, 18));
                    //var txStatus = await _gobiWithdraw.Transfer(md.Address, debitValue);
                    ITransactionStatusModel txStatus = null;
                    md.TxHash = txStatus.TransactionHash;

                    if (txStatus.GasUsed.HasValue)
                    {
                        md.Gas = txStatus.GasUsed.Value;
                    }
                    switch (txStatus.Status)
                    {
                        case TransactionStatusEnum.Succeesed:
                            if (string.Compare(_configurationService.GetWithdrawAddress(), txStatus.FromAddress, true) != 0)
                            {
                                md.Message = string.Format(ERROR_INVALID_SENDER, txStatus.FromAddress);
                                md.Status = FinanceTransactionStatusEnum.ErrorInvalidSender;
                                md.Balance -= (decimal)request.Value;
                                md.Save();
                                var msg = string.Format("Amount of __GOBI({0})__ was withdrawl.", debitValue);
                                _glogService.AddLog(md.IdUser, msg, LogType.Finance);
                            }
                            else if (string.Compare(user.PublicAddress, txStatus.ToAddress, true) != 0)
                            {
                                md.Message = string.Format(ERROR_INVALID_RECEIVER, txStatus.ToAddress);
                                md.Status = FinanceTransactionStatusEnum.ErrorInvalidReceiver;
                                md.Balance -= (decimal)request.Value;
                                md.Save();
                                var msg = string.Format("Amount of __GOBI({0})__ was withdrawl.", debitValue);
                                _glogService.AddLog(md.IdUser, msg, LogType.Finance);
                            }
                            else if (debitValue != txStatus.Value)
                            {
                                md.Message = string.Format(ERROR_INVALID_VALUE, txStatus.Value);
                                md.Status = FinanceTransactionStatusEnum.ErrorInvalidValue;
                                md.Balance -= (decimal)request.Value;
                                md.Save();
                                var msg = string.Format("Amount of __GOBI({0})__ was withdrawl.", debitValue);
                                _glogService.AddLog(md.IdUser, msg, LogType.Finance);
                            }
                            else
                            {
                                md.Status = FinanceTransactionStatusEnum.Confirmed;
                                md.Balance -= (decimal)request.Value;
                                md.Save();
                                var msg = string.Format("Amount of __GOBI({0})__ was withdrawl.", debitValue);
                                _glogService.AddLog(md.IdUser, msg, LogType.Finance);
                            }
                            transaction.Commit();
                            break;
                        case TransactionStatusEnum.Failed:
                            transaction.Rollback();
                            md.Message = txStatus.MessageError;
                            md.Status = FinanceTransactionStatusEnum.ErrorBlockchain;
                            md.Save();
                            break;
                        case TransactionStatusEnum.Processing:
                            transaction.Rollback();
                            md.Status = FinanceTransactionStatusEnum.Processing;
                            md.Save();
                            break;
                    }

                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    md.Message = err.Message;
                    md.Status = FinanceTransactionStatusEnum.ErrorRunTime;
                    md.Save();
                }
            }
            return ModelToInfo(md);
        }
    }
}
