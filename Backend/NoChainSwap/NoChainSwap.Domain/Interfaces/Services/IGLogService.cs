using NoChainSwap.Domain.Impl.Core;
using NoChainSwap.DTO.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Interfaces.Services
{
    public interface IGLogService
    {
        GLogListResult List(long idUser, int page);
        void AddLog(long idUser, string msg, LogType logType, string Ip = "");
    }
}
