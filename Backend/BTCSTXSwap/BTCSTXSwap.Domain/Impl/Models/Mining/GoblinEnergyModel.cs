using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Mining;
using System;
using System.Collections.Generic;

namespace BTCSTXSwap.Domain.Impl.Models.Mining
{
    public class GoblinEnergyModel : IGoblinEnergyModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRechargeDomainFactory _rechargeFactory;
        private readonly IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory> _rechargeRepository;

        public GoblinEnergyModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IRechargeDomainFactory rechargeFactory,
            IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory> rechargeRepository
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _rechargeFactory = rechargeFactory;
            _rechargeRepository = rechargeRepository;
            EnergyInfo = new GoblinEnergyMiningInfo();
        }

        public GoblinEnergyMiningInfo EnergyInfo { get; set; }
        public int ChargeDuration
        {
            get
            {
                var rarityEnum = GoblinUtils.GetGoblinEnumRarity(EnergyInfo.GoblinRarity);
                switch(rarityEnum)
                {
                    case RarityEnum.Common:
                        return 8;
                    case RarityEnum.Uncommon:
                        return 12;
                    case RarityEnum.Rare:
                        return 16;
                    case RarityEnum.Epic:
                        return 24;
                    case RarityEnum.Legendary:
                        return 32;
                    default:
                        return 8;
                }
            }
        }

        public decimal DoRecharge(long idGoblin, long idUser, bool free = false)
        {
            var rechargeValue = _rechargeRepository.DoRecharge(idGoblin, idUser, _rechargeFactory, free);
            return rechargeValue;
        }

        public IGoblinEnergyModel GetGoblin(long idGoblin)
        {
            return _rechargeRepository.GetGoblin(_rechargeFactory, idGoblin);
        }

        public IEnumerable<IGoblinEnergyModel> ListUserGoblin(long idUser)
        {
            return _rechargeRepository.ListUserGoblin(_rechargeFactory, idUser);
        }

        public bool HasRecharge(long idGoblin)
        {
            return _rechargeRepository.HasRecharge(idGoblin);
        }

        public void RestartCharge(long idGoblin)
        {
            _rechargeRepository.RestartCharge(idGoblin);
        }

        public void StopCharge(long idGoblin)
        {
            _rechargeRepository.StopCharge(idGoblin);
        }

        public decimal RechargeAll(long idUser)
        {
            return _rechargeRepository.RechargeAll(idUser, _rechargeFactory);
        }
    }
}
