using Core.Domain;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Items;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Gobox;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoboxService: IGoboxService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoboxDomainFactory _goboxFactory;
        private readonly IGeneService _geneService;
        private readonly IGoblinBreedService _breedService;
        private readonly IFinanceService _financeService;
        private readonly IGoblinService _goblinService;
        private readonly IGLogService _gLogService;
        private readonly IUserItemService _userItemService;

        public GoboxService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGoboxDomainFactory goboxFactory,
            IGeneService geneService,
            IGoblinBreedService breedService,
            IFinanceService financeService,
            IGoblinService goblinService,
            IGLogService gLogService,
            IUserItemService userItemService
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goboxFactory = goboxFactory;
            _geneService = geneService;
            _breedService = breedService;
            _financeService = financeService;
            _goblinService = goblinService;
            _gLogService = gLogService;
            _userItemService = userItemService;
        }

        const string GOBOX_CREDIT = "{0} {1} has been credited to you.";
        const string GOBOX_DEBIT = "{0} {1} has been debited from you.";
        const string ITEM_BOX_DEBIT = "Item box {0} was opened by you.";

        private readonly IList<GoboxPriceInfo> _GOBOX_PRICE = new List<GoboxPriceInfo>() {
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.GoboxCommon,
                Name = "Gobox Common",
                ImageUrl = "https://goblinwars.io/images/boxes/gobox1.png",
                Price = 400
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.GoboxUncommon,
                Name = "Gobox Uncommon",
                ImageUrl = "https://goblinwars.io/images/boxes/gobox2.png",
                Price = 800
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.GoboxRare,
                Name = "Gobox Rare",
                ImageUrl = "https://goblinwars.io/images/boxes/gobox3.png",
                Price = 2400
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.ItemboxCommon,
                Name = "Item Box Common",
                ImageUrl = "",
                Price = int.MaxValue
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.ItemboxUncommon,
                Name = "Item Box Uncommon",
                ImageUrl = "",
                Price = int.MaxValue
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.ItemboxRare,
                Name = "Item Box Rare",
                ImageUrl = "",
                Price = int.MaxValue
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.ItemboxEpic,
                Name = "Item Box Epic",
                ImageUrl = "",
                Price = int.MaxValue
            },
            new GoboxPriceInfo
            {
                BoxType = (int) GoboxEnum.ItemboxLegendary,
                Name = "Item Box Legendary",
                ImageUrl = "",
                Price = int.MaxValue
            },
        };

        private string GetGoboxName(GoboxEnum boxType)
        {
            return _GOBOX_PRICE
                .Where(x => x.BoxType == (int)boxType)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public IList<GoboxInfo> ListByUser(long idUser)
        {
            var md = _goboxFactory.BuildGoboxModel();
            var qtdy = md.ListByUser(idUser).ToDictionary(x => x.BoxType, y => y.Qtdy);

            return _GOBOX_PRICE.Select(x => new GoboxInfo {
                BoxType = x.BoxType,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Qtdy = qtdy.ContainsKey((GoboxEnum)x.BoxType) ? qtdy[(GoboxEnum)x.BoxType] : 0
            }).ToList();
        }

        private bool IsGoblinBox(GoboxEnum boxType)
        {
            switch(boxType)
            {
                case GoboxEnum.GoboxCommon:
                case GoboxEnum.GoboxUncommon:
                case GoboxEnum.GoboxRare:
                    return true;
                default:
                    return false;
            }
        }

        public void Credit(long idUser, GoboxEnum boxType, int Qtdy, bool auction)
        {
            var md = _goboxFactory.BuildGoboxModel().GetByGobox(idUser, boxType);
            if (md == null)
            {
                md = _goboxFactory.BuildGoboxModel();
                md.IdUser = idUser;
                md.BoxType = boxType;
                md.Qtdy = Qtdy;
                md.Insert();
            }
            else
            {
                md.Qtdy += Qtdy;
                md.Update();
            }
            var msg = string.Format(GOBOX_CREDIT, Qtdy, GetGoboxName(boxType));
            _gLogService.AddLog(idUser, msg, auction ? LogType.CancelAuctionBox : IsGoblinBox(boxType) ? LogType.BuyGoblinBox : LogType.BuyItemBox);
        }
        public void Debit(long idUser, GoboxEnum boxType, int Qtdy, bool auction)
        {
            var md = _goboxFactory.BuildGoboxModel().GetByGobox(idUser, boxType);
            if (md == null)
            {
                throw new Exception("Dont have enought boxes");
            }
            
            if (Qtdy > md.Qtdy) {
                throw new Exception("Dont have enought boxes");
            }
            else if (Qtdy == md.Qtdy)
            {
                md.Delete(md.Id);
            }
            else
            {
                md.Qtdy -= Qtdy;
                md.Update();
            }
            var msg = string.Format(GOBOX_DEBIT, Qtdy, GetGoboxName(boxType));
            _gLogService.AddLog(idUser, msg, auction ? LogType.InsertAuctionBox : IsGoblinBox(boxType) ? LogType.OpenGoblinBox : LogType.OpenItemBox);
        }

        public int GetBoxQtdy(long idUser, GoboxEnum boxType)
        {
            var md = _goboxFactory.BuildGoboxModel();
            return md.GetBoxQtdy(idUser, boxType);
        }

        public GoboxInfo GetByGobox(long idUser, GoboxEnum boxType) {
            var md = _goboxFactory.BuildGoboxModel();
            var price = _GOBOX_PRICE.Where(x => x.BoxType == (int)boxType).FirstOrDefault();
            if (price == null)
            {
                return null;
            }
            return new GoboxInfo
            {
                BoxType = price.BoxType,
                Name = price.Name,
                ImageUrl = price.ImageUrl,
                Price = price.Price,
                Qtdy = md.GetBoxQtdy(idUser, boxType)
            };
        }

        private GoboxPriceInfo GetPrice(GoboxEnum boxType)
        {
            return _GOBOX_PRICE.Where(x => x.BoxType == (int)boxType).FirstOrDefault();
        }

        public void BuyBox(long idUser, GoboxEnum boxType, int qtdy)
        {
            var price = GetPrice(boxType);
            if (price == null)
            {
                throw new Exception("Price not found.");
            }
            var gobi = _financeService.GetGobiOnCloud(idUser);
            if (gobi < (price.Price * qtdy))
            {
                throw new Exception("Dont have enough GOBI.");
            }
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    const string MSG_BUY_GOBOX = "Buy {0} {1} for __GOBI({2})__.";
                    string msg = string.Format(MSG_BUY_GOBOX, qtdy, price.Name, (price.Price * qtdy));
                    _financeService.DebitGobi(idUser, price.Price * qtdy, null, msg, LogType.Finance);
                    Credit(idUser, boxType, qtdy, false);
                    /*
                    var md = _goboxFactory.BuildGoboxModel().GetByGobox(idUser, boxType);
                    if (md == null)
                    {
                        md = _goboxFactory.BuildGoboxModel();
                        md.IdUser = idUser;
                        md.BoxType = boxType;
                        md.Qtdy = 1;
                        md.Insert();
                    }
                    else
                    {
                        md.Qtdy++;
                        md.Update();
                    }
                    */
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            _financeService.ActiveWithdrawal(idUser);
        }

        public long OpenBox(long idUser, GoboxEnum boxType)
        {
            IGoblinModel goblin;
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var md = _goboxFactory.BuildGoboxModel().GetByGobox(idUser, boxType);
                    if (md == null || md.Qtdy <= 0)
                    {
                        throw new Exception("You dont have gobox enought.");
                    }
                    Debit(idUser, boxType, 1, false);
                    switch (boxType)
                    {
                        case GoboxEnum.GoboxCommon:
                        case GoboxEnum.GoboxUncommon:
                        case GoboxEnum.GoboxRare:
                            int rarity = _geneService.GetRarityByBox(boxType);
                            goblin = _breedService.GenerateRandom(idUser, rarity);
                            trans.Commit();
                            break;
                        default:
                            throw new NotImplementedException();
                            break;
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            _financeService.ActiveWithdrawal(idUser);
            _goblinService.GenerateImage(goblin.Id);
            return goblin.TokenId;
        }

        //private IList<ItemInfo> OpenItemBoxStep(ItemRarityEnum baseRarity, ItemRarityEnum bonusRarity, ItemRarityEnum previousRarity, int bonusChance)
        private IList<ItemInfo> OpenItemBoxStep(ItemRarityEnum rarity)
        {
            IList<ItemInfo> itens = new List<ItemInfo>();
            for (int i = 0; i < 3; i++)
            {
                itens.Add(_userItemService.GetRandomItem(rarity));
            }
            /*
            itens.Add(_userItemService.GetRandomItem(baseRarity));
            if (new Random().Next(100) <= bonusChance)
                itens.Add(_userItemService.GetRandomItem(bonusRarity));
            else
                itens.Add(_userItemService.GetRandomItem(previousRarity));
            itens.Add(_userItemService.GetRandomItem(previousRarity));
            */
            return itens;
        }

        public IList<ItemInfo> OpenItemBox(long idUser, GoboxEnum boxType)
        {
            IList<ItemInfo> itens;
            //int nextChance = 50;
            string msg = "";
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var md = _goboxFactory.BuildGoboxModel().GetByGobox(idUser, boxType);
                    if (md == null || md.Qtdy <= 0)
                    {
                        throw new Exception("You dont have gobox enought.");
                    }
                    Debit(idUser, boxType, 1, false);
                    switch (boxType)
                    {
                        case GoboxEnum.ItemboxCommon:
                            itens = OpenItemBoxStep(ItemRarityEnum.Common);
                            msg = string.Format(ITEM_BOX_DEBIT, "Common");
                            break;
                        case GoboxEnum.ItemboxUncommon:
                            itens = OpenItemBoxStep(ItemRarityEnum.Uncommon);
                            msg = string.Format(ITEM_BOX_DEBIT, "Uncommon");
                            break;
                        case GoboxEnum.ItemboxRare:
                            itens = OpenItemBoxStep(ItemRarityEnum.Rare);
                            msg = string.Format(ITEM_BOX_DEBIT, "Rare");
                            break;
                        case GoboxEnum.ItemboxEpic:
                            itens = OpenItemBoxStep(ItemRarityEnum.Epic);
                            msg = string.Format(ITEM_BOX_DEBIT, "Epic");
                            break;
                        case GoboxEnum.ItemboxLegendary:
                            itens = OpenItemBoxStep(ItemRarityEnum.Legendary);
                            msg = string.Format(ITEM_BOX_DEBIT, "Legendary");
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    foreach(var item in itens)
                    {
                        _userItemService.Add(idUser, item.Key, 1);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            _gLogService.AddLog(idUser, msg, LogType.OpenItemBox);
            return itens;
        }
    }
}
