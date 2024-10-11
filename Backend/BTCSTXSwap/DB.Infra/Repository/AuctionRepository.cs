using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.DTO.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class AuctionRepository: IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel>
    {
        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        private const int COMMON_MAX = 128;
        private const int UNCOMMON_MAX = 210;
        private const int RARE_MAX = 242;
        private const int EPIC_MAX = 253;
        private const int LEGENDARY_MAX = 255;

        //private const int MAX_ITEMS = 3;
        private readonly IList<GoblinStatusEnum> STATUS_INVALID = new List<GoblinStatusEnum>() {
            GoblinStatusEnum.Dead,
            GoblinStatusEnum.Claimed,
            GoblinStatusEnum.Fused
        };

        public AuctionRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        private IAuctionModel DbToModel(IAuctionDomainFactory factory, Auction info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildAuctionModel();
            md.Id = info.Id;
            //md.PublicAddress = publicAddress;
            md.IdUser = info.IdUser;
            md.IdBuyer = info.IdBuyer;
            md.IdGoblin = info.IdGoblin;
            if (info.BoxType.HasValue)
            {
                md.BoxType = (GoboxEnum)info.BoxType;
            }
            md.ItemKey = info.ItemKey;
            md.InsertDate = info.InsertDate;
            md.Qtdy = info.Qtdy;
            md.AuctionType = (AuctionEnum) info.AuctionType;
            md.Status = (AuctionStatusEnum) info.Status;
            md.Price = info.Price;
            return md;
        }

        private void ModelToDb(Auction info, IAuctionModel md)
        {
            info.Id = md.Id;
            info.IdUser = md.IdUser;
            info.IdGoblin = md.IdGoblin;
            info.IdBuyer = md.IdBuyer;
            if (md.BoxType.HasValue)
            {
                info.BoxType = (int)md.BoxType;
            }
            info.ItemKey = md.ItemKey;
            info.InsertDate = md.InsertDate;
            info.Qtdy = md.Qtdy;
            info.AuctionType = (int)md.AuctionType;
            info.Status = (int)md.Status;
            info.Price = md.Price;
        }

        public IEnumerable<IAuctionModel> Search(IAuctionDomainFactory factory, IAuctionFilterModel filter, out int balance)
        {
            var q = (
                from a in _goblinContext.Auctions
                join g in _goblinContext.Goblins on a.IdGoblin equals g.Id
                join u in _goblinContext.Users on a.IdUser equals u.Id
                where a.Status == (int)AuctionStatusEnum.Active
                orderby g.Rarity descending, a.Price descending
                select new { Auction = a, Goblin = g, PublicAddress = u.PublicAddress }
            );

            if (filter.Rarity != null)
            {
                switch (filter.Rarity)
                {
                    case RarityEnum.Common:
                        q = q.Where(x => x.Goblin.Rarity < COMMON_MAX);
                        break;
                    case RarityEnum.Uncommon:
                        q = q.Where(x => x.Goblin.Rarity >= COMMON_MAX && x.Goblin.Rarity < UNCOMMON_MAX);
                        break;
                    case RarityEnum.Rare:
                        q = q.Where(x => x.Goblin.Rarity >= UNCOMMON_MAX && x.Goblin.Rarity < RARE_MAX);
                        break;
                    case RarityEnum.Epic:
                        q = q.Where(x => x.Goblin.Rarity >= RARE_MAX && x.Goblin.Rarity < EPIC_MAX);
                        break;
                    case RarityEnum.Legendary:
                        q = q.Where(x => x.Goblin.Rarity >= EPIC_MAX && x.Goblin.Rarity < LEGENDARY_MAX);
                        break;
                }
            }

            if (filter.Genre != null) {
                if (filter.Genre.Value == GenreEnum.Male) {
                    q = q.Where(x => x.Goblin.Genre == "m");
                }
                else if (filter.Genre.Value == GenreEnum.Female)
                {
                    q = q.Where(x => x.Goblin.Genre == "f");
                }
            }

            if (filter.StrengthStart.HasValue && filter.StrengthStart.Value > 0 && 
                filter.StrengthEnd.HasValue && filter.StrengthEnd.Value > 0) {
                q = q.Where(x => x.Goblin.Strength >= filter.StrengthStart.Value 
                    && x.Goblin.Strength <= filter.StrengthEnd.Value);
            }
            else if (filter.StrengthStart.HasValue && filter.StrengthStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Strength >= filter.StrengthStart.Value);
            }
            else if (filter.StrengthEnd.HasValue && filter.StrengthEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Strength <= filter.StrengthEnd.Value);
            }

            if (filter.AgilityStart.HasValue && filter.AgilityStart.Value > 0 &&
                filter.AgilityEnd.HasValue && filter.AgilityEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Agility >= filter.AgilityStart.Value
                    && x.Goblin.Agility <= filter.AgilityEnd.Value);
            }
            else if (filter.AgilityStart.HasValue && filter.AgilityStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Agility >= filter.AgilityStart.Value);
            }
            else if (filter.AgilityEnd.HasValue && filter.AgilityEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Agility <= filter.AgilityEnd.Value);
            }

            if (filter.VigorStart.HasValue && filter.VigorStart.Value > 0 &&
                filter.VigorEnd.HasValue && filter.VigorEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Vigor >= filter.VigorStart.Value
                    && x.Goblin.Vigor <= filter.VigorEnd.Value);
            }
            else if (filter.VigorStart.HasValue && filter.VigorStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Vigor >= filter.VigorStart.Value);
            }
            else if (filter.VigorEnd.HasValue && filter.VigorEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Vigor <= filter.VigorEnd.Value);
            }

            if (filter.PerceptionStart.HasValue && filter.PerceptionStart.Value > 0 &&
                filter.PerceptionEnd.HasValue && filter.PerceptionEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Perception >= filter.PerceptionStart.Value
                    && x.Goblin.Perception <= filter.PerceptionEnd.Value);
            }
            else if (filter.PerceptionStart.HasValue && filter.PerceptionStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Perception >= filter.PerceptionStart.Value);
            }
            else if (filter.PerceptionEnd.HasValue && filter.PerceptionEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Perception <= filter.PerceptionEnd.Value);
            }

            if (filter.IntelligenceStart.HasValue && filter.IntelligenceStart.Value > 0 &&
                filter.IntelligenceEnd.HasValue && filter.IntelligenceEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Intelligence >= filter.IntelligenceStart.Value
                    && x.Goblin.Intelligence <= filter.IntelligenceEnd.Value);
            }
            else if (filter.IntelligenceStart.HasValue && filter.IntelligenceStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Intelligence >= filter.IntelligenceStart.Value);
            }
            else if (filter.IntelligenceEnd.HasValue && filter.IntelligenceEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Intelligence <= filter.IntelligenceEnd.Value);
            }

            if (filter.CharismStart.HasValue && filter.CharismStart.Value > 0 &&
                filter.CharismEnd.HasValue && filter.CharismEnd.Value > 0)
            {
                q = q.Where(x => x.Goblin.Charism >= filter.CharismStart.Value
                    && x.Goblin.Charism <= filter.CharismEnd.Value);
            }
            else if (filter.CharismStart.HasValue && filter.CharismStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Charism >= filter.CharismStart.Value);
            }
            else if (filter.CharismStart.HasValue && filter.CharismStart.Value > 0)
            {
                q = q.Where(x => x.Goblin.Charism <= filter.CharismEnd.Value);
            }

            if (filter.Race != null) {
                q = q.Where(x => x.Goblin.Race == (int)filter.Race.Value);
            }
            if (filter.Hair != null)
            {
                q = q.Where(x => x.Goblin.Hair == (int)filter.Hair.Value);
            }
            if (filter.Ear != null)
            {
                q = q.Where(x => x.Goblin.Ear == (int)filter.Ear.Value);
            }
            if (filter.Eye != null)
            {
                q = q.Where(x => x.Goblin.Eye == (int)filter.Eye.Value);
            }
            if (filter.Mount != null)
            {
                q = q.Where(x => x.Goblin.Mount == (int)filter.Mount.Value);
            }
            if (filter.Skin != null)
            {
                q = q.Where(x => x.Goblin.Skin == (int)filter.Skin.Value);
            }

            int maxPages = 20;//int.Parse(_configuration["Contract:ItensForPage"]);
            balance = q.Count();
            int pg = (filter.Page ?? 1);
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);

            return q.ToList()
                .Skip(skip).Take(maxPages).ToList()
                .Select(i => DbToModel(factory, i.Auction));
        }

        public IEnumerable<IAuctionModel> SearchEquipment(IAuctionDomainFactory factory, IAuctionEquipmentFilterModel filter, out int balance)
        {
            var q = (
                from a in _goblinContext.Auctions
                where a.ItemKey.HasValue 
                    && a.AuctionType == 3 
                    && a.Status == (int)AuctionStatusEnum.Active 
                    && filter.ItemKeys.Contains(a.ItemKey.Value)
                orderby a.Price descending
                select a
            );
            int maxPages = 20;//int.Parse(_configuration["Contract:ItensForPage"]);
            balance = q.Count();
            int pg = (filter.Page ?? 1);
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);

            return q.ToList()
                .Skip(skip).Take(maxPages).ToList()
                .Select(a => DbToModel(factory, a));
        }

        public IEnumerable<IAuctionModel> ListByAuction(IAuctionDomainFactory factory, int auction, int page, out int balance)
        {
            var q = _goblinContext.Auctions
                .Where(x => x.AuctionType == auction
                    && x.Status == (int)AuctionStatusEnum.Active)
                .OrderBy(x => x.Price);
            int maxPages = 20;
            balance = q.Count();
            int pg = page; 
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);

            return q.ToList()
                .Skip(skip).Take(maxPages).ToList()
                .Select(i => DbToModel(factory, i));
        }

        public IEnumerable<IAuctionModel> ListByUser(IAuctionDomainFactory factory, long idUser, int auction)
        {
            return _goblinContext.Auctions
                .Where(x => x.IdUser == idUser 
                    && x.AuctionType == auction
                    && x.Status == (int)AuctionStatusEnum.Active)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }

        public IEnumerable<IAuctionModel> ListSameEquipment(IAuctionDomainFactory factory, long idUser, long itemKey)
        {
            return _goblinContext.Auctions
                .Where(x => x.IdUser != idUser
                    && x.AuctionType == 3
                    && x.ItemKey == itemKey
                    && x.Status == (int)AuctionStatusEnum.Active)
                .OrderBy(x => x.Price)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }

        public IAuctionModel GetById(IAuctionDomainFactory factory, long idAuction)
        {
            return DbToModel(factory, _goblinContext.Auctions.Find(idAuction));
        }

        public IAuctionModel GetLastActiveByIdGoblin(IAuctionDomainFactory factory, long idGoblin)
        {
            return DbToModel(factory, _goblinContext.Auctions
                .Where(x => x.AuctionType == (int) AuctionEnum.Goblin 
                    && x.IdGoblin == idGoblin 
                    && x.Status == (int)AuctionStatusEnum.Active)
                .OrderByDescending(x => x.InsertDate)
                .FirstOrDefault()
            );
        }

        public long Insert(IAuctionModel md)
        {
            Auction info = new Auction();
            ModelToDb(info, md);
            _goblinContext.Auctions.Add(info);
            _goblinContext.SaveChanges();
            md.Id = info.Id;
            return info.Id;
        }

        public long Update(IAuctionModel md)
        {
            Auction info = _goblinContext.Auctions.Find(md.Id);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
            return info.Id;
        }

        public void Delete(long idAunction)
        {
            var info = _goblinContext.Auctions.Find(idAunction);
            _goblinContext.Auctions.Remove(info);
            _goblinContext.SaveChanges();
        }
    }
}
