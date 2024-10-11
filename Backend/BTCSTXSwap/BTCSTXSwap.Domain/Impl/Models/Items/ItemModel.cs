using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Equipment;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class ItemModel: IItemModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        

        //private static IList<IItemModel> _items;

        public ItemModel(ILogCore log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public long Key { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ItemRarityEnum Rarity { get; set; }
        public string IconAsset { get; set; }
        public bool IsTrash { get; set; }
        public bool IsBag { get; set; }
        public int Price { get; set; }
        public IDestroyRewardModel DestroyReward { get; set; }
        public bool IsEquipment { get; set; } = false;
        public IEquipmentModel EquipmentInfo { get; set; } = null;

    }
}
