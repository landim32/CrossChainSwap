using System;
using System.Collections.Generic;

namespace Core.Domain.Repository
{
    public interface IGoblinEquipmentRepository<TModel, TFactory>
    {
        TModel LoadEquipment(long idGoblin);
        void Save(TModel md);
    }
}
