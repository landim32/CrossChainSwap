using Core.Domain;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class ItemListDomainFactory : IItemListDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemCategoryDomainFactory _itemCategoryFactory;

        public ItemListDomainFactory(
            ILogCore log, 
            IUnitOfWork unitOfWork,
            IItemCategoryDomainFactory itemCategoryFactory
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _itemCategoryFactory = itemCategoryFactory;
        }

        public IItemListModel BuildItemListModel()
        {
            return new ItemListModel(_log, _unitOfWork, _itemCategoryFactory);
        }
    }
}
