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
    public class FarmCategoryModel : IItemCategoryModel
    {
        public const int WHEAT_SEED = 511;
        public const int COTTON_SEED = 512;
        public const int WHEAT = 513;
        public const int COTTON = 514;
        public const int CLOTH = 515;

        private const string CATEGORY = "Farming";

        private readonly ILogCore _log;
        private readonly IItemDomainFactory _itemFactory;

        public FarmCategoryModel(ILogCore log, IItemDomainFactory itemFactory)
        {
            _log = log;
            _itemFactory = itemFactory;
        }

        public IList<IItemModel> Generate()
        {
            var i = new List<IItemModel>();
            IItemModel md = null;


            md = _itemFactory.BuildItemModel();
            md.Key = WHEAT;
            md.Category = CATEGORY;
            md.Name = "Wheat";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/wheat.png";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            md.IsBag = false;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = COTTON;
            md.Category = CATEGORY;
            md.Name = "Cotton";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/cotton.png";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 1;
            md.IsBag = false;
            md.IsTrash = false;
            i.Add(md);

            md = _itemFactory.BuildItemModel();
            md.Key = CLOTH;
            md.Category = CATEGORY;
            md.Name = "Cloth";
            md.IconAsset = "https://goblinwars.blob.core.windows.net/basegoblins/Itens/cloath.png";
            md.Rarity = ItemRarityEnum.Common;
            md.Price = 3;
            md.IsBag = false;
            md.IsTrash = false;
            i.Add(md);

            return i;
        }
    }
}
