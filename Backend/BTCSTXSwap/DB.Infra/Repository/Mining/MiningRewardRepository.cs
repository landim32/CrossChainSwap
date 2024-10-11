using Core.Domain.Repository.Mining;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Mining
{
    public class MiningRewardRepository : IMiningRewardRepository<IMiningRewardModel, IMiningRewardDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public MiningRewardRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IMiningRewardModel DbToModel(IMiningRewardDomainFactory factory, MiningReward info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildMiningRewardModel();
            md.Id = info.Id;
            md.IdUser = info.IdUser;
            md.InsertDate = info.InsertDate;
            md.ClaimDate = info.ClaimDate;
            md.GobiValue = info.GobiValue;
            md.Credit = info.Credit;
            md.Fee = info.Fee;
            md.HashValue = info.HashValue ?? 0;
            md.Status = (MiningRewardStatusEnum)info.Status;
            return md;
        }

        private void ModelToDb(MiningReward info, IMiningRewardModel md)
        {
            info.Id = md.Id;
            info.Id = md.Id;
            info.IdUser = md.IdUser;
            info.InsertDate = md.InsertDate;
            info.ClaimDate = md.ClaimDate;
            info.GobiValue = md.GobiValue;
            info.Credit = md.Credit;
            info.Fee = md.Fee;
            info.HashValue = md.HashValue;
            info.Status = (int)md.Status;
        }

        public IEnumerable<IMiningRewardModel> List(IMiningRewardDomainFactory factory, long idUser, int limit)
        {
            return _goblinContext.MiningRewards
                .Where(x => x.IdUser == idUser && x.Status == (int)MiningRewardStatusEnum.Avaliable)
                .OrderByDescending(x => x.InsertDate)
                .Take(limit)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }

        public IMiningRewardModel GetById(IMiningRewardDomainFactory factory, long id)
        {
            return DbToModel(factory, _goblinContext.MiningRewards.Find(id));
        }

        public decimal GetBalanceClaimable(long idUser)
        {
            return _goblinContext.MiningRewards
                .Where(x => x.IdUser == idUser && x.Status == (int)MiningRewardStatusEnum.Avaliable)
                .Select(x => x.GobiValue)
                .Sum();
        }

        public void Update(IMiningRewardModel md)
        {
            MiningReward info = _goblinContext.MiningRewards.Find(md.Id);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
        }
    }
}
