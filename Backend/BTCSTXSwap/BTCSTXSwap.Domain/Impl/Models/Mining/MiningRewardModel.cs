using Core.Domain;
using Core.Domain.Repository.Mining;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Mining
{
    public class MiningRewardModel: IMiningRewardModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMiningRewardDomainFactory _miningRewardFactory;
        private readonly IMiningRewardRepository<IMiningRewardModel, IMiningRewardDomainFactory> _miningRewardRep;

        public MiningRewardModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IMiningRewardDomainFactory miningRewardFactory,
            IMiningRewardRepository<IMiningRewardModel, IMiningRewardDomainFactory> miningRewardRep
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _miningRewardFactory = miningRewardFactory;
            _miningRewardRep = miningRewardRep;
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal GobiValue { get; set; }
        public decimal Credit { get; set; }
        public decimal Fee { get; set; }
        public long HashValue { get; set; }
        public MiningRewardStatusEnum Status { get; set; }

        public IEnumerable<IMiningRewardModel> List(long idUser, int limit)
        {
            return _miningRewardRep.List(_miningRewardFactory, idUser, limit);
        }

        public IMiningRewardModel GetById(long id)
        {
            return _miningRewardRep.GetById(_miningRewardFactory, id);
        }

        public decimal GetBalanceClaimable(long idUser)
        {
            return _miningRewardRep.GetBalanceClaimable(idUser);
        }

        public void Update() {
            _miningRewardRep.Update(this);
        }
    }
}
