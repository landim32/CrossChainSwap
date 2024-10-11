using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.DTO.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGLogService
    {
        GLogListResult List(long idUser, int page);
        void AddLog(long idUser, string msg, LogType logType, string Ip = "");
    }
}
