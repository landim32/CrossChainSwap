using Auth.Domain.Interfaces.Services;
using Core.Domain;
using Core.Domain.Cloud;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Mining;
using BTCSTXSwap.DTO.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class MiningService : IMiningService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGLogService _glog;
        private readonly IMiningDomainFactory _miningFactory;
        private readonly IMiningRewardDomainFactory _miningRewardFactory;
        private readonly IMiningHistoryDomainFactory _miningHistoryFactory;
        private readonly IUserService _userService;
        private readonly IGoblinService _goblinService;
        private readonly IGoblinMiningService _goblinMiningService;
        private readonly IFinanceService _financeService;
        private readonly IGoboxService _goboxService;


        private const int MAX_GOBLINS = 16;
        private const string CLAIM_NO_FEE = "An amount of __GOBI({0})__ GOBI was claimed, with no fees.";
        private const string CLAIM_FEE = "An amount of __GOBI({0})__ has been claimed, discounted __GOBI({1})__ ({2}% fee)";
        private const string MSG_CLAIMED_BOX = "__USER({0})__ claimed mining ranking reward of {1}.";


        public MiningService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGLogService glog,
            IMiningDomainFactory miningFactory,
            IMiningRewardDomainFactory miningRewardFactory,
            IMiningHistoryDomainFactory miningHistoryFactory,
            IUserService userService,
            IGoblinService goblinService,
            IGoblinMiningService goblinMiningService,
            IFinanceService financeService,
            IGoboxService goboxService
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _glog = glog;
            _userService = userService;
            _miningFactory = miningFactory;
            _miningRewardFactory = miningRewardFactory;
            _miningHistoryFactory = miningHistoryFactory;
            _goblinService = goblinService;
            _goblinMiningService = goblinMiningService;
            _financeService = financeService;
            _goboxService = goboxService;
        }

        private MiningRankingInfo ModelToRaking(IMiningModel md, ref int rank)
        {
            var mr = new MiningRankingInfo { 
                Id = md.Id,
                IdUser = md.IdUser,
                Name = md.Name,
                GoblinQtde = md.GoblinQtde,
                Ranking = rank,
                HashPower = md.HashPower,
                HashforWeek = md.HashforWeek,
                HashforMonth = md.HashForMonth
            };
            rank++;
            return mr;
        }

        private MiningRewardInfo ModelToReward(IMiningRewardModel md)
        {
            return new MiningRewardInfo
            {
                Id = md.Id,
                IdUser = md.IdUser,
                InsertDate = md.InsertDate,
                InsertDateStr = md.InsertDate.ToString("MM/dd/yyyy"),
                ClaimDate = md.ClaimDate,
                GobiValue = md.GobiValue,
                Credit = md.Credit,
                Fee = md.Fee,
                PercentFee = CalculateFee(md.InsertDate),
                Status = (int)md.Status
            };
        }

        private MiningInfo ModelToInfo(IMiningModel md)
        {
            MiningInfo info = null;
            if (md != null)
            {
                info = new MiningInfo
                {
                    Id = md.Id,
                    IdUser = md.IdUser,
                    LastMining = md.LastMining,
                    Name = md.Name,
                    HashPower = md.HashPower,
                    GoblinQtde = md.GoblinQtde,
                    RewardPerMonth = md.RewardPerMonth,
                    RewardPerSecond = md.RewardPerSecond,
                    Gobi = md.Gobi,
                    //Ranking = ranking
                };
            }
            else
            {
                info = new MiningInfo
                {
                    Id = -1,
                    IdUser = 0,
                    LastMining = DateTime.MinValue,
                    Name = "",
                    HashPower = 0,
                    GoblinQtde = 0,
                    RewardPerMonth = 0,
                    RewardPerSecond = 0,
                    Gobi = 0,
                    //Ranking = -1
                };
            }
            return info;
        }

        public long GetHashPower(long idUser)
        {
            return _miningFactory.BuildMiningModel().GetHashPower(idUser);
        }

        public MiningInfo GetMining(long idUser)
        {
            var md = _miningFactory.BuildMiningModel();
            var minHashPower = md.MinHashPower();
            var totalHashPower = md.TotalHashPower();
            var dailyReward = md.DailyReward();

            //var user = _userService.GetUSerByID(idUser);

            //await UploadImage(GenerateImage(idUser, userAddress), userAddress);

            var info = ModelToInfo(md.GetMining(idUser));
            info.MinHashPower = minHashPower;
            info.TotalHashPower = totalHashPower;
            info.DailyReward = dailyReward;

            info.Goblins = _goblinService.ListMiningByCursor(idUser, 0).Goblins.ToList();
            return info;
        }

        private DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        private DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }

        private DateTime LastDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        public MiningListResult ListRanking(long idUser, MiningRewardTypeEnum miningType)
        {
            var md = _miningFactory.BuildMiningModel();
            var minHashPower = md.MinHashPower();
            var totalHashPower = md.TotalHashPower();
            var dailyReward = md.DailyReward();

            var user = _userService.GetUSerByID(idUser);

            DateTime? rewardDate = null;
            var rankings = new List<MiningRankingInfo>();
            switch (miningType)
            {
                case MiningRewardTypeEnum.Weekly:
                    rewardDate = LastDayOfWeek(DateTime.Today).Add(new TimeSpan(23, 59, 59));

                    var q1 = md.ListRanking(0)
                        .OrderByDescending(x => x.HashforWeek)
                        .ToList();
                    var firstSix = q1.Take(6).ToList();
                    var r1 = 1;
                    rankings.AddRange(firstSix.Select(x => ModelToRaking(x, ref r1)));
                    var me1 = q1.Where(x => x.IdUser == idUser).FirstOrDefault();
                    if (me1 != null)
                    {
                        if (!firstSix.Contains(me1))
                        {
                            r1 = q1.IndexOf(me1) + 1;
                            rankings.Add(ModelToRaking(me1, ref r1));
                        }
                    }
                    break;
                case MiningRewardTypeEnum.Monthly:
                    rewardDate = LastDayOfMonth(DateTime.Today).Add(new TimeSpan(23, 59, 59));
                    var q2 = md.ListRanking(0)
                        .OrderByDescending(x => x.HashForMonth)
                        .ToList();
                    var firstTen = q2.Take(10).ToList();
                    var r2 = 1;
                    rankings.AddRange(firstTen.Select(x => ModelToRaking(x, ref r2)));
                    var me2 = q2.Where(x => x.IdUser == idUser).FirstOrDefault();
                    if (me2 != null)
                    {
                        if (!firstTen.Contains(me2))
                        {
                            r2 = q2.IndexOf(me2) + 1;
                            rankings.Add(ModelToRaking(me2, ref r2));
                        }
                    }
                    break;
                case MiningRewardTypeEnum.Top100:
                    int r3 = 1;
                    rankings.AddRange(md.ListRanking(100)
                        .OrderByDescending(x => x.HashPower)
                        .Select(x => ModelToRaking(x, ref r3))
                        .ToList()
                    );
                    break;
            }
            return new MiningListResult {
                RewardDate = rewardDate,
                Minings = rankings 
            };
        }

        public IList<MiningRewardInfo> ListReward(long idUser)
        {
            var md = _miningRewardFactory.BuildMiningRewardModel();
            return md
                .List(idUser, 10)
                .Select(x => ModelToReward(x))
                .ToList();
        }

        private int CalculateFee(DateTime insertDate)
        {
            int percentFee = 0;

            var time = DateTime.Today.Subtract(insertDate.Date);
            switch (time.Days)
            {
                case 0:
                    percentFee = 70;
                    break;
                case 1:
                    percentFee = 60;
                    break;
                case 2:
                    percentFee = 50;
                    break;
                case 3:
                    percentFee = 40;
                    break;
                case 4:
                    percentFee = 30;
                    break;
                case 5:
                    percentFee = 20;
                    break;
                case 6:
                    percentFee = 10;
                    break;
                default:
                    percentFee = 0;
                    break;
            }
            return percentFee;
        }

        public void ClaimReward(long idReward)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var md = _miningRewardFactory.BuildMiningRewardModel().GetById(idReward);

                    if (md.Status == MiningRewardStatusEnum.Claimed)
                        throw new Exception("Already claimed !");

                    decimal percentFee = (decimal)CalculateFee(md.InsertDate) / 100.0M;

                    md.Fee = md.GobiValue * percentFee;
                    md.Credit = md.GobiValue - md.Fee;
                    md.ClaimDate = DateTime.Now;
                    md.Status = MiningRewardStatusEnum.Claimed;
                    md.Update();

                    string msg;
                    if (md.Fee > 0)
                    {
                        msg = string.Format(CLAIM_FEE, md.Credit, md.Fee, string.Format("{0:N0}", percentFee * 100));
                    }
                    else
                    {
                        msg = string.Format(CLAIM_NO_FEE, md.Credit);
                    }
                    if(md.Credit > 0)
                        _financeService.CreditGobi(md.IdUser, md.Credit, md.Fee, msg, Core.LogType.Mining);
                    transaction.Commit();
                }
                catch(Exception err)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        public int MinHashPower()
        {
            return _miningFactory.BuildMiningModel().MinHashPower();
        }

        public bool StartMining(long idUser, long tokenId)
        {
            var goblin = _goblinService.GetGoblinByToken(tokenId);
            if (goblin.IdUser != idUser) {
                throw new Exception("You are not owner of this goblin.");
            }
            if(_miningFactory.BuildMiningModel().GoblinMining(idUser) >= MAX_GOBLINS)
            {
                throw new Exception(string.Format("You can only have {0} goblins mining at the same time", MAX_GOBLINS));
            }
            if (goblin.Status != (int)GoblinStatusEnum.Minning) {
                if (!goblin.IsAvaliable)
                {
                    throw new Exception("Goblin is not avaliable.");
                }
                _goblinService.UpdateStatus(tokenId, GoblinStatusEnum.Minning);
                if (!_goblinMiningService.HasRecharge(goblin.Id))
                {
                    _goblinMiningService.DoRecharge(idUser, goblin.Id, true);
                }
                else
                    _goblinMiningService.RestartGoblinCharge(goblin.Id);
                this.RefreshMining();
                _glog.AddLog(idUser, string.Format("__GOBLIN({0})__ stared mining.", tokenId), Core.LogType.Mining);
                return true;
            }
            return true;
        }

        public bool StopMining(long idUser, long tokenId)
        {
            var goblin = _goblinService.GetGoblinByToken(tokenId);
            if (goblin.IdUser != idUser)
            {
                throw new Exception("You are not owner of this goblin.");
            }
            if (goblin.Status != (int)GoblinStatusEnum.Minning)
            {
                throw new Exception("Goblin is not mining.");
            }
            //await GenerateImage(goblin);
            _goblinService.UpdateStatus(tokenId, GoblinStatusEnum.Tired, DateTime.Now.AddHours(1));
            _goblinMiningService.StopGoblinCharge(goblin.Id);
            this.RefreshMining();
            _glog.AddLog(idUser, string.Format("__GOBLIN({0})__ stop mining.", tokenId), Core.LogType.Mining);
            return true;
        }
        public long TotalHashPower()
        {
            return _miningFactory.BuildMiningModel().TotalHashPower();
        }
        public int TotalRewardPerDay()
        {
            return _miningFactory.BuildMiningModel().TotalHashPower();
        }
        public void RefreshMining()
        {
            _miningFactory.BuildMiningModel().RefreshMining();
        }

        private MiningHistoryInfo ModelToHistory(IMiningHistoryModel md)
        {
            return new MiningHistoryInfo
            {
                Id = md.Id,
                IdUser = md.IdUser,
                Name = md.Name,
                RewardType = ((char)md.RewardType).ToString(),
                RewardDate = md.RewardDate,
                Ranking = md.Ranking,
                GoblinQtde = md.GoblinQtde,
                HashPower = md.HashPower,
                HashForWeek = md.HashForWeek,
                HashForMonth = md.HashForMonth,
                BoxType = (int)md.BoxType,
                Claimed = md.Claimed
    };
        }

        public IList<DateTime> ListHistoryDate(MiningRewardTypeEnum miningType)
        {
            var md = _miningHistoryFactory.BuildMiningHistoryModel();
            return md.ListHistoryDate(miningType).ToList();
        }
        public IList<MiningHistoryInfo> ListHistory(MiningRewardTypeEnum miningTypeEnum, DateTime rewardDate)
        {
            var md = _miningHistoryFactory.BuildMiningHistoryModel();
            return md.ListHistory(miningTypeEnum, rewardDate)
                .Select(x => ModelToHistory(x))
                .ToList();
        }
        public IList<MiningHistoryInfo> ListHistoryByUser(long idUser)
        {
            var md = _miningHistoryFactory.BuildMiningHistoryModel();
            return md.ListHistoryByUser(idUser)
                .OrderByDescending(x => x.RewardDate)
                .Select(x => ModelToHistory(x))
                .ToList();
        }
        public void ClaimRankingReward(long idUser, long IdMiningHistory)
        {
            var md = _miningHistoryFactory.BuildMiningHistoryModel().GetById(IdMiningHistory);
            if (md == null)
            {
                throw new Exception("Mining history not found.");
            }
            if (md.Claimed)
            {
                throw new Exception("Reward has already been claimed.");
            }
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _goboxService.Credit(idUser, md.BoxType, 1, false);
                    md.DoClaimed(IdMiningHistory);
                    string msgFrom = string.Format(MSG_CLAIMED_BOX, idUser, md.RewardDate.ToString("dd/MMM"));
                    _glog.AddLog(idUser, msgFrom, LogType.Transfer);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}