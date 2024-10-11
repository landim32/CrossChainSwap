using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Gobox
{
    public class GoboxDomainFactory : IGoboxDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoboxRepository<IGoboxModel, IGoboxDomainFactory> _repGobox;

        public GoboxDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGoboxRepository<IGoboxModel, IGoboxDomainFactory> repGobox
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repGobox = repGobox;
        }

        public IGoboxModel BuildGoboxModel()
        {
            return new GoboxModel(_log, _unitOfWork, this, _repGobox);
        }
    }
}
