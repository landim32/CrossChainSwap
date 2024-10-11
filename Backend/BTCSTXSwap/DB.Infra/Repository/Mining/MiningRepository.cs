using Core.Domain.Repository;
using Core.Domain.Repository.Mining;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Mining
{
    public class MiningRepository : IMiningRepository<IMiningModel, IMiningDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        private const string DAILY_REWARD = "DAILY_REWARD";
        private const string MIN_HASH_POWER = "MIN_HASH_POWER";

        public MiningRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IMiningModel DbToModel(IMiningDomainFactory factory, MiningRanking mining)
        {
            if (mining == null)
            {
                return null;
            }
            var md = factory.BuildMiningModel();
            md.Id = mining.Id;
            md.IdUser = mining.IdUser;
            md.LastMining = mining.LastMining;
            md.Name = mining.Name;
            md.HashPower = mining.HashPower;
            md.GoblinQtde = mining.GoblinQtde;
            md.RewardPerMonth = mining.RewardPerMonth;
            md.RewardPerSecond = mining.RewardPerSecond;
            md.HashforWeek = mining.HashForWeek;
            md.HashForMonth = mining.HashForMonth;
            return md;
        }

        public IEnumerable<IMiningModel> ListRanking(IMiningDomainFactory factory, int limit)
        {
            var miHashPower = long.Parse(_goblinContext
                .Configurations
                .Where(y => y.Name == "MIN_HASH_POWER")
                .Select(y => y.Value)
                .FirstOrDefault()
            );
            var q = _goblinContext.MiningRankings.Where(x => x.HashPower >= miHashPower);
            if (limit > 0)
            {
                q = q.Take(limit);
            }
            return q.ToList().Select(i => DbToModel(factory, i));
        }

        public IMiningModel GetMining(IMiningDomainFactory factory, long idUser)
        {
            var md = DbToModel(factory,
                _goblinContext.MiningRankings
                .Where(x => x.IdUser == idUser)
                .FirstOrDefault()
            );
            if(md != null)
                md.Gobi = _goblinContext.MiningRewards
                    .Where(x => x.IdUser == idUser && x.Status == (int)MiningRewardStatusEnum.Avaliable)
                    .Select(x => x.GobiValue)
                    .Sum();
            return md;
        }

        public int GetHashPower(long idUser)
        {
            return _goblinContext.MiningRankings
                .Where(x => x.IdUser == idUser)
                .Select(x => x.HashPower)
                .FirstOrDefault();
        }

        public int GetNumberOfMiningGoblin(long idUser)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser && x.Status == (int)GoblinStatusEnum.Minning)?.Count() ?? 0;
        }

        public int MinHashPower()
        {
            var str = _goblinContext.Configurations
                .Where(x => x.Name == MIN_HASH_POWER)
                .Select(x => x.Value)
                .FirstOrDefault();
            int r = 0;
            int.TryParse(str, out r);
            return r;
        }

        public int TotalHashPower()
        {
            var minHashPower = MinHashPower();
            return _goblinContext.MiningRankings
                .Where(x => x.HashPower >= minHashPower)
                .Sum(x => x.HashPower);
        }

        public int DailyReward()
        {
            var str = _goblinContext.Configurations
                .Where(x => x.Name == DAILY_REWARD)
                .Select(x => x.Value)
                .FirstOrDefault();
            int r = 0;
            int.TryParse(str, out r);
            return r;
        }
        public void RefreshProcRanking()
        {
            ((DbContext)_goblinContext).Database.ExecuteSqlRaw("EXEC DO_MINING;");
        }
    }
}
