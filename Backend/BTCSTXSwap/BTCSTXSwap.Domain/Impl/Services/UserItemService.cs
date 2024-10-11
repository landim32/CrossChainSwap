using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.Domain.Impl.Models.Equipments.Armor;
using BTCSTXSwap.Domain.Impl.Models.Equipments.Weapon;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCSTXSwap.Domain.Impl.Models.Items;
using Core.Domain;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class UserItemService : IUserItemService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserItemDomainFactory _userItemFactory;
        private readonly IItemListDomainFactory _itemListFactory;
        private readonly IUserService _userService;
        private readonly IItemService _itemService;
        private readonly IGLogService _logService;
        private readonly IGoldFinanceService _goldFinanceService;

        private const int MAX_COLUMN = 6;
        private const int MAX_ROW = 7;

        /*
        private readonly IList<int> COMMON_ITENS;
        private readonly IList<int> UNCOMMON_ITENS;
        private readonly IList<int> RARE_ITENS;
        private readonly IList<int> EPIC_ITENS;
        private readonly IList<int> LEGENDARY_ITENS;
        */

        private const string LOG_ADD_ITEM = "{0} __ITEM({1})__ have been added to the inventory.";
        private const string LOG_CONSUME_ITEM = "__ITEM({1})__ have been consumed from inventory.";
        private const string LOG_DESTROY_ITEM = "{0} __ITEM({1})__ have been destroyed.";
        private const string LOG_SELL_ITEM = "{0} __ITEM({1})__ have been sold for __GOLD({2})__.";
        private const string LOG_GOLD_CREDIT = "__GOLD({0})__ has credited.";
        private const string LOG_GOLD_DEBIT = "__GOLD({0})__ has debited.";

        private Random _rand = new Random();

        public UserItemService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IUserItemDomainFactory userItemFactory,
            IItemListDomainFactory itemListFactory,
            IItemService itemService,
            IGLogService logService,
            IGoldFinanceService goldFinanceService
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _userItemFactory = userItemFactory;
            _itemListFactory = itemListFactory;
            _itemService = itemService;
            _logService = logService;
            _goldFinanceService = goldFinanceService;

            /*
            COMMON_ITENS = new List<int>() {BodyCategoryModel.COMMON_MINING, FootCategoryModel.COMMON_MINING, HandCategoryModel.COMMON_MINING,
                HelmetCategoryModel.COMMON_MINING, PickaxeCategoryModel.COMMON_BRONZE_PICKAXE };
            UNCOMMON_ITENS = new List<int>() {BodyCategoryModel.UNCOMMON_MINING, FootCategoryModel.UNCOMMON_MINING, HandCategoryModel.UNCOMMON_MINING,
                HelmetCategoryModel.UNCOMMON_MINING, PickaxeCategoryModel.UNCOMMON_BRONZE_PICKAXE };
            RARE_ITENS = new List<int>() {BodyCategoryModel.RARE_MINING, FootCategoryModel.RARE_MINING, HandCategoryModel.RARE_MINING,
                HelmetCategoryModel.RARE_MINING, PickaxeCategoryModel.RARE_BRONZE_PICKAXE };
            EPIC_ITENS = new List<int>() {BodyCategoryModel.EPIC_MINING, FootCategoryModel.EPIC_MINING, HandCategoryModel.EPIC_MINING,
                HelmetCategoryModel.EPIC_MINING, PickaxeCategoryModel.EPIC_BRONZE_PICKAXE };
            LEGENDARY_ITENS = new List<int>() {BodyCategoryModel.LEGENDARY_MINING, FootCategoryModel.LEGENDARY_MINING, HandCategoryModel.LEGENDARY_MINING,
                HelmetCategoryModel.LEGENDARY_MINING, PickaxeCategoryModel.LEGENDARY_BRONZE_PICKAXE };
            */
        }

        public UserItemInfo GetById(long idItem)
        {
            return ModelToDto(_userItemFactory.BuildUserItemModel().GetById(idItem));
        }

        public UserItemInfo GetByPosition(long idUser, int x, int y)
        {
            return ModelToDto(_userItemFactory.BuildUserItemModel().GetByPosition(idUser, x, y));
        }

        public UserItemInfo GetByKey(long idUser, long key, bool forced = false)
        {
            var md = _userItemFactory.BuildUserItemModel().GetByKey(idUser, key);
            if (md == null && forced)
            {
                md = _userItemFactory.BuildUserItemModel();
                md.IdUser = idUser;
                md.ItemKey = key;
                md.PosX = 0;
                md.PosY = 0;
                md.Qtde = 0;
            }
            return ModelToDto(md);
        }

        private Point GetEmptyPosition(long idUser)
        {
            var allItems = _userItemFactory
                .BuildUserItemModel()
                .ListById(idUser)
                .OrderBy(i => i.PosY)
                .ThenBy(b => b.PosX)
                .ToList();
            for (int y = 0; y < MAX_ROW; y++)
            {
                for (int x = 0; x < MAX_COLUMN; x++)
                {
                    if (!allItems.Where(i => i.PosX == x && i.PosY == y).Any()) {
                        return new Point(x, y);
                    }
                }
            }
            throw new Exception("Your bag is full");
        }

        public int Add(long idUser, long key, int qtde)
        {
            var md = _userItemFactory
                .BuildUserItemModel()
                .GetByKey(idUser, key);
            if (md == null)
            {
                var p = GetEmptyPosition(idUser);
                md = _userItemFactory.BuildUserItemModel();
                md.IdUser = idUser;
                md.ItemKey = key;
                md.PosX = p.X;
                md.PosY = p.Y;
                md.Qtde = 0;
            }
            return Add(md, qtde);
        }

        private int Add(IUserItemModel item, int qtde)
        {
            item.Qtde += qtde;
            item.Save();
            _logService.AddLog(item.IdUser, string.Format(LOG_ADD_ITEM, qtde, item.ItemKey), Core.LogType.Item);
            return item.Qtde;
        }

        private IList<IUserItemModel> ListDestroyReward(IItemModel md) {
            _rand = new Random();
            var result = new List<IUserItemModel>();
            if (md.DestroyReward.Qtdy > 0)
            {
                var result100Percent = md.DestroyReward
                    .Items
                    .Where(x => x.Percent == 100)
                    .Take(md.DestroyReward.Qtdy)
                    .ToList();
                result100Percent.Shuffle();
                foreach (var reward in result100Percent)
                {
                    var ui = _userItemFactory.BuildUserItemModel();
                    ui.ItemKey = reward.ItemKey;
                    ui.Qtde = reward.QtdeMin < reward.QtdeMax ? _rand.Next(reward.QtdeMin, reward.QtdeMax) : reward.QtdeMax;
                    result.Add(ui);
                }
                if (md.DestroyReward.Qtdy > result.Count)
                {
                    var resultOthers = md.DestroyReward
                        .Items
                        .Where(x => x.Percent != 100)
                        .OrderByDescending(x => _rand.Next(1, x.Percent))
                        .Take(md.DestroyReward.Qtdy - result.Count)
                        .ToList();
                    resultOthers.Shuffle();
                    foreach (var reward in resultOthers)
                    {
                        var ui = _userItemFactory.BuildUserItemModel();
                        ui.ItemKey = reward.ItemKey;
                        ui.Qtde = reward.QtdeMin < reward.QtdeMax ? _rand.Next(reward.QtdeMin, reward.QtdeMax) : reward.QtdeMax;
                        result.Add(ui);
                    }
                }
            }
            else
            {
                var rewardAll = md.DestroyReward.Items.ToList();
                rewardAll.Shuffle();
                foreach (var reward in rewardAll)
                {
                    if (reward.Percent == 100 || _rand.Next(1, reward.Percent) <= reward.Percent)
                    {
                        var ui = _userItemFactory.BuildUserItemModel();
                        ui.ItemKey = reward.ItemKey;
                        ui.Qtde = reward.QtdeMin < reward.QtdeMax ? _rand.Next(reward.QtdeMin, reward.QtdeMax) : reward.QtdeMax;
                        result.Add(ui);
                    }
                }
            }
            return result;
        }

        private UserItemInfo ModelToDto(IUserItemModel md)
        {
            if (md == null)
            {
                return null;
            }
            return new UserItemInfo
            {
                IdItem = md.IdItem,
                IdUser = md.IdUser,
                ItemKey = md.ItemKey,
                PosX = md.PosX,
                PosY = md.PosY,
                Qtde = md.Qtde,
                Item = _itemService.GetItemByKey((int)md.ItemKey)
            };
        }

        public IList<UserItemInfo> List(long idUser) {
            return _userItemFactory
                .BuildUserItemModel()
                .ListById(idUser)
                .Select(x => ModelToDto(x))
                .ToList();
        }

        public ItemDestroyResult DestroyItem(long idUser, long idItem, int qtde)
        {
            var result = new List<IUserItemModel>();
            _rand = new Random();
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var md = _userItemFactory.BuildUserItemModel().GetById(idItem);
                    if (md.IdUser != idUser)
                    {
                        throw new Exception("Item is not your!");
                    }
                    if (md.IdItem <= 0)
                    {
                        throw new Exception("Item not exists!");
                    }
                    if ((md.Qtde - qtde) < 0)
                    {
                        throw new Exception("Not enough items!");
                    }
                    if (!md.GetItem().IsBag)
                    {
                        throw new Exception("You cant destroy this item!");
                    }

                    var itemInfo = md.GetItem();
                    for (var i = 0; i < qtde; i++)
                    {
                        result.AddRange(ListDestroyReward(itemInfo));
                    }

                    var items = result
                        .GroupBy(k => k.ItemKey)
                        .Select(g => new {
                            ItemKey = g.Key,
                            Qtde = g.Sum(i => i.Qtde)
                        })
                        .ToList();

                    result.Clear();
                    foreach (var i in items)
                    {
                        var ui = _userItemFactory.BuildUserItemModel();
                        ui.IdUser = md.IdUser;
                        ui.ItemKey = i.ItemKey;
                        ui.Qtde = i.Qtde;
                        result.Add(ui);
                        Add(md.IdUser, i.ItemKey, i.Qtde);
                    }

                    if(itemInfo.DestroyReward.GoldMax > 0)
                    {
                        var goldValue = _rand.Next(itemInfo.DestroyReward.GoldMin, itemInfo.DestroyReward.GoldMax);
                        _goldFinanceService.AddGoldTransaction(idUser, goldValue, string.Format(LOG_GOLD_CREDIT, goldValue), false);
                    }

                    md.Qtde -= qtde;
                    if (md.Qtde == 0)
                    {
                        md.Delete();
                    }
                    else
                    {
                        md.Save();
                    }
                    _logService.AddLog(idUser, string.Format(LOG_DESTROY_ITEM, qtde, md.ItemKey), Core.LogType.Item);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return new ItemDestroyResult
            {
                Sucesso = true,
                Items = result.Select(x => ModelToDto(x)).ToList()
            };
        }

        public int Remove(long idUser, long key, int qtde)
        {
            var md = _userItemFactory.BuildUserItemModel().GetByKey(idUser, key);
            if (md == null)
            {
                throw new Exception("Item is empty.");
            }
            if (md.Qtde - qtde < 0)
            {
                throw new Exception("Dont have enougth items.");
            }
            md.Qtde -= qtde;
            if (md.Qtde == 0)
            {
                md.Delete();
            }
            else
            {
                md.Save();
            }
            _logService.AddLog(idUser, string.Format(LOG_CONSUME_ITEM, qtde, key), Core.LogType.Item);
            return md.Qtde;
        }

        public bool Move(long idUser, long idItem, int x, int y)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var md = _userItemFactory.BuildUserItemModel().GetById(idItem);
                    if (md == null)
                    {
                        return false;
                    }
                    if (md.GetByPosition(idUser, x, y) != null)
                    {
                        return false;
                    }
                    md.PosX = x;
                    md.PosY = y;
                    md.Save();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return true;
        }

        public void Sell(long idUser, long key, int qtde)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var trash = _userItemFactory.BuildUserItemModel().GetByKey(idUser, key);
                    if (trash == null)
                    {
                        throw new Exception("You dont have this item.");
                    }
                    Remove(idUser, trash.ItemKey, qtde);
                    var u = _userService.GetUSerByID(idUser);
                    var goldValue = trash.GetItem().Price * qtde;
                    _goldFinanceService.AddGoldTransaction(idUser, goldValue, string.Format(LOG_GOLD_CREDIT, goldValue), false);
                    _logService.AddLog(idUser, string.Format(LOG_SELL_ITEM, qtde, key, goldValue), Core.LogType.Item);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void SellAllTrash(long idUser)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var gold = 0;
                    var trashs = _userItemFactory.BuildUserItemModel().ListTrashByUser(idUser);
                    foreach (var trash in trashs)
                    {
                        gold += trash.GetItem().Price * trash.Qtde;
                        trash.Delete();
                    }

                    var u = _userService.GetUSerByID(idUser);
                    _goldFinanceService.AddGoldTransaction(idUser, gold, string.Format(LOG_GOLD_CREDIT, gold), false);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /*
        private ItemInfo RandomItemImpl(IList<int> lstItem)
        {
            var randomItem = new Random().Next(lstItem.Count);
            return _itemService.GetItemByKey(lstItem.ElementAt(randomItem));
        }
        */

        public ItemRarityEnum GetItemRarityByBase(ItemRarityEnum rarity)
        {
            int r = _rand.Next(0, 10000);
            ItemRarityEnum ret = ItemRarityEnum.Common;
            switch (rarity)
            {
                case ItemRarityEnum.Common:
                    if (r <= 5022)
                    {
                        ret = ItemRarityEnum.Common;
                    }
                    else if (r > 5022 && r <= 8237)
                    {
                        ret = ItemRarityEnum.Uncommon;
                    }
                    else if (r > 8237 && r <= 9491)
                    {
                        ret = ItemRarityEnum.Rare;
                    }
                    else if (r > 9491 && r <= 9922)
                    {
                        ret = ItemRarityEnum.Epic;
                    }
                    else if (r > 9922 && r <= 10000)
                    {
                        ret = ItemRarityEnum.Legendary;
                    }
                    break;
                case ItemRarityEnum.Uncommon:
                    if (r <= 6486)
                    {
                        ret = ItemRarityEnum.Uncommon;
                    }
                    else if (r > 6486 && r <= 9005)
                    {
                        ret = ItemRarityEnum.Rare;
                    }
                    else if (r > 9005 && r <= 9871)
                    {
                        ret = ItemRarityEnum.Epic;
                    }
                    else if (r > 9871 && r <= 10000)
                    {
                        ret = ItemRarityEnum.Legendary;
                    }
                    break;
                case ItemRarityEnum.Rare:
                    if (r <= 7113)
                    {
                        ret = ItemRarityEnum.Rare;
                    }
                    else if (r > 7113 && r <= 9558)
                    {
                        ret = ItemRarityEnum.Epic;
                    }
                    else if (r > 9558 && r <= 10000)
                    {
                        ret = ItemRarityEnum.Legendary;
                    }
                    break;
                case ItemRarityEnum.Epic:
                    if (r <= 8469)
                    {
                        ret = ItemRarityEnum.Epic;
                    }
                    else if (r > 8469 && r <= 10000)
                    {
                        ret = ItemRarityEnum.Legendary;
                    }
                    break;
                case ItemRarityEnum.Legendary:
                    ret = ItemRarityEnum.Legendary;
                    break;
                default:
                    throw new Exception("This box is not a goblin box");
            }
            return ret;
        }

        public ItemInfo GetRandomItem(ItemRarityEnum rarity)
        {
            var newRarity = GetItemRarityByBase(rarity);
            var items = _itemListFactory
                .BuildItemListModel()
                .ListAll()
                .Where(x => x.IsEquipment 
                    && x.EquipmentInfo != null 
                    && x.Rarity == newRarity
                )
                .Select(x => x.Key)
                .ToList();
            items.Shuffle();
            return _itemService.GetItemByKey(items.FirstOrDefault());
        }
    }
}
