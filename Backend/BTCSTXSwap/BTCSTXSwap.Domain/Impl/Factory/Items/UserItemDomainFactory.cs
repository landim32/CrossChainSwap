using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory.Items
{
    public class UserItemDomainFactory: IUserItemDomainFactory
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemDomainFactory _itemFactory;
        private readonly IItemListDomainFactory _itemListFactory;
        //private readonly IUserItemDomainFactory _userItemFactory;
        private readonly IUserItemRepository<IUserItemModel, IUserItemDomainFactory> _userItemRep;

        public UserItemDomainFactory(
            ILogCore log, 
            IUnitOfWork unitOfWork, 
            IItemDomainFactory itemFactory,
            IItemListDomainFactory itemListFactory,
            //IUserItemDomainFactory userItemFactory,
            IUserItemRepository<IUserItemModel, IUserItemDomainFactory> userItemRep
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _itemFactory = itemFactory;
            _itemListFactory = itemListFactory;
            //_userItemFactory = userItemFactory;
            _userItemRep = userItemRep;
        }

        public IUserItemModel BuildUserItemModel()
        {
            return new UserItemModel(_log, _unitOfWork, _itemFactory, _itemListFactory, this, _userItemRep);
        }
    }
}
