using Core.Domain;
using Core.Domain.Repository;
using Core.Domain.Repository.Goblins;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Interfaces.Core;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class GoblinModel : IGoblinModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IGoblinDomainFactory _goblinFactory;
        private readonly IGoblinPerkDomainFactory _goblinPerkFactory;
        private readonly IGoblinRepository<IGoblinModel, IGoblinDomainFactory> _repositoryGoblin;
        private readonly IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory> _repGoblinPerk;

        public GoblinModel(
            ILogCore log, 
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IGoblinDomainFactory goblinFactory,
            IGoblinPerkDomainFactory goblinPerkFactory,
            IGoblinRepository<IGoblinModel, IGoblinDomainFactory> repositoryGoblin,
            IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory> repGoblinPerk
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _goblinFactory = goblinFactory;
            _goblinPerkFactory = goblinPerkFactory;
            _repositoryGoblin = repositoryGoblin;
            _repGoblinPerk = repGoblinPerk;
        }

        public long Id { get; set; }
        public BigInteger Genes { get; set; }
        //public bool Ativo { get; set; }
        public long IdUser { get; set; }
        public string Username { get; set; }
        public long TokenId { get; set; }
        public long? TokenIdFatherTmp { get; set; }
        public long? TokenIdMotherTmp { get; set; }
        public long? TokenIdSpouseTmp { get; set; }
        public long? IdFather { get; set; }
        public long? IdMother { get; set; }
        public long? IdSpouse { get; set; }
        public long? FatherTokenId { get; set; }
        public long? MotherTokenId { get; set; }
        public long? SpouseTokenId { get; set; }
        public DateTime? CooldownTime { get; set; }

        public DateTime Birthday { get; set; }
        public DateTime? LastUserChange { get; set; }
        public int Xp { get; set; }
        public string Name { get; set; }
        //public string ImageURL { get; set; }
        //public string HeadImageURL { get; set; }
        //public DateTime? Busy { get; set; }
        public GenreEnum Genre { get; set; }
        public RaceEnum Race { get; set; }
        public RaceEnum Hair { get; set; }
        public RaceEnum Ear { get; set; }
        public RaceEnum Eye { get; set; }
        public RaceEnum Mount { get; set; }
        public RaceEnum Skin { get; set; }
        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Color EyeColor { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vigor { get; set; }
        public int Intelligence { get; set; }
        public int Charism { get; set; }
        public int Perception { get; set; }
        public long QuestAffinity { get; set; }
        public GoblinStatusEnum Status { get; set; }
        public string BaseImagePath { get; set; }

        public int Rarity { get; set; }

        public RarityEnum RarityEnum {
            get {
                return GoblinUtils.GetGoblinEnumRarity(Rarity);
            }
        }

        public bool HasImageMine { get; set; }
        public bool Minted { get; set; }

        public string GetImageUrl()
        {
            var url = _configuration["Assets:ContainerBaseURL"];
            url += string.Format("goblins/{0}/{1}.png", this.TokenId, this.BaseImagePath);
            return url;
        }
        public string GetHeadImageUrl()
        {
            var url = _configuration["Assets:ContainerBaseURL"];
            url += string.Format("goblins/{0}/{1}.png", this.TokenId, this.BaseImagePath + "-head");
            return url;
        }

        public long GetIdByTokenId(long tokenId)
        {
            return _repositoryGoblin.GetIdByTokenId(tokenId);
        }

        public IGoblinModel GetById(long idGoblin)
        {
            return _repositoryGoblin.GetByUid(_goblinFactory, idGoblin);
        }

        public IGoblinModel GetByTokenId(long tokenId, bool forced = false)
        {
            return _repositoryGoblin.GetByTokenId(_goblinFactory, tokenId, forced);
        }

        public int GetSonsCount()
        {
            return _repositoryGoblin.GetSonsCount(this.Id);
        }

        public IEnumerable<IGoblinModel> ListByUserWithCursor(long idUser, int cursor, int limit)
        {
            return _repositoryGoblin.ListByUserWithCursor(_goblinFactory, idUser, cursor, limit);
        }

        public IEnumerable<IGoblinModel> ListByUser(long idUser, int page, int itemsPerPage, out int balance)
        {
            return _repositoryGoblin.ListByUser(_goblinFactory, idUser, page, itemsPerPage, out balance);
        }
        public IEnumerable<IGoblinModel> ListSons(long idGoblin, int page, out int balance)
        {
            return _repositoryGoblin.ListSons(_goblinFactory, idGoblin, page, out balance);
        }
        public IEnumerable<IGoblinModel> ListBrothers(long idGoblin, int page, out int balance)
        {
            return _repositoryGoblin.ListBrothers(_goblinFactory, idGoblin, page, out balance);
        }
        public IEnumerable<IGoblinModel> ListGoblinCanBreed(long idGoblin, int cursor, int limit)
        {
            return _repositoryGoblin.ListGoblinCanBreed(_goblinFactory, idGoblin, cursor, limit);
        }
        public IEnumerable<IGoblinPerkModel> ListPerks()
        {
            return _repGoblinPerk.ListByGoblin(_goblinPerkFactory, this.Id);
        }
        public void AddPerk(GoblinPerkEnum perk)
        {
            var md = _goblinPerkFactory.BuildGoblinPerkModel();
            md.IdGoblin = this.Id;
            md.Perk = perk;
            _repGoblinPerk.Insert(md);
        }
        public void ClearPerks()
        {
            _repGoblinPerk.Clear(this.Id);
        }

        public bool IsAvaliable()
        {
            var statusNotAvaliable = new List<GoblinStatusEnum>() {
                GoblinStatusEnum.Minning,
                GoblinStatusEnum.ForSale,
                GoblinStatusEnum.Dead,
                GoblinStatusEnum.Claimed
            };
            return (!CooldownTime.HasValue || CooldownTime <= DateTime.UtcNow) && !statusNotAvaliable.Contains(Status);
        }

        

        public void DoBasic()
        {
            Strength = 7;
            Agility = 7;
            Vigor = 7;
            Intelligence = 7;
            Charism = 7;
            Perception = 7;
        }

        public void ChangeUser(long _idNewUser)
        {
            _repositoryGoblin.ChangeUser(this.Id, _idNewUser);
        }

        public void DoMint(long idUser)
        {
            _repositoryGoblin.DoMint(this.Id, idUser);
        }
        public void Deposit(long idUser)
        {
            _repositoryGoblin.Deposit(this.Id, idUser);
        }
        public void Claimed(long idUser)
        {
            _repositoryGoblin.Claimed(this.Id, idUser);
        }

        #region Obsolete
        [Obsolete]
        public string UserAddress { get; set; }
        [Obsolete]
        public BigInteger IdTokenOld { get; set; }
        [Obsolete]
        public BigInteger IdTokenFather { get; set; }
        [Obsolete]
        public BigInteger IdTokenMother { get; set; }
        [Obsolete]
        public BigInteger Mods { get; set; }
        [Obsolete]
        public BigInteger Inventory { get; set; }
        [Obsolete]
        public BigInteger Bag { get; set; }
        [Obsolete]
        public BigInteger SpouseWithId { get; set; }
        [Obsolete]
        public BigInteger SonsCount { get; set; }
        [Obsolete]
        public BigInteger LastUpdateTime { get; set; }
        [Obsolete]
        public BigInteger CooldownTimeOld { get; set; }
        #endregion
    }
}