using Core.Domain;
using Core.Domain.Repository;
using NoChainSwap.Domain.Interfaces.Core;
using NoChainSwap.Domain.Interfaces.Factory.GLog;
using NoChainSwap.Domain.Interfaces.Models.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Impl.Models.GLog
{
    public class GLogModel: IGLogModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGLogDomainFactory _glogFactory;
        //private readonly IGLogRepository<IGLogModel, IGLogDomainFactory> _repLog;

        public GLogModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGLogDomainFactory glogFactory
            //IGLogRepository<IGLogModel, IGLogDomainFactory> repLog
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _glogFactory = glogFactory;
            //_repLog = repLog;
        }

        public long IdLog { get; set; }
        public long IdUser { get; set; }
        public string Ip { get; set; }
        public DateTime InsertDate { get; set; }
        public string Message { get; set; }
        public string LogType { get; set; }

        public IEnumerable<IGLogModel> List(long idUser, int page, out int balance)
        {
            //return _repLog.List(_glogFactory, idUser, page, out balance);
            balance = 0;
            return new List<IGLogModel>();
        }
        public void Insert()
        {
            //_repLog.Insert(this);
        }
    }
}
