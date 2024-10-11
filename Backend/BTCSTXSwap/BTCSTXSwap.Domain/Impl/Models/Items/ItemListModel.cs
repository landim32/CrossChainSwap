using Core.Domain;
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
    public class ItemListModel : IItemListModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemCategoryDomainFactory _itemCategoryDomainFactory;

        private static IList<IItemModel> _items;

        public ItemListModel(
            ILogCore log, 
            IUnitOfWork unitOfWork,
            IItemCategoryDomainFactory itemCategoryDomainFactory
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _itemCategoryDomainFactory = itemCategoryDomainFactory;
        }

        private IEnumerable<IItemModel> Generate()
        {
            var s = new List<IItemModel>();
            var sm = Enum.GetValues(typeof(ItemCategoryEnum));
            foreach (var sme in sm)
            {
                var item = _itemCategoryDomainFactory.BuildItemCategoryModel((ItemCategoryEnum)sme);
                s.AddRange(item.Generate());
            }
            return s.OrderBy(o => o.Category).ThenBy(c => c.Name).ToList();
        }

        public IList<IItemModel> ListAll()
        {
            if (_items == null)
            {
                _items = Generate().ToList();
            }
            return _items;
        }

        public IItemModel GetItemByKey(long key)
        {
            return ListAll().Where(x => x.Key == key).FirstOrDefault();
        }
    }
}
