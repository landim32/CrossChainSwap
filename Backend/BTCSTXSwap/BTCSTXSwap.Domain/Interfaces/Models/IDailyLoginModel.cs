using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IDailyLoginModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        DateTime InsertDate { get; set; }
        IList<IDailyLoginDayModel> Days { get; set; }
    }
}
