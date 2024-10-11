using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Equipments;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class GoblinEquipment : IGoblinEquipment
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> _goblinEquipmentRepository;
        private readonly IUserItemDomainFactory _userItemDomainFactory;
        private readonly IGoblinEquipmentDomainFactory _goblinEquipmentDomainFactory;

        public GoblinEquipment(ILogCore log, IUnitOfWork unitOfWork,
            IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory> goblinEquipmentRepository,
            IUserItemDomainFactory userItemDomainFactory, IGoblinEquipmentDomainFactory goblinEquipmentDomainFactory)
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goblinEquipmentRepository = goblinEquipmentRepository;
            _userItemDomainFactory = userItemDomainFactory;
            _goblinEquipmentDomainFactory = goblinEquipmentDomainFactory;
        }

        public IItemModel Head { get; set; }
        public IItemModel Chest { get; set; }
        public IItemModel Hand { get; set; }
        public IItemModel Foot { get; set; }
        public IItemModel RightHand { get; set; }
        public IItemModel LeftHand { get; set; }
        public IList<IItemModel> CanEquip { get; set; }
        public long IdGoblin { get; set; }
        public long IdUser { get; set; }

        public IItemModel BuildItemModel(long itemKey)
        {
            var usrMd = _userItemDomainFactory.BuildUserItemModel();
            usrMd.ItemKey = itemKey;
            return usrMd.GetItem();
        }

        public void EquipPart(long itemKey, BodyPartEnum bodyPart)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    switch (bodyPart)
                    {
                        case BodyPartEnum.Head:
                            this.Head = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveHelmet(this);
                            break;
                        case BodyPartEnum.Chest:
                            this.Chest = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveChest(this);
                            break;
                        case BodyPartEnum.Gloves:
                            this.Hand = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveGloves(this);
                            break;
                        case BodyPartEnum.Foot:
                            this.Foot = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveFoot(this);
                            break;
                        case BodyPartEnum.RHand:
                            this.RightHand = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveRHand(this);
                            break;
                        case BodyPartEnum.LHand:
                            this.LeftHand = BuildItemModel(itemKey);
                            _goblinEquipmentRepository.SaveLHand(this);
                            break;
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public IGoblinEquipment GetGoblinEquipment(long idGoblin, bool simple)
        {
            return _goblinEquipmentRepository.LoadEquipment(_goblinEquipmentDomainFactory, idGoblin, simple);
        }

    }
}
