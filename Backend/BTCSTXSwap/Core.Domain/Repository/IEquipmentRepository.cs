using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IEquipmentRepository<TModel, TFactory>
    {
        TModel LoadEquipment(TFactory factory, long idGoblin, bool simple);
        void SaveHelmet(TModel md);
        void SaveChest(TModel md);
        void SaveGloves(TModel md);
        void SaveFoot(TModel md);
        void SaveRHand(TModel md);
        void SaveLHand(TModel md);
        long? GetMiningPowerBonus(long itemKey);
    }
}
