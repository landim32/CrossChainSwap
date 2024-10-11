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
    public class ToolCategoryModel : IItemCategoryModel
    {
        public const int TRASH = 31;
        public const int LUMBERJACK_AX = 32;
        public const int PICKAXE = 33;
        public const int HAMMER = 34;
        public const int IMPROVISED_FURNANCE = 35;
        private const string CATEGORY = "Tools";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public ToolCategoryModel(ILogCore log, IItemDomainFactory itemFactory)
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;

            md = _itemFactory.BuildItemModel();
            md.Key = TRASH;
            md.Category = "Trash";
            md.Name = "Trash";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/trash.png";
            md.IsTrash = true;
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = LUMBERJACK_AX;
            md.Category = CATEGORY;
            md.Name = "Lumberjack Ax";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = PICKAXE;
            md.Category = CATEGORY;
            md.Name = "Pickaxe";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = HAMMER;
            md.Category = CATEGORY;
            md.Name = "Hammer";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = IMPROVISED_FURNANCE;
            md.Category = CATEGORY;
            md.Name = "Improvised Furnace";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            i.Add(md);

            return i;
        }
    }
}
