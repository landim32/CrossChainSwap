using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class RechargeRepository : IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory>
    {
        private GoblinWarsContext _goblinContext;


        public RechargeRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IGoblinEnergyModel DbToModel(IRechargeDomainFactory factory, EnergyCost energyCost, GoblinRecharge goblinRecharge)
        {
            if (energyCost == null)
            {
                return null;
            }
            var md = factory.BuildGoblinEnergyModel();
            md.EnergyInfo.ChargeExpiration = goblinRecharge != null ? goblinRecharge.TiredDate : null;
            md.EnergyInfo.HasCost = energyCost.HasCost == 1 ? true : false;
            md.EnergyInfo.EnergyCost = energyCost.HasCost == 1 ? (decimal)energyCost.PartialRecharge : 0;
            md.EnergyInfo.EnergyPercent = energyCost.EnergyPercent ?? 0;
            md.EnergyInfo.Exhausted = energyCost.Exhausted == 1 ? true : false;
            md.EnergyInfo.IdGoblin = energyCost.Id;
            md.EnergyInfo.IdUser = energyCost.UserId;
            md.EnergyInfo.LastCharge = goblinRecharge?.LastRecharge ?? null;
            md.EnergyInfo.GoblinRarity = energyCost.Rarity;
            return md;
        }

        public IEnumerable<IGoblinEnergyModel> ListUserGoblin(IRechargeDomainFactory factory, long idUser)
        {
            var goblinsRow = _goblinContext.EnergyCosts.Where(x => x.UserId == idUser).ToList();
            return goblinsRow.Select(x => this.DbToModel(factory, x, _goblinContext.GoblinRecharges.Where(y => y.IdGoblin == x.Id).OrderByDescending(y => y.LastRecharge).FirstOrDefault()));
        }

        public IGoblinEnergyModel GetGoblin(IRechargeDomainFactory factory, long idGoblin)
        {
            var goblinRow = _goblinContext.EnergyCosts.Where(x => x.Id == idGoblin).FirstOrDefault();
            if (goblinRow == null)
                return null;
            return this.DbToModel(factory, goblinRow, _goblinContext.GoblinRecharges.Where(y => y.IdGoblin == goblinRow.Id).OrderByDescending(y => y.LastRecharge).FirstOrDefault());
        }

        public bool HasRecharge(long idGoblin)
        {
            var goblinRow = _goblinContext.GoblinRecharges.Where(x => x.IdGoblin == idGoblin).FirstOrDefault();
            if (goblinRow == null)
                return false;
            return true;
        }

        public decimal DoRecharge(long idGoblin, long idUser, IRechargeDomainFactory factory, bool free = false)
        {
            decimal costRecharge = 0;
            var rechargeRow = new GoblinRecharge();
            if (free)
            {
                var goblinRow = _goblinContext.Goblins.Where(x => x.Id == idGoblin).FirstOrDefault();
                if (goblinRow == null)
                    throw new Exception("Goblin is not on mining or dont exists");
                if (_goblinContext.Goblins.Find(idGoblin).Status != 3)
                    throw new Exception("Goblin is not on mining");
                var userRow = _goblinContext.Users.Where(x => x.Id == idUser).FirstOrDefault();
                if (userRow == null)
                    throw new Exception("User dont exists");

                rechargeRow.Cost = 0;
                rechargeRow.IdGoblin = idGoblin;
                rechargeRow.LastRecharge = DateTime.UtcNow;
                var energyModel = factory.BuildGoblinEnergyModel();
                energyModel.EnergyInfo.GoblinRarity = goblinRow.Rarity;
                rechargeRow.TiredDate = DateTime.UtcNow.AddHours(energyModel.ChargeDuration);
            } else
            {
                var goblinRow = _goblinContext.EnergyCosts.Where(x => x.Id == idGoblin).FirstOrDefault();
                if (goblinRow == null)
                    throw new Exception("Goblin is not on mining or dont exists");
                if (_goblinContext.Goblins.Find(idGoblin).Status != 3)
                    throw new Exception("Goblin is not on mining");
                var userRow = _goblinContext.Users.Where(x => x.Id == idUser).FirstOrDefault();
                if (userRow == null)
                    throw new Exception("User dont exists");


                if (userRow.Gobi < (decimal)goblinRow.PartialRecharge)
                    throw new Exception("User does not have enough GOBI");
                rechargeRow.Cost = (decimal)goblinRow.PartialRecharge;
                costRecharge = (decimal)goblinRow.PartialRecharge;
                rechargeRow.IdGoblin = idGoblin;
                rechargeRow.LastRecharge = DateTime.UtcNow;
                var energyModel = factory.BuildGoblinEnergyModel();
                energyModel.EnergyInfo.GoblinRarity = goblinRow.Rarity;
                rechargeRow.TiredDate = DateTime.UtcNow.AddHours(energyModel.ChargeDuration);
            }
            
            

            var chargesActives = _goblinContext.GoblinRecharges.Where(x => x.IdGoblin == idGoblin && x.Active == 1);
            if (chargesActives != null)
            {
                foreach (var chargeActive in chargesActives)
                {
                    chargeActive.Active = 0;
                }
            }

            rechargeRow.Active = 1;
            _goblinContext.GoblinRecharges.Add(rechargeRow);
            _goblinContext.SaveChanges();
            return costRecharge;
        }

        public decimal RechargeAll(long idUser, IRechargeDomainFactory factory)
        {
            decimal costRecharge = 0;
            var goblinsCharge = _goblinContext.EnergyCosts.Where(x => x.UserId == idUser).ToList();
            if (goblinsCharge != null)
                goblinsCharge.ForEach((goblin) =>
                {
                    costRecharge += this.DoRecharge(goblin.Id, idUser, factory, false);
                });
            return costRecharge;
        }

        public void RestartCharge(long idGoblin)
        {
            var charge = _goblinContext.GoblinRecharges.Where(x => x.IdGoblin == idGoblin && x.StopDate != null && x.Active == 1).FirstOrDefault();
            if (charge == null)
                return;
            else
            {
                var rechargeRow = new GoblinRecharge();
                rechargeRow.Cost = 0;
                rechargeRow.IdGoblin = idGoblin;
                var now = DateTime.UtcNow;
                var timeLeft = charge.TiredDate - (DateTime)charge.StopDate;
                if(timeLeft.TotalSeconds > 0)
                {
                    var totalTimeCharge = ((charge.RestartTiredDate ?? charge.TiredDate) - charge.LastRecharge).TotalSeconds;
                    rechargeRow.RestartTiredDate = now.AddSeconds(totalTimeCharge);
                    rechargeRow.TiredDate = now.AddSeconds(timeLeft.TotalSeconds);
                    rechargeRow.LastRecharge = now;
                    rechargeRow.RestartDate = now.AddSeconds(totalTimeCharge - timeLeft.TotalSeconds);
                } else
                {
                    rechargeRow.LastRecharge = now;
                }
                

                var chargesActives = _goblinContext.GoblinRecharges.Where(x => x.IdGoblin == idGoblin && x.Active == 1);
                if(chargesActives != null)
                {
                    foreach(var chargeActive in chargesActives)
                    {
                        chargeActive.Active = 0;
                    }
                }
                rechargeRow.Active = 1;
                _goblinContext.GoblinRecharges.Add(rechargeRow);
                _goblinContext.SaveChanges();
            }
        }

        public void StopCharge(long idGoblin)
        {
            var charge = _goblinContext.GoblinRecharges.Where(x => x.IdGoblin == idGoblin && x.Active == 1).FirstOrDefault();
            if (charge == null)
                return;
            else
            {
                charge.StopDate = DateTime.UtcNow;
                _goblinContext.SaveChanges();
            }
        }
    }
}
