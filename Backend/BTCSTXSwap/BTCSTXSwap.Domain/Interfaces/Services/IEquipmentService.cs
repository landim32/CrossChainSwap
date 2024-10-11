using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IEquipmentService
    {
        void BuildAvatarEquipment(AvatarInfo avatar, long idGoblin);
        void EquipGoblinPart(long idGoblin, IItemModel equipment, BodyPartEnum part, long idUser);
        GoblinEquipmentInfo GetEquipmentInfo(long idGoblin);
        GoblinEquipmentInfo GetSimpleEquipmentInfo(long idGoblin);
    }
}
