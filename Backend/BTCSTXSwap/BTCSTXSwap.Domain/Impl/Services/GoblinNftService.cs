using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Core.Domain;
using Core.Domain.Withdraw;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinNftService : IGoblinNftService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoblinDomainFactory _goblinFactory;
        private readonly IUserDomainFactory _userFactory;
        private readonly IGoblinService _goblinService;
        private readonly IFinanceService _financeService;
        private readonly IGLogService _glogService;
        //private readonly IGoblinContract _goblinContract;

        const string LOG_DEPOSIT_ERROR = "__GOBLIN({0})__ is not in 'Claimed' status on deposit";
        const string MSG_TRANSFER_FROM = "__USER({0})__ transfer __GOBLIN({1})__ to you.";

        public GoblinNftService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGoblinDomainFactory goblinFactory,
            IUserDomainFactory userFactory,
            IGoblinService goblinService,
            IFinanceService financeService,
            IGLogService glogService//,
            //IGoblinContract goblinContract
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goblinFactory = goblinFactory;
            _userFactory = userFactory;
            _goblinService = goblinService;
            _financeService = financeService;
            _glogService = glogService;
            //_goblinContract = goblinContract;
        }

        public async Task<bool> Mint(long idUser, long TokenId)
        {
            var goblin = _goblinFactory.BuildGoblinModel().GetByTokenId(TokenId);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            if (goblin.IdUser != idUser)
            {
                throw new Exception("Goblin is not yours");
            }
            if (!goblin.IsAvaliable())
            {
                throw new Exception("Goblin not avaliable");
            }
            if (goblin.Minted)
            {
                throw new Exception("Goblin has already been minted");
            }
            var user = _userFactory.BuildUserModel().GetById(idUser, _userFactory);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    try {
                        /*
                        var ownerAddress = await _goblinContract.OwnerOf(TokenId);
                        if (!string.IsNullOrEmpty(ownerAddress))
                        {
                            throw new Exception("Goblin has already been minted");
                        }
                        */
                    }
                    catch (Exception)
                    {
                        // Nothing
                    }
                    //var tx = await _goblinContract.Mint(user.PublicAddress, TokenId);
                    ITransactionStatusModel tx = null;
                    if (tx.Status == TransactionStatusEnum.Failed)
                    {
                        throw new Exception(tx.MessageError);
                    }
                    if (tx.Status == TransactionStatusEnum.Processing)
                    {
                        throw new Exception("Mint has not been processed yet");
                    }
                    if (tx.Status != TransactionStatusEnum.Succeesed)
                    {
                        throw new Exception("Error unknow on mint");
                    }
                    const int MINT_COST = 20;
                    const string MSG_MINT = "__GOBLIN({0})__ as minted on transaction __TX({1})__ for __GOBI({2})__.";
                    var msg = string.Format(MSG_MINT, goblin.Id, tx.TransactionHash, MINT_COST);
                    _financeService.DebitGobi(idUser, MINT_COST, null, msg, LogType.Mint);
                    goblin.DoMint(idUser);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> Claim(long idUser, long TokenId)
        {
            var goblin = _goblinFactory.BuildGoblinModel().GetByTokenId(TokenId);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            if (goblin.IdUser != idUser)
            {
                throw new Exception("Goblin is not yours");
            }
            if (!goblin.IsAvaliable())
            {
                throw new Exception("Goblin not avaliable");
            }
            if (!goblin.Minted)
            {
                throw new Exception("Goblin has not minted");
            }
            var user = _userFactory.BuildUserModel().GetById(idUser, _userFactory);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    try
                    {
                        /*
                        var ownerAddress = await _goblinContract.OwnerOf(TokenId);
                        if (!string.IsNullOrEmpty(ownerAddress))
                        {
                            throw new Exception("Goblin has already been minted");
                        }
                        */
                    }
                    catch (Exception)
                    {
                        // Nothing
                    }
                    //var tx = await _goblinContract.Transfer(user.PublicAddress, TokenId);
                    ITransactionStatusModel tx = null;
                    if (tx.Status == TransactionStatusEnum.Failed)
                    {
                        throw new Exception(tx.MessageError);
                    }
                    if (tx.Status == TransactionStatusEnum.Processing)
                    {
                        throw new Exception("Mint has not been processed yet");
                    }
                    if (tx.Status != TransactionStatusEnum.Succeesed)
                    {
                        throw new Exception("Error unknow on mint");
                    }
                    const int TRANSFER_COST = 10;
                    const string MSG_MINT = "__GOBLIN({0})__ as transfer on transaction __TX({1})__ for __GOBI({2})__.";
                    var msg = string.Format(MSG_MINT, goblin.Id, tx.TransactionHash, TRANSFER_COST);
                    _financeService.DebitGobi(idUser, TRANSFER_COST, null, msg, LogType.Mint);
                    goblin.Claimed(idUser);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> ConfirmDeposit(long idUser, long TokenId, string transactionHash)
        {
            //var txStatus = await _goblinContract.GetTransaction(transactionHash);
            ITransactionStatusModel txStatus = null;
            switch (txStatus.Status)
            {
                case TransactionStatusEnum.Succeesed:
                    var goblin = _goblinFactory.BuildGoblinModel().GetByTokenId(TokenId, true);
                    if (goblin == null)
                    {
                        throw new Exception("Goblin not found");
                    }
                    using (var trans = _unitOfWork.BeginTransaction())
                    {
                        try
                        {
                            if (goblin.Status != GoblinStatusEnum.Claimed)
                            {
                                string msgError = string.Format(LOG_DEPOSIT_ERROR, goblin.Id);
                                _glogService.AddLog(idUser, msgError, LogType.Error);
                            }
                            /*
                            var ownerAddress = await _goblinContract.OwnerOf(TokenId);
                            if (string.Compare(_goblinContract.getWithdrawalAddress(), ownerAddress, true) != 0)
                            {
                                throw new Exception("Goblin not on withdraw wallet.");
                            }
                            */
                            goblin.Deposit(idUser);
                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                    break;
                case TransactionStatusEnum.Failed:
                    throw new Exception(txStatus.MessageError);
                    break;
                case TransactionStatusEnum.Processing:
                    throw new Exception("Deposit goblin under processing yet");
                    break;
            }
            return true;
        }

        public async Task<IList<GoblinInfo>> List(long idUser)
        {
            var user = _userFactory.BuildUserModel().GetById(idUser, _userFactory);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var goblins = new List<GoblinInfo>();
            //var balance = await _goblinContract.BalanceOf(user.PublicAddress);
            BigInteger balance = 0;
            for (BigInteger i = 0; i < balance; i++)
            {
                /*
                var tokenIdBI = await _goblinContract.TokenOfOwnerByIndex(user.PublicAddress, i);
                long tokenId = long.Parse(tokenIdBI.ToString());
                var goblin = _goblinFactory.BuildGoblinModel().GetByTokenId(tokenId, true);
                if (goblin != null)
                {
                    goblins.Add(_goblinService.ModelToInfo(goblin));
                }
                */
            }
            return goblins;
        }
    }
}
