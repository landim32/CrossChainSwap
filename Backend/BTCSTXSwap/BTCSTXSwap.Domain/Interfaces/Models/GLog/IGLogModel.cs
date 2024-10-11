using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.GLog
{
    public interface IGLogModel
    {
        long IdLog { get; set; }
        long IdUser { get; set; }
        string Ip { get; set; }
        DateTime InsertDate { get; set; }
        string Message { get; set; }
        string LogType { get; set; }

        IEnumerable<IGLogModel> List(long idUser, int page, out int balance);
        void Insert();
    }
}
