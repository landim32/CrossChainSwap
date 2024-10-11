using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class ItemDomainFactory: IItemDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;

        public ItemDomainFactory(
            ILogCore log,
            IUnitOfWork unitOfWork
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public IItemModel BuildItemModel()
        {
            return new ItemModel(_log, _unitOfWork);
        }
    }
}
