using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class GoblinIdleModel: IGoblinIdleModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory> _repositoryGoblinIdle;

        public GoblinIdleModel(ILogCore log, IUnitOfWork unitOfWork, IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory> repositoryGoblinIdle)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repositoryGoblinIdle = repositoryGoblinIdle;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public RaceEnum Race { get; set; }
        public string Description { get; }
        //public bool IsBusy { get; set; }

        public IEnumerable<IGoblinIdleModel> ListIdle(IGoblinIdleDomainFactory factory, int idUser)
        {
            return _repositoryGoblinIdle.ListIdle(factory, idUser);
        }
    }
}
