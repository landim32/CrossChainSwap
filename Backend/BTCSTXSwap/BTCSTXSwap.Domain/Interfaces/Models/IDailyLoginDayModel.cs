using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IDailyLoginDayModel
    {
        long IdDay { get; set; }
        long IdDaily { get; set; }
        DateTime LimitDate { get; set; }
        int Day { get; set; }
        int ItemKey { get; set; }
        bool Success { get; set; }

        IEquipmentModel GetItem(int key);
    }
}
