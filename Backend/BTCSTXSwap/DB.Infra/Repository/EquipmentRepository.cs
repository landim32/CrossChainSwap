using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Goblin;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class EquipmentRepository : IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory>
    {

        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        public EquipmentRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        private IItemModel DbToModel(IGoblinEquipment md, GoblinEquipment info)
        {
            if (info == null)
            {
                return null;
            }
            var ret = md.BuildItemModel(info.ItemKey);
            var miningPowerBonusAttribute = _goblinContext.EquipmentAttributes.Where(x => x.Name == "ADD_MINING_POWER").FirstOrDefault().Id;
            var bonunMining = _goblinContext.EquipmentAttributeBonus.Where(x => x.ItemKey == ret.Key && x.IdAttribute == miningPowerBonusAttribute).FirstOrDefault();
            ret.EquipmentInfo.Mining = bonunMining == null ? 0 : Decimal.ToInt64(bonunMining.Value);
            return ret;
        }

        private void ModelToDb(GoblinEquipment info, IItemModel md, long idGoblin)
        {
            info.IdGoblin = idGoblin;
            info.DataAlteracao = DateTime.UtcNow;
            info.EquipmentType = (int)md.EquipmentInfo.ItemType;
            info.ItemCategory = md.Category;
            info.ItemKey = md.Key;
        }

        private UserItem GetItemInventory(long itemKey, long idUser)
        {
            var msgErro = "User does not own the item";
            var rowItem = _goblinContext.UserItems.Where(x => x.ItemKey == itemKey && x.IdUser == idUser).FirstOrDefault();
            if (rowItem == null || rowItem.Qtde == 0)
                throw new Exception(msgErro);
            return rowItem;
        }

        private void WithdrawalInventory(UserItem item)
        {
            if(item.Qtde == 1)
            {
                _goblinContext.UserItems.Remove(item);
            }
            else
            {
                item.Qtde--;
            }
            _goblinContext.SaveChanges();
        }

        public IGoblinEquipment LoadEquipment(IGoblinEquipmentDomainFactory factory, long idGoblin, bool simple)
        {
            var mdGoblinEquipment = factory.BuildGoblinEquipment();
            mdGoblinEquipment.IdGoblin = idGoblin;
            mdGoblinEquipment.IdUser = _goblinContext.Goblins.Find(idGoblin).IdUser;
            var mdHead = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.Head && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();
            var mdChest = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.Chest && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();
            var mdGloves = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.Gloves && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();
            var mdFoot = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.Foot && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();
            var mdRHand = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.RHand && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();
            var mdLHand = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.LHand && x.IdGoblin == idGoblin && x.Equiped == 1).FirstOrDefault();

            mdGoblinEquipment.Head = DbToModel(mdGoblinEquipment, mdHead);
            mdGoblinEquipment.Chest = DbToModel(mdGoblinEquipment, mdChest);
            mdGoblinEquipment.Hand = DbToModel(mdGoblinEquipment, mdGloves);
            mdGoblinEquipment.Foot = DbToModel(mdGoblinEquipment, mdFoot);
            mdGoblinEquipment.RightHand = DbToModel(mdGoblinEquipment, mdRHand);
            mdGoblinEquipment.LeftHand = DbToModel(mdGoblinEquipment, mdLHand);

            if(!simple)
            {
                var equipmentsBag = _goblinContext.GoblinEquipments.Where(x => x.IdGoblin == idGoblin && x.Equiped == 0).ToList();
                mdGoblinEquipment.CanEquip = equipmentsBag.Select(x =>
                {
                    var itemMd = DbToModel(mdGoblinEquipment, x);
                    itemMd.EquipmentInfo.Binded = true;
                    return itemMd;
                }).ToList();
                var userId = _goblinContext.Goblins.Find(idGoblin).IdUser;
                var equipmentsUser = _goblinContext.UserItems.Where(x => x.IdUser == userId && x.Qtde > 0).ToList();
                if (equipmentsUser != null)
                {
                    if (mdGoblinEquipment.CanEquip == null)
                        mdGoblinEquipment.CanEquip = new List<IItemModel>();
                    foreach (var equipmentUser in equipmentsUser)
                    {
                        if (mdGoblinEquipment.CanEquip.Where(x => x.Key == equipmentUser.ItemKey).Any())
                            continue;
                        /*if (mdGoblinEquipment.Head != null && mdGoblinEquipment.Head.Key == equipmentUser.ItemKey)
                            continue;
                        if (mdGoblinEquipment.Chest != null && mdGoblinEquipment.Chest.Key == equipmentUser.ItemKey)
                            continue;
                        if (mdGoblinEquipment.Hand != null && mdGoblinEquipment.Hand.Key == equipmentUser.ItemKey)
                            continue;
                        if (mdGoblinEquipment.Foot != null && mdGoblinEquipment.Foot.Key == equipmentUser.ItemKey)
                            continue;
                        if (mdGoblinEquipment.RightHand != null && mdGoblinEquipment.RightHand.Key == equipmentUser.ItemKey)
                            continue;
                        if (mdGoblinEquipment.LeftHand != null && mdGoblinEquipment.LeftHand.Key == equipmentUser.ItemKey)
                            continue;*/

                        var item = mdGoblinEquipment.BuildItemModel(equipmentUser.ItemKey);
                        if (!item.IsEquipment)
                            continue;
                        for (var i = 0; i < equipmentUser.Qtde; i++)
                        {
                            item.EquipmentInfo.Binded = false;
                            mdGoblinEquipment.CanEquip.Add(item);
                        }
                    }
                }
            }

            return mdGoblinEquipment;
        }

        private void SavePart(BodyPartEnum part, IItemModel item, long idGoblin, long idUser)
        {
            if(item.EquipmentInfo.Part.Contains(part) == false)
            {
                throw new Exception("This item cant be equiped in this slot.");
            }
            var flagInsert = false;
            GoblinEquipment mdEquip = null;
            if (part != BodyPartEnum.RHand && part != BodyPartEnum.LHand)
                mdEquip = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)part && x.IdGoblin == idGoblin && x.ItemKey == item.Key).FirstOrDefault();
            else
                mdEquip = _goblinContext.GoblinEquipments.Where(x => (x.BodyPart == (int)BodyPartEnum.RHand || x.BodyPart == (int)BodyPartEnum.LHand) && x.IdGoblin == idGoblin && x.ItemKey == item.Key && x.Equiped == 0).FirstOrDefault();

            if (mdEquip == null)
            {
                var usrItem = GetItemInventory(item.Key, idUser);
                WithdrawalInventory(usrItem);
                mdEquip = new GoblinEquipment();
                flagInsert = true;
            }
            var mdEquips = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)part && x.IdGoblin == idGoblin);
            if (mdEquips != null)
            {
                foreach (var equip in mdEquips)
                {
                    equip.Equiped = 0;
                }
            }
            _goblinContext.SaveChanges();
            ModelToDb(mdEquip, item, idGoblin);
            mdEquip.BodyPart = (int)part;
            mdEquip.Equiped = 1;
            if (flagInsert)
                _goblinContext.GoblinEquipments.Add(mdEquip);
            _goblinContext.SaveChanges();
        }

        public void SaveHelmet(IGoblinEquipment md)
        {
            SavePart(BodyPartEnum.Head, md.Head, md.IdGoblin, md.IdUser);
        }

        public void SaveChest(IGoblinEquipment md)
        {
            SavePart(BodyPartEnum.Chest, md.Chest, md.IdGoblin, md.IdUser);
        }

        public void SaveGloves(IGoblinEquipment md)
        {
            SavePart(BodyPartEnum.Gloves, md.Hand, md.IdGoblin, md.IdUser);
        }

        public void SaveFoot(IGoblinEquipment md)
        {
            SavePart(BodyPartEnum.Foot, md.Foot, md.IdGoblin, md.IdUser);
        }

        public void SaveRHand(IGoblinEquipment md)
        {
            SavePart(BodyPartEnum.RHand, md.RightHand, md.IdGoblin, md.IdUser);
            if (md.RightHand.EquipmentInfo.IsTwoHanded)
            {
                var lequips = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.LHand && x.IdGoblin == md.IdGoblin && x.Equiped == 1).ToList();
                if (lequips != null)
                {
                    foreach (var lequip in lequips)
                    {
                        lequip.Equiped = 0;
                    }
                    _goblinContext.SaveChanges();
                }
            }
        }

        public void SaveLHand(IGoblinEquipment md)
        {
            var RHand = _goblinContext.GoblinEquipments.Where(x => x.BodyPart == (int)BodyPartEnum.RHand && x.IdGoblin == md.IdGoblin && x.Equiped == 1);
            if (RHand != null && RHand.Any())
            {
                var itemKey = RHand.First().ItemKey;
                if (md.BuildItemModel(itemKey).EquipmentInfo.IsTwoHanded)
                    throw new Exception("U cant equip while using a two handed.");
            }
                
            SavePart(BodyPartEnum.LHand, md.LeftHand, md.IdGoblin, md.IdUser);
        }

        public long? GetMiningPowerBonus(long itemKey)
        {
            try
            {
                var miningPowerBonusAttribute = _goblinContext.EquipmentAttributes.Where(x => x.Name == "ADD_MINING_POWER").FirstOrDefault().Id;
                var bonunMining = _goblinContext.EquipmentAttributeBonus.Where(x => x.ItemKey == itemKey && x.IdAttribute == miningPowerBonusAttribute).FirstOrDefault();
                return bonunMining == null ? null : Decimal.ToInt64(bonunMining.Value);
            } catch(Exception err)
            {
                throw;
            }
            
        }

    }
}
