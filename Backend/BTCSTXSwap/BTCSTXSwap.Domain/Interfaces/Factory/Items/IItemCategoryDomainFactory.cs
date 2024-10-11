using BTCSTXSwap.Domain.Impl.Models.Equipments;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Factory
{
    public interface IItemCategoryDomainFactory
    {
        IItemCategoryModel BuildItemCategoryModel(ItemCategoryEnum s);
    }
}
