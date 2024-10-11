using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Items
{
    public interface IItemCategoryModel
    {
        IList<IItemModel> Generate();
    }
}
