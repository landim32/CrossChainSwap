using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinIdleService
    {
        IEnumerable<IGoblinIdleModel> ListIdle(int idUser);
        //IList<IGoblinIdleModel> ListOnlyIdle(string uidUser);
        //IList<IGoblinIdleModel> ListReadyForWork(IWorkModel w);
    }
}
