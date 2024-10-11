using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class GoblinRepository : IGoblinRepository<IGoblinModel, IGoblinDomainFactory>
    {
        private const int COMMON_MAX = 128;
        private const int UNCOMMON_MAX = 210;
        private const int RARE_MAX = 242;
        private const int EPIC_MAX = 253;
        private const int LEGENDARY_MAX = 255;

        private GoblinWarsContext _goblinContext;
        private readonly IConfiguration _configuration;
        private readonly IList<GoblinStatusEnum> STATUS_INVALID = new List<GoblinStatusEnum>() {
            GoblinStatusEnum.Dead,
            GoblinStatusEnum.Claimed,
            GoblinStatusEnum.Fused
        };

        public GoblinRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }

        public long GetIdByTokenId(long tokenId)
        {
            return _goblinContext.Goblins
                .Where(x => x.TokenId == tokenId)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        private IGoblinModel EntityToModel(IGoblinDomainFactory factory, Goblin g)
        {
            if (g == null)
                return null;
            var md = factory.BuildGoblinModel();
            var user = _goblinContext.Users.Find(g.IdUser);
            md.Id = g.Id;
            md.TokenId = g.TokenId;
            if (g.Genes != null)
            {
                md.Genes = new BigInteger(g.Genes);
            }
            //md.Ativo = g.Ativo == 1 ? true : false;
            //md.TokenId = g.TokenId;
            md.TokenIdFatherTmp = g.TokenIdFatherTmp;
            md.TokenIdMotherTmp = g.TokenIdMotherTmp;
            md.TokenIdSpouseTmp = g.TokenIdSpouseTmp;
            md.IdFather = g.IdFather;
            if (g.IdFather.HasValue) {
                md.FatherTokenId = _goblinContext.Goblins
                    .Where(x => x.Id == g.IdFather.Value)
                    .Select(x => x.TokenId)
                    .FirstOrDefault();
            }
            md.IdMother = g.IdMother;
            if (g.IdMother.HasValue)
            {
                md.MotherTokenId = _goblinContext.Goblins
                    .Where(x => x.Id == g.IdMother.Value)
                    .Select(x => x.TokenId)
                    .FirstOrDefault();
            }
            md.IdSpouse = g.IdSpouse;
            if (g.IdSpouse.HasValue)
            {
                md.SpouseTokenId = _goblinContext.Goblins
                    .Where(x => x.Id == g.IdSpouse.Value)
                    .Select(x => x.TokenId)
                    .FirstOrDefault();
            }
            md.IdUser = g.IdUser;
            md.Username = user.Name;
            md.Name = g.Name;
            //md.Busy = g.Busy;
            md.Genre = !string.IsNullOrEmpty(g.Genre) ? (GenreEnum)(g.Genre[0]) : GenreEnum.Undefined;
            md.Race = (RaceEnum)g.Race;
            md.Hair = (RaceEnum)g.Hair;
            md.Ear = (RaceEnum)g.Ear;
            md.Eye = (RaceEnum)g.Eye;
            md.Mount = (RaceEnum)g.Mount;
            md.Skin = (RaceEnum)g.Skin;
            md.EyeColor = Color.FromArgb(g.EyeColor);
            md.SkinColor = Color.FromArgb(g.SkinColor);
            md.HairColor = Color.FromArgb(g.HairColor);
            md.Strength = g.Strength;
            md.Agility = g.Agility;
            md.Vigor = g.Vigor;
            md.Intelligence = g.Intelligence;
            md.Charism = g.Charism;
            md.Perception = g.Perception;

            md.IdTokenOld = new BigInteger(g.IdToken);
            md.UserAddress = user.PublicAddress;
            md.IdTokenFather = new BigInteger(g.IdTokenFather);
            md.IdTokenMother = new BigInteger(g.IdTokenMother);
            md.CooldownTimeOld = new BigInteger(g.ContractCooldownTime);
            md.Inventory = new BigInteger(g.ContractInventory);
            md.Bag = new BigInteger(g.ContractBag);
            md.Mods = new BigInteger(g.ContractMods);
            md.SpouseWithId = new BigInteger(g.ContractSpouse);
            md.SonsCount = new BigInteger(g.ContractSonsCount);
            md.LastUpdateTime = new BigInteger(g.ContractLastUpdateTime);

            md.LastUserChange = g.LastUserChange;
            md.Birthday = g.Birthday;
            md.CooldownTime = g.CooldownTime;
            md.BaseImagePath = g.BaseImagePath;
            /*
            if(_goblinContext.Auctions.Where(x => x.Status == 0 && x.TokenId == g.IdToken).Any())
            {
                md.Status = GoblinStatusEnum.ForSale;
            }
            else
            {
            */
                md.Status = (GoblinStatusEnum)g.Status;
            //}
            md.Rarity = g.Rarity;
            md.HasImageMine = g.HasImageMine;
            md.Minted = g.Minted;
            return md;
        }

        private void ModelToEntity(IGoblinModel goblin, Goblin g)
        {
            g.Id = goblin.Id;
            g.Genes = goblin.Genes.ToByteArray();
            g.IdUser = goblin.IdUser;
            g.TokenId = goblin.TokenId;
            g.TokenIdFatherTmp = goblin.TokenIdFatherTmp;
            g.TokenIdMotherTmp = goblin.TokenIdMotherTmp;
            g.IdFather = goblin.IdFather;
            g.IdMother = goblin.IdMother;
            g.CooldownTime = goblin.CooldownTime;
            g.Birthday = goblin.Birthday;
            g.LastUserChange = goblin.LastUserChange;
            g.Xp = goblin.Xp;
            g.Name = goblin.Name;
            //g.Busy = goblin.Busy;
            g.Genre = ((char)goblin.Genre).ToString();
            g.Race = (int)goblin.Race;
            g.Hair = (int)goblin.Hair;
            g.Ear = (int)goblin.Ear;
            g.Eye = (int)goblin.Eye;
            g.Mount = (int)goblin.Mount;
            g.Skin = (int)goblin.Skin;
            g.HairColor = goblin.HairColor.ToArgb();
            g.SkinColor = goblin.SkinColor.ToArgb();
            g.EyeColor = goblin.EyeColor.ToArgb();
            g.Strength = goblin.Strength;
            g.Agility = goblin.Agility;
            g.Vigor = goblin.Vigor;
            g.Intelligence = goblin.Intelligence;
            g.Charism = goblin.Charism;
            g.Perception = goblin.Perception;

            g.IdToken = goblin.IdTokenOld.ToByteArray();
            g.IdTokenFather = goblin.IdTokenFather.ToByteArray();
            g.IdTokenMother = goblin.IdTokenMother.ToByteArray();
            g.ContractInventory = goblin.Inventory.ToByteArray();
            g.ContractBag = goblin.Bag.ToByteArray();
            g.ContractMods = goblin.Mods.ToByteArray();
            g.ContractSpouse = goblin.SpouseWithId.ToByteArray();
            g.ContractSonsCount = goblin.SonsCount.ToByteArray();
            g.ContractLastUpdateTime = goblin.LastUpdateTime.ToByteArray();
            g.ContractCooldownTime = goblin.CooldownTimeOld.ToByteArray();

            g.Status = (int)goblin.Status;
            g.Rarity = goblin.Rarity;
            g.HasImageMine = goblin.HasImageMine;
            g.BaseImagePath = goblin.BaseImagePath;
            g.Minted = goblin.Minted;
        }

        public IGoblinModel GetByUid(IGoblinDomainFactory factory, long idGoblin)
        {
            return EntityToModel(factory, 
                _goblinContext.Goblins
                .Where(x => x.Id == idGoblin 
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .FirstOrDefault());
        }
        public IGoblinModel GetByTokenId(IGoblinDomainFactory factory, long idToken, bool forced = false)
        {
            var row = _goblinContext.Goblins
                .Where(x => x.TokenId == idToken 
                    && (forced || !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status)))
                .FirstOrDefault();
            if(row != null)
                return EntityToModel(factory, row);
            return null;
        }
        public IGoblinModel GetByOldTokenId(IGoblinDomainFactory factory, BigInteger oldTokenId)
        {
            var row = _goblinContext.Goblins
                .Where(x => x.IdToken == oldTokenId.ToByteArray() 
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .FirstOrDefault();
            if (row != null)
                return EntityToModel(factory, row);
            return null;
        }
        public int GetSonsCount(long idGoblin)
        {
            return _goblinContext.Goblins
                .Where(x => (x.IdFather == idGoblin || x.IdMother == idGoblin) 
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .Count();
        }

        public IEnumerable<IGoblinModel> ListByUserWithCursor(IGoblinDomainFactory factory, long idUser, int cursor, int limit)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser 
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .Skip(cursor).Take(limit)
                .ToList()
                .Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> ListByUser(IGoblinDomainFactory factory, long idUser, int page, int itemsPerPage, out int totalPages)
        {
            var q = _goblinContext.Goblins
                .Where(x => x.IdUser == idUser 
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .OrderByDescending(x => x.Rarity);
            //int maxPages = int.Parse(_configuration["Contract:ItensForPage"]);
            int balance = q.Count();
            int pg = page;
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = itemsPerPage * (pg - 1);
            totalPages = (int)Math.Ceiling((decimal)balance / (decimal)itemsPerPage);

            return q.Skip(skip).Take(itemsPerPage).ToList().Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> ListSons(IGoblinDomainFactory factory, long idGoblin, int page, out int totalPages)
        {
            var q = _goblinContext.Goblins
                .Where(x => (x.IdFather == idGoblin || x.IdMother == idGoblin)
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status));
            int maxPages = int.Parse(_configuration["Contract:ItensForPage"]);
            int balance = q.Count();
            int pg = page;
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);
            totalPages = (int)Math.Ceiling((decimal)(balance / maxPages));

            return q.Skip(skip).Take(maxPages).ToList().Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> ListBrothers(IGoblinDomainFactory factory, long idGoblin, int page, out int totalPages)
        {
            var g = _goblinContext.Goblins.Where(x => x.Id == idGoblin).FirstOrDefault();
            var q = _goblinContext.Goblins
                 .Where(x => (x.IdFather == g.IdFather || x.IdMother == g.IdMother) && x.Id != idGoblin
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status));
            int maxPages = int.Parse(_configuration["Contract:ItensForPage"]);
            int balance = q.Count();
            int pg = page;
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);
            totalPages = (int)Math.Ceiling((decimal)(balance / maxPages));

            return q.Skip(skip).Take(maxPages).ToList().Select(x => EntityToModel(factory, x));
        }

        [Obsolete]
        public IEnumerable<IGoblinModel> ListByUserOld(IGoblinDomainFactory factory, long idUser)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .ToList()
                .Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> ListMiningByUser(IGoblinDomainFactory factory, long idUser, int cursor, int limit)
        {
            return _goblinContext.Goblins
                //.Where(x => x.IdUser == idUser && x.Status == 3 && x.Ativo == 1)
                .Where(x => x.IdUser == idUser && x.Status == (int)GoblinStatusEnum.Minning)
                .ToList().Skip(cursor).Take(limit)
                .Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> ListCanMiningByUser(IGoblinDomainFactory factory, long idUser, int cursor, int limit)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .ToList()
                .Select(x => EntityToModel(factory, x))
                .Where(x => x.IsAvaliable())
                .Skip(cursor).Take(limit);
        }

        public IEnumerable<IGoblinModel> ListAvaliableByUser(IGoblinDomainFactory factory, long idUser)
        {
            return _goblinContext.Goblins
                .Where(x => x.IdUser == idUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .ToList()
                .Select(x => EntityToModel(factory, x))
                .Where(x => x.IsAvaliable());
        }

        public IEnumerable<IGoblinModel> ListGoblinCanBreed(IGoblinDomainFactory factory, long idGoblin, int cursor, int limit)
        {
            var g = _goblinContext.Goblins.Where(x => x.Id == idGoblin).FirstOrDefault();

            var q = _goblinContext.Goblins.Where(x => x.IdUser == g.IdUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status));
            if (g.Genre == ((char)GenreEnum.Male).ToString())
            {
                q = q.Where(x => x.Genre == "F");
            }
            else if (g.Genre == ((char)GenreEnum.Female).ToString())
            {
                q = q.Where(x => x.Genre == "M");
            }
            q = q.Where(x => !(g.IdFather.HasValue && (x.IdFather == g.IdFather || x.IdFather == g.Id || x.Id == g.IdFather)));
            q = q.Where(x => !(g.IdMother.HasValue && (x.IdMother == g.IdMother || x.IdMother == g.Id || x.Id == g.IdMother)));
            return q
                .ToList()
                .Select(x => EntityToModel(factory, x))
                .Where(x => x.IsAvaliable())
                .Skip(cursor)
                .Take(limit);
            /*
            return q
                .Skip(cursor)
                .Take(limit)
                .ToList()
                .Select(x => EntityToModel(factory, x));
            */
        }

        /*
        public bool IsBusy(int idGoblin)
        {
            using (var context = _goblinContext)
            {
                return (
                    from a in context.Actions
                    join e in context.ActionGoblins on a.Id equals e.IdAction
                    where e.IdGoblin == idGoblin
                        && a.Status == (int)ActionStatusEnum.Executing
                        && a.DateTerminate > DateTime.UtcNow
                    select a
                ).Any();
            }
        }
        */

        public void Insert(IGoblinModel goblin)
        {
            Goblin g = new Goblin();
            ModelToEntity(goblin, g);
            _goblinContext.Add(g);
            _goblinContext.SaveChanges();
        }
        public void Update(IGoblinModel goblin)
        {
            Goblin g = _goblinContext.Goblins.Find(goblin.Id);
            if (g == null)
            {
                throw new Exception("Goblin not found");
            }
            ModelToEntity(goblin, g);
            _goblinContext.Update(g);
            _goblinContext.SaveChanges();
        }

        public void Save(IGoblinModel goblin)
        {
            bool insert = false;
            Goblin g = null;
            if (goblin.Id > 0)
            {
                g = _goblinContext.Goblins.Where(x => x.Id == goblin.Id).FirstOrDefault();
            }
            if (g == null)
            {
                g = new Goblin();
                insert = true;
                //_goblinContext.Add(g);
            }
            ModelToEntity(goblin, g);
            if (insert)
            {
                _goblinContext.Add(g);
            }
            _goblinContext.SaveChanges();
        }

        /*
        public void DisableGoblin(long idUser, BigInteger idToken)
        {
            var g = _goblinContext.Goblins.Where(x => x.IdToken == idToken.ToByteArray() && x.IdUser == idUser).FirstOrDefault();
            g.Ativo = 0;
            //g.Status = 0;
            g.ContractLastUpdateTime = new BigInteger(0).ToByteArray();
            _goblinContext.Goblins.Update(g);
            _goblinContext.SaveChanges();
        }

        public void EnableGoblin(long idUser, BigInteger idToken)
        {
            var g = _goblinContext.Goblins.Where(x => x.IdToken == idToken.ToByteArray() && x.IdUser == idUser).FirstOrDefault();
            g.Ativo = 1;
            _goblinContext.Goblins.Update(g);
            _goblinContext.SaveChanges();
        }
        */

        public IEnumerable<IGoblinModel> GetAllUserGoblins(long idUser, IGoblinDomainFactory factory)
        {
            return _goblinContext.Goblins
                //.Where(x => x.IdUser == idUser && x.Ativo == 1)
                .Where(x => x.IdUser == idUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status))
                .ToList()
                .Select(x => EntityToModel(factory, x));
        }

        public IEnumerable<IGoblinModel> GetGoblinsCanFuse(long idGoblin, long idUser, IGoblinDomainFactory factory)
        {
            var goblin = _goblinContext.Goblins.Find(idGoblin);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            var goblinRarity = GoblinUtils.GetGoblinEnumRarity(goblin.Rarity);
            var q = _goblinContext.Goblins
                .Where(x => x.Id != idGoblin && x.IdUser == idUser
                    && !STATUS_INVALID.Contains((GoblinStatusEnum)x.Status));
            /*
            var goblins = _goblinContext.Goblins
                .Where(x => x.Id != idGoblin && x.IdUser == idUser && x.Ativo == 1 && (x.Busy == null || x.Busy < DateTime.UtcNow)
                    && x.Status != 3 && !_goblinContext.Auctions.Where(y => y.Status == 0).Any())
                .ToList();
            */
            switch (goblinRarity)
            {
                case RarityEnum.Common:
                    q = q.Where(x => x.Rarity < COMMON_MAX);
                    break;
                case RarityEnum.Uncommon:
                    q = q.Where(x => x.Rarity >= COMMON_MAX && x.Rarity < UNCOMMON_MAX);
                    break;
                case RarityEnum.Rare:
                    q = q.Where(x => x.Rarity >= UNCOMMON_MAX && x.Rarity < RARE_MAX);
                    break;
                case RarityEnum.Epic:
                    q = q.Where(x => x.Rarity >= RARE_MAX && x.Rarity < EPIC_MAX);
                    break;
                case RarityEnum.Legendary:
                    q = q.Where(x => x.Rarity >= EPIC_MAX && x.Rarity < LEGENDARY_MAX);
                    break;
            }
            //goblins = goblins.Where(x => Utils.UnixTimeStampToDateTime(double.Parse(new BigInteger(x.ContractCooldownTime).ToString())) < DateTime.UtcNow).ToList();
            return q
                .ToList()
                .Select(x => EntityToModel(factory, x))
                .Where(x => x.IsAvaliable());
        }
        public long GetLastToken()
        {
            if(_goblinContext.Goblins.Count() > 0)
            {
                return _goblinContext.Goblins.Select(x => x.TokenId).Max();
            } else
            {
                return 0;
            }
            
        }

        public bool IsOwner(long idUser, long idGoblin = 0, long tokenId = 0)
        {
            if (idGoblin > 0)
            {
                return (
                    from g in _goblinContext.Goblins
                    where g.IdUser == idUser && g.Id == idGoblin
                    select g.Id
                ).Any();
            }
            else if (tokenId > 0)
            {
                return (
                    from g in _goblinContext.Goblins
                    join u in _goblinContext.Users on g.IdUser equals u.Id
                    where g.IdUser == idUser && g.TokenId == tokenId
                    select g.Id
                ).Any();
            }
            else
            {
                throw new Exception("Id or Token is not inform");
            }
        }

        public void ChangeUser(long idGoblin, long newIdUser)
        {
            var goblin = _goblinContext.Goblins.Find(idGoblin);
            goblin.IdUser = newIdUser;
            goblin.CooldownTime = DateTime.UtcNow.AddHours(1);
            _goblinContext.Goblins.Update(goblin);
            _goblinContext.SaveChanges();
        }

        public void DoMint(long idGoblin, long IdUser)
        {
            var goblin = _goblinContext.Goblins.Find(idGoblin);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            if (goblin.IdUser != IdUser)
            {
                goblin.IdUser = IdUser;
                goblin.CooldownTime = DateTime.UtcNow.AddHours(3);
            }
            goblin.Status = (int)GoblinStatusEnum.Claimed;
            goblin.Minted = true;
            _goblinContext.Goblins.Update(goblin);
            _goblinContext.SaveChanges();
        }

        public void Deposit(long idGoblin, long IdUser)
        {
            var goblin = _goblinContext.Goblins.Find(idGoblin);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            if (goblin.IdUser != IdUser)
            {
                goblin.IdUser = IdUser;
                goblin.CooldownTime = DateTime.UtcNow.AddHours(3);
            }
            goblin.Status = (int)GoblinStatusEnum.Avaliable;
            _goblinContext.Goblins.Update(goblin);
            _goblinContext.SaveChanges();
        }

        public void Claimed(long idGoblin, long IdUser)
        {
            var goblin = _goblinContext.Goblins.Find(idGoblin);
            if (goblin == null)
            {
                throw new Exception("Goblin not found");
            }
            if (goblin.IdUser != IdUser)
            {
                goblin.IdUser = IdUser;
                goblin.CooldownTime = DateTime.UtcNow.AddHours(3);
            }
            goblin.Status = (int)GoblinStatusEnum.Claimed;
            _goblinContext.Goblins.Update(goblin);
            _goblinContext.SaveChanges();
        }

        public int GetMiningPowerBonus(long idGoblin)
        {
            return Decimal.ToInt32(_goblinContext.GoblinAttributeBonus.Where(x => x.Id == idGoblin).Select(x => x.MiningPower).FirstOrDefault() ?? 0);
        }

        public void SetBaseImagePath(long idGoblin, string baseImagePath)
        {
            try
            {
                var goblin = _goblinContext.Goblins.Where(x => x.Id == idGoblin).FirstOrDefault();
                goblin.BaseImagePath = baseImagePath;
                _goblinContext.SaveChanges();
            } catch(Exception e)
            {
                throw;
            }
            
        }

        public void SetGoblinParents(long idGoblin, long? idFather, long? idMother)
        {
            try
            {
                var goblin = _goblinContext.Goblins.Find(idGoblin);
                goblin.IdFather = idFather;
                goblin.IdMother = idMother;
                _goblinContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
