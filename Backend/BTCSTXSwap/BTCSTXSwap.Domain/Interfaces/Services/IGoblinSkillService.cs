using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinSkillService
    {
        GoblinSkillInfo GetGoblinSkillList(IGoblinModel mdGoblin, GoblinEquipmentInfo goblinEquipment);
    }
}
