using BTCSTXSwap.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.DailyLogin
{
    public class DailyLoginModel : IDailyLoginModel
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime InsertDate { get; set; }
        public IList<IDailyLoginDayModel> Days { get; set; }
     
    }
}
