using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Cloud;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Mining;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinMiningService : IGoblinMiningService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogCore _log;
        private readonly IRechargeDomainFactory _rechargeFactory;
        private readonly IGoblinSpriteDomainFactory _miningSpriteFactory;
        private readonly IAssetsProviders _assetsProvider;
        private readonly IGLogService _glog;
        private readonly IFinanceService _financeService;

        private const string LOG_RECHARGE_GOBLIN = "__GOBLIN({0})__  was recharged by __GOBI({1})__.";
        private const string LOG_RECHARGE_ALL = "All goblins was recharged by __GOBI({0})__.";

        public GoblinMiningService(
            IConfiguration configuration, 
            IUnitOfWork unitOfWork, 
            ILogCore log,
            IRechargeDomainFactory rechargeFactory,
            IGoblinSpriteDomainFactory miningSpriteFactory,
            IAssetsProviders assetsProvider, 
            IGLogService glog, 
            IFinanceService financeService
        )
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _log = log;
            _rechargeFactory = rechargeFactory;
            _miningSpriteFactory = miningSpriteFactory;
            _assetsProvider = assetsProvider;
            _glog = glog;
            _financeService = financeService;
        }

        public GoblinEnergyMiningInfo BuildGoblinMining(long idGoblin)
        {
            var reFactory = _rechargeFactory.BuildGoblinEnergyModel();
            var goblinEnergy = reFactory.GetGoblin(idGoblin);
            if (goblinEnergy == null)
                return null;
            goblinEnergy.EnergyInfo.ChargeDuration = goblinEnergy.ChargeDuration;
            return goblinEnergy.EnergyInfo;
        }

        public IEnumerable<GoblinEnergyMiningInfo> BuildGoblinMiningList(long userId)
        {
            var reFactory = _rechargeFactory.BuildGoblinEnergyModel();
            var goblinEnergyList = reFactory.ListUserGoblin(userId);
            return goblinEnergyList.Select(x => {
                x.EnergyInfo.ChargeDuration = x.ChargeDuration;
                return x.EnergyInfo;
            });
        }

        public GoblinEnergyMiningInfo DoRecharge(long userId, long idGoblin, bool free = false)
        {
            var reFactory = _rechargeFactory.BuildGoblinEnergyModel();
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var rechargeValue = reFactory.DoRecharge(idGoblin, userId, free);
                    if(!free)
                        _financeService.DebitGobi(userId, rechargeValue, null, string.Format(LOG_RECHARGE_GOBLIN, idGoblin, Math.Round(rechargeValue, 2)), Core.LogType.Recharge);
                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    throw;
                }
            }
            var ret = BuildGoblinMining(idGoblin);
            return ret;
        }
        public bool HasRecharge(long idGoblin)
        {
            return _rechargeFactory.BuildGoblinEnergyModel().HasRecharge(idGoblin);
        }

        public void RestartGoblinCharge(long idGoblin)
        {
            _rechargeFactory.BuildGoblinEnergyModel().RestartCharge(idGoblin);
        }

        public void StopGoblinCharge(long idGoblin)
        {
            _rechargeFactory.BuildGoblinEnergyModel().StopCharge(idGoblin);
        }

        public void RechargeAll(long idUser)
        {
            var reFactory = _rechargeFactory.BuildGoblinEnergyModel();
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var rechargeCost = reFactory.RechargeAll(idUser);
                    _financeService.DebitGobi(idUser, rechargeCost, null, string.Format(LOG_RECHARGE_ALL, Math.Round(rechargeCost, 2)), Core.LogType.Recharge);
                    trans.Commit();
                    return;
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
