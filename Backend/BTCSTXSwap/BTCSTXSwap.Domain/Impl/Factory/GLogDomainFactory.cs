using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory
{
    public class GLogDomainFactory : IGLogDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGLogRepository<IGLogModel, IGLogDomainFactory> _repLog;

        public GLogDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGLogRepository<IGLogModel, IGLogDomainFactory> repLog
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repLog = repLog;
        }

        public IGLogModel BuildGLogModel()
        {
            return new GLogModel(_log, _unitOfWork, this, _repLog);
        }
    }
}
