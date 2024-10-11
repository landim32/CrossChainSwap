using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory
{
    public class GoblinEquipmentDomainFactory : IGoblinEquipmentDomainFactory
    {

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> _equipmentRepository;
        private readonly IUserItemDomainFactory _userItemDomainFactory;

        public GoblinEquipmentDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> equipmentRepository,
            IUserItemDomainFactory userItemDomainFactory
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _equipmentRepository = equipmentRepository;
            _userItemDomainFactory = userItemDomainFactory;
        }


        public IGoblinEquipment BuildGoblinEquipment()
        {
            return new GoblinEquipment(_log, _unitOfWork, _equipmentRepository, _userItemDomainFactory, this);
        }

        
    }
}
