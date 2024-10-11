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
    public class WoodCategoryModel : IItemCategoryModel
    {
        public static readonly int WOOD_LOG = 1;
        public static readonly int WOODEN_BOARD = 2;

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public WoodCategoryModel(ILogCore log, IItemDomainFactory itemFactory)
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = WOOD_LOG;
            md.Category = "Wood";
            md.Name = "Wood Log";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/wood.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = WOODEN_BOARD;
            md.Category = "Wood";
            md.Name = "Wood Board";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/wooden-board.png";
            md.Rarity = ItemRarityEnum.Common;
            md.IsTrash = false;
            md.Price = 1;
            i.Add(md);

            return i;
        }
    }
}
