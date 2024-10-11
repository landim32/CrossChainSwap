using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class UserItemModel: IUserItemModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemDomainFactory _itemFactory;
        private readonly IItemListDomainFactory _itemListFactory;
        private readonly IUserItemDomainFactory _userItemFactory;
        private readonly IUserItemRepository<IUserItemModel, IUserItemDomainFactory> _repUserItem;

        public UserItemModel(
            ILogCore log, 
            IUnitOfWork unitOfWork, 
            IItemDomainFactory itemFactory,
            IItemListDomainFactory itemListFactory,
            IUserItemDomainFactory userItemFactory,
            IUserItemRepository<IUserItemModel, IUserItemDomainFactory> repUserItem
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _itemFactory = itemFactory;
            _itemListFactory = itemListFactory;
            _userItemFactory = userItemFactory;
            _repUserItem = repUserItem;
        }

        private IItemModel _item = null;

        public long IdItem { get; set; }
        public long ItemKey { get; set; }
        public long IdUser { get; set; }
        public int Qtde { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public IItemModel GetItem() {
            if (ItemKey <= 0) {
                throw new Exception("Item key cant be empty");
            }
            if (_item == null)
            {
                _item = _itemListFactory.BuildItemListModel().GetItemByKey(ItemKey);
                if (_item == null)
                {
                    throw new Exception(string.Format("No item with key {0}", ItemKey));
                }
            }
            return _item;
        }

        public IEnumerable<IUserItemModel> ListById(long idUser)
        {
            return _repUserItem.ListByUid(_userItemFactory, idUser).ToList();
        }

        public IList<IUserItemModel> ListTrashByUser(long idUser)
        {
            return _repUserItem
                .ListByUid(_userItemFactory, idUser)
                .Where(x => x.GetItem().IsTrash)
                .ToList();
        }

        public IUserItemModel GetById(long idItem)
        {
            return _repUserItem.GetById(_userItemFactory, idItem);
        }

        public IUserItemModel GetByKey(long idUser, long key)
        {
            return _repUserItem.GetByKey(_userItemFactory, idUser, key);
        }

        public IUserItemModel GetByPosition(long idUser, int x, int y)
        {
            return _repUserItem.GetByPosition(_userItemFactory, idUser, x, y);
        }

        public void Save()
        {
            if (IdItem > 0)
            {
                _repUserItem.Update(this);
            }
            else
            {
                _repUserItem.Insert(this);
            }
        }

        public void Delete()
        {
            _repUserItem.Delete(this.IdItem);
        }
    }
}
