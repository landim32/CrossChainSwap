using Auth.Domain.Interfaces.Factory;
using Core.Domain;
using Core.Domain.Cloud;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Equipments.Armor;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Goblin;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinService : IGoblinService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> _goblinContract;
        private readonly IGoblinRepository<IGoblinModel, IGoblinDomainFactory> _goblinRep;
        private readonly IGoblinDomainFactory _goblinFactory;
        private readonly IGoblinPerkDomainFactory _perkFactory;
        private readonly IGoblinDNADomainFactory _goblinDNAFactory;
        private readonly IUserDomainFactory _userFactory;
        private readonly IGeneService _geneService;
        private readonly IAvatarService _avatarService;
        private readonly IEquipmentService _equipmentService;
        private readonly IAssetsProviders _assetsProvider;
        private readonly IConfiguration _configuration;
        private readonly IBuildGoblinService _buildGoblinService;
        private readonly IGoblinMiningService _goblinMiningService;
        private readonly IMiningSpriteService _miningSpriteService;
        private readonly IFinanceService _financeService;
        private readonly IGLogService _glogService;
        private readonly IGoblinSkillService _goblinSkillService;

        private const double LEVEL_XP = 100;
        private const double LEVEL_INCREASE = 0.2;
        private const int RESPERK_COST = 10;
        private const decimal TRANSFER_GOBI_COST = 10;
        private const string RESPERK_MSG = "Spent {0} GOBI to resperk goblin __GOBLIN({1})__.";
        private const string MSG_TRANSFER_TO = "__GOBLIN({0})__ transfer to __USER({1})__, cost __GOBI({2})__ fee.";
        private const string MSG_TRANSFER_FROM = "__USER({0})__ transfer __GOBLIN({1})__ to you.";

        private readonly IList<GoblinStatusEnum> STATUS_INVALID = new List<GoblinStatusEnum>() {
            GoblinStatusEnum.Dead,
            GoblinStatusEnum.Claimed,
            GoblinStatusEnum.Fused
        };

        public GoblinService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            //IGoblinContractOld<IGoblinDNA, IGoblinDNADomainFactory> goblinContract,
            IGoblinDomainFactory goblinFactory, 
            IGoblinPerkDomainFactory perkFactory,
            IGoblinRepository<IGoblinModel, IGoblinDomainFactory> globinRep,
            IGoblinDNADomainFactory goblinDNAFactory, 
            IUserDomainFactory userFactory, 
            IGeneService geneService, 
            IAvatarService avatarService,
            IEquipmentService equipmentService,
            IAssetsProviders assetsProvider, 
            IConfiguration configuration, 
            IBuildGoblinService buildGoblinService,
            IRechargeDomainFactory rechargeFactory,
            IGoblinMiningService goblinMiningService,
            IMiningSpriteService miningSpriteService,
            IFinanceService financeService,
            IGLogService glogService,
            IGoblinSkillService goblinSkillService
        ) {
            _log = log;
            _unitOfWork = unitOfWork;
            //_goblinContract = goblinContract;
            _goblinFactory = goblinFactory;
            _perkFactory = perkFactory;
            _goblinRep = globinRep;     
            _goblinDNAFactory = goblinDNAFactory;
            _userFactory = userFactory;
            _geneService = geneService;
            _avatarService = avatarService;
            _equipmentService = equipmentService;
            _assetsProvider = assetsProvider;
            _configuration = configuration;
            _buildGoblinService = buildGoblinService;
            _goblinMiningService = goblinMiningService;
            _miningSpriteService = miningSpriteService;
            _financeService = financeService;
            _glogService = glogService;
            _goblinSkillService = goblinSkillService;
        }

        public GoblinPerkInfo ModelPerkToInfo(IGoblinPerkModel md)
        {
            return new GoblinPerkInfo { 
                Perk = (int) md.Perk,
                Name = md.Name,
                Description = md.Description
            };
        }

        public GoblinInfo ModelToInfo(IGoblinModel g)
        {
            var goblinEquipment = _equipmentService.GetSimpleEquipmentInfo(g.Id);
            var goblinSkill = _goblinSkillService.GetGoblinSkillList(g, goblinEquipment);
            return new GoblinInfo
            {
                Id = g.Id,
                IdToken = g.TokenId,
                IdUser = g.IdUser,
                NameUser = g.Username,
                UserAddress = (g.UserAddress ?? string.Empty).ToLower(),
                IdTokenFather = g.FatherTokenId,
                IdTokenMother = g.MotherTokenId,
                IdTokenSpouse = g.SpouseTokenId,
                Birthday = g.Birthday,
                LastUserChange = g.LastUserChange,
                CooldownDate = g.CooldownTime,
                InCooldown = g.CooldownTime > DateTime.UtcNow,
                Xp = g.Xp,
                Level = CalculateLevel(g.Xp),
                Name = g.Name,
                //ImageURL = g.ImageURL ?? (_configuration["Assets:ContainerBaseURL"] + BuildImagePath(g.TokenId.ToString(), g.BaseImagePath)),
                //HeadImageURL = g.HeadImageURL ?? (_configuration["Assets:ContainerBaseURL"] + BuildImagePath(g.TokenId.ToString(), g.BaseImagePath + "-head")),
                ImageURL = g.GetImageUrl(),
                HeadImageURL = g.GetHeadImageUrl(),
                Sprite = _configuration["Assets:ContainerBaseURL"] + string.Format("goblins/{0}/{1}-mine-sprite.png", g.TokenId.ToString(), g.BaseImagePath),
                SpriteTired = _configuration["Assets:ContainerBaseURL"] + string.Format("goblins/{0}/{1}-tired-sprite.png", g.TokenId.ToString(), g.BaseImagePath),
                Genre = ((char)g.Genre).ToString(),
                Race = (int)g.Race,
                RaceName = g.Race.ToString(),
                Hair = (int)g.Hair,
                HairName = g.Hair.ToString(),
                Ear = (int)g.Ear,
                EarName = g.Ear.ToString(),
                Eye = (int)g.Eye,
                EyeName = g.Eye.ToString(),
                Mount = (int)g.Mount,
                MountName = g.Mount.ToString(),
                Skin = (int)g.Skin,
                SkinName = g.Skin.ToString(),
                HairColor = "#" + g.HairColor.R.ToString("X2") + g.HairColor.G.ToString("X2") + g.HairColor.B.ToString("X2"),
                SkinColor = "#" + g.SkinColor.R.ToString("X2") + g.SkinColor.G.ToString("X2") + g.SkinColor.B.ToString("X2"),
                EyeColor = "#" + g.EyeColor.R.ToString("X2") + g.EyeColor.G.ToString("X2") + g.EyeColor.B.ToString("X2"),
                Strength = g.Strength,
                Agility = g.Agility,
                Vigor = g.Vigor,
                Intelligence = g.Intelligence,
                Charism = g.Charism,
                Perception = g.Perception,
                Status = (int) g.Status,
                Rarity = g.Rarity,
                RarityEnum = (int)g.RarityEnum,
                SonsCount = g.GetSonsCount(),
                IsAvaliable = g.IsAvaliable(),
                Minted = g.Minted,
                HasImageMine = g.HasImageMine,
                GoblinMining = _goblinMiningService.BuildGoblinMining(g.Id),
                Perks = g.ListPerks().Select(x => ModelPerkToInfo(x)).ToList(),
                QuestAffinity = g.QuestAffinity,
                GoblinEquipment = goblinEquipment,
                GolinSkillList = goblinSkill
            };
        }

        /*public async Task<bool> SyncByUser(long idUser)
        {
            var user = _userFactory.BuildUserModel().GetById(idUser, _userFactory);
            var tokens = await _goblinContract.ListTokenIdByAddress(user.PublicAddress);
            foreach (var tokenId in tokens)
            {
                await SyncNFTOld(tokenId);
            }
            return true;
        }

        private async Task<bool> SyncNFTOld(long oldTokenId)
        {
            var mdDNA = _goblinDNAFactory.BuildGoblinModel();
            var goblinDNA = await mdDNA.GetGoblin(new BigInteger(oldTokenId), _goblinDNAFactory);
            if (goblinDNA == null)
            {
                return false;
            }
            var ownerAddress = await goblinDNA.GetOwnerAddress();
            var user = _userFactory.BuildUserModel().GetUser(ownerAddress, _userFactory);
            await buildGoblinByDNA(goblinDNA, user.Id, user.PublicAddress);
            return true;
        }*/

        public void RefreshParents(long idUser)
        {
            var goblins = _goblinRep.GetAllUserGoblins(idUser, _goblinFactory);
            if(goblins != null)
                foreach(var goblin in goblins)
                {
                    try
                    {
                        long? idFather = null;
                        long? idMother = null;
                        var fatherMd = _goblinRep.GetByOldTokenId(_goblinFactory, goblin.IdTokenFather);
                        var motherMd = _goblinRep.GetByOldTokenId(_goblinFactory, goblin.IdTokenMother);
                        if (fatherMd != null)
                            idFather = fatherMd.Id;
                        if (motherMd != null)
                            idMother = motherMd.Id;
                        _goblinRep.SetGoblinParents(goblin.Id, idFather, idMother);

                    }
                    catch(Exception err)
                    {
                        continue;
                    }
                }
        }

        private string BuildImagePath(string tokenId, string path)
        {
            return "goblins/" + tokenId + "/" + path + ".png";
        }

        private BuildAvatarInfo GetGoblinImage(GeneInfo goblinGene, long idGoblin)
        {
            try
            {
                var avatar = _avatarService.GeneToAvatar(goblinGene);
                _equipmentService.BuildAvatarEquipment(avatar, idGoblin);
                var imageGoblin = _avatarService.GenerateAvatar(avatar);
                return imageGoblin;
            }
            catch
            {
                throw;
            }
        }

        private string GenerateBaseImagePath(string tokenId)
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + tokenId;
        }

        public async Task<bool> GenerateImage(long idGoblin)
        {
            var md = GetByUid(idGoblin);
            var gene = _geneService.ConvertInt256ToGene(md.Genes);
            await BuildGoblinImage(md.TokenId);
            return true;
        }

        /* public async Task<IGoblinModel> buildGoblinByDNA(IGoblinDNA goblinDNA, long userId, string userAddress)
        {
            long idToken = long.Parse(goblinDNA.TokenId.ToString());
            var mdGoblin = _goblinRep.GetByOldTokenId(_goblinFactory,  BigInteger.Parse(goblinDNA.TokenId.ToString()));
            var geneInfo = _geneService.ConvertInt256ToGene(goblinDNA.Genes);
            var baseFileName = GenerateBaseImagePath(goblinDNA.TokenId.ToString());
            var bkpBaseFileName = "";
            bool uploadImage = false;

            //Gerar do zero o goblin
            await goblinDNA.LoadGoblinFamily();
            if (mdGoblin == null)
            {
                mdGoblin = _goblinFactory.BuildGoblinModel();
            }
            Utils.Copy(_buildGoblinService.BuildGoblin(geneInfo), mdGoblin);
            mdGoblin.Genes = goblinDNA.Genes;
            mdGoblin.Birthday = Utils.UnixTimeStampToDateTime(double.Parse(goblinDNA.BirthTime.ToString()));
            mdGoblin.IdUser = userId;
            mdGoblin.TokenId = idToken;
            mdGoblin.TokenIdFatherTmp = long.Parse(goblinDNA.FatherId.ToString());
            mdGoblin.TokenIdMotherTmp = long.Parse(goblinDNA.MotherId.ToString());
            mdGoblin.TokenIdSpouseTmp = long.Parse(goblinDNA.SpouseId.ToString());

            mdGoblin.CooldownTime = Utils.UnixTimeStampToDateTime(double.Parse(goblinDNA.CooldownTime.ToString()));
            mdGoblin.LastUserChange = DateTime.UtcNow;
            mdGoblin.Name = "Goblin " + goblinDNA.TokenId.ToString();
            mdGoblin.Xp = 0;

            mdGoblin.IdTokenOld = goblinDNA.TokenId;
            mdGoblin.Inventory = goblinDNA.Inventory;
            mdGoblin.Bag = goblinDNA.Bag;
            mdGoblin.Mods = goblinDNA.Mods;
            mdGoblin.SpouseWithId = goblinDNA.SpouseId;
            mdGoblin.SonsCount = goblinDNA.SonsCount;
            mdGoblin.IdTokenFather = goblinDNA.FatherId;
            mdGoblin.IdTokenMother = goblinDNA.MotherId;
            mdGoblin.LastUpdateTime = goblinDNA.LastUpdateTime;
            mdGoblin.CooldownTimeOld = goblinDNA.CooldownTime;
            mdGoblin.HairColor = geneInfo.HairColor;
            mdGoblin.SkinColor = geneInfo.SkinColor;
            mdGoblin.EyeColor = geneInfo.EyesColor;
            mdGoblin.BaseImagePath = baseFileName;
            if (mdGoblin.Status == GoblinStatusEnum.ForSale)
                mdGoblin.Status = GoblinStatusEnum.Avaliable;

            _goblinRep.Update(mdGoblin);
            mdGoblin = _goblinRep.GetByTokenId(_goblinFactory, idToken);
            uploadImage = true;

            if (uploadImage)
            {
                //Gera a imagem
                var imgHeadPath = BuildImagePath(goblinDNA.TokenId.ToString(), mdGoblin.BaseImagePath + "-head");
                var imgFullPath = BuildImagePath(goblinDNA.TokenId.ToString(), mdGoblin.BaseImagePath);

                var fullBuffer = GetGoblinImage(geneInfo, mdGoblin.Id);

                await _assetsProvider.UploadFileToBlobAsync(imgFullPath, (byte[])new ImageConverter().ConvertTo(fullBuffer.FullImage, typeof(byte[])), "image/png");
                await _assetsProvider.UploadFileToBlobAsync(imgHeadPath, (byte[])new ImageConverter().ConvertTo(fullBuffer.HeadImage, typeof(byte[])), "image/png");
                //await _goblinMiningService.GenerateImage(long.Parse(goblinDNA.TokenId.ToString()), _configuration["Assets:ContainerBaseURL"] + BuildImagePath(goblinDNA.TokenId.ToString(), mdGoblin.BaseImagePath + "-head"));
                await _miningSpriteService.GenerateSprite(mdGoblin);
                if (!String.IsNullOrEmpty(bkpBaseFileName))
                {
                    _assetsProvider.DeleteFile(BuildImagePath(goblinDNA.TokenId.ToString(), bkpBaseFileName));
                    _assetsProvider.DeleteFile(BuildImagePath(goblinDNA.TokenId.ToString(), bkpBaseFileName + "-head"));
                }  
            }
            
            //mdGoblin.HeadImageURL = _configuration["Assets:ContainerBaseURL"] + BuildImagePath(goblinDNA.TokenId.ToString(), mdGoblin.BaseImagePath + "-head");
            //mdGoblin.ImageURL = _configuration["Assets:ContainerBaseURL"] + BuildImagePath(goblinDNA.TokenId.ToString(), mdGoblin.BaseImagePath);
            return mdGoblin;
        }*/

        public long GetIdbyTokenId(long tokenId)
        {
            return _goblinRep.GetIdByTokenId(tokenId);
        }

        public IGoblinModel GetByTokenId(long tokenId)
        {
            _log.Log("Get goblin by user Uid.", Core.Levels.Debug);
            return _goblinRep.GetByTokenId(_goblinFactory, tokenId);
        }

        public IGoblinModel GetByUid(long idGoblin) {
            _log.Log("Get goblin by user Uid.", Core.Levels.Debug);
            return _goblinRep.GetByUid(_goblinFactory, idGoblin);
        }

        public GoblinInfo GetInfoByUid(long idGoblin)
        {
            var mdGoblin = GetByUid(idGoblin);
            return ModelToInfo(mdGoblin);
        }

        public IEnumerable<GoblinInfo> ListByUser(long idUser, int page, int itemsPerPage, out int balance)
        {
            _log.Log("List goblins by user.", Core.Levels.Debug);
            var md = _goblinFactory.BuildGoblinModel();
            var goblins = md.ListByUser(idUser, page, itemsPerPage, out balance);
            return goblins.Select(x => ModelToInfo(x)).ToList();
        }


        public bool IsOwner(long idUser, long idGoblin)
        {
            return _goblinRep.IsOwner(idUser, idGoblin);
        }

        public bool IsOwnerByToken(long idUser, long tokenId)
        {
            return _goblinRep.IsOwner(idUser, 0, tokenId);
        }

        public async Task BuildGoblinImage(long tokenId)
        {
            var mdGoblin = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            var bkpBaseImagePath = mdGoblin.BaseImagePath?.ToString();
            var baseFileName = GenerateBaseImagePath(tokenId.ToString());
            _goblinRep.SetBaseImagePath(mdGoblin.Id, baseFileName);
            mdGoblin.BaseImagePath = baseFileName;
            var imgHeadPath = BuildImagePath(tokenId.ToString(), baseFileName + "-head");
            var imgFullPath = BuildImagePath(tokenId.ToString(), baseFileName);

            var avatar = _avatarService.GoblinInfoToAvatar(mdGoblin);
            _equipmentService.BuildAvatarEquipment(avatar, mdGoblin.Id);
            var imageGoblin = _avatarService.GenerateAvatar(avatar);

            await _assetsProvider.UploadFileToBlobAsync(imgFullPath, (byte[])new ImageConverter().ConvertTo(imageGoblin.FullImage, typeof(byte[])), "image/png");
            await _assetsProvider.UploadFileToBlobAsync(imgHeadPath, (byte[])new ImageConverter().ConvertTo(imageGoblin.HeadImage, typeof(byte[])), "image/png");

            await _miningSpriteService.GenerateSprite(mdGoblin, avatar, bkpBaseImagePath);

            if (!String.IsNullOrEmpty(bkpBaseImagePath))
            {
                try
                {
                    await _assetsProvider.DeleteFile(BuildImagePath(tokenId.ToString(), bkpBaseImagePath));
                    await _assetsProvider.DeleteFile(BuildImagePath(tokenId.ToString(), bkpBaseImagePath + "-head"));
                }
                catch (Exception)
                {
                    //Se não conseguir deletar, pode seguir com o processamento, pois a mesma pode não existir mais.
                }
            }
        }

        public GoblinInfo GetGoblinByToken(long tokenId)
        {
            return GetGoblinFromDatabase(tokenId);
        }

        public GoblinInfo GetNftFromDatabase(long tokenId)
        {
            var mdGoblin = _goblinRep.GetByTokenId(_goblinFactory, tokenId, true);
            if (mdGoblin == null)
            {
                return null;
            }
            return ModelToInfo(mdGoblin);
        }

        public GoblinInfo GetGoblinFromDatabase(long tokenId)
        {
            var mdGoblin = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            if (mdGoblin == null) {
                return null;
            }
            return ModelToInfo(mdGoblin);
        }

        public IEnumerable<GoblinInfo> ListBrothers(long tokenId, int page, out int balance)
        {
            var md = _goblinFactory.BuildGoblinModel();
            var idGoblin = md.GetIdByTokenId(tokenId);
            var goblins = md.ListBrothers(idGoblin, page, out balance);
            return goblins.Select(x => ModelToInfo(x)).ToList();
        }

        public IEnumerable<GoblinInfo> ListSons(long tokenId, int page, out int balance)
        {
            var md = _goblinFactory.BuildGoblinModel();
            var idGoblin = md.GetIdByTokenId(tokenId);
            var goblins = md.ListSons(idGoblin, page, out balance);
            return goblins.Select(x => ModelToInfo(x)).ToList();
        }


        public GoblinInfo SetGoblinName(long tokenId, string name)
        {
            var goblinMd = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            goblinMd.Name = name;
            _goblinRep.Update(goblinMd);
            var user = _userFactory.BuildUserModel().GetUser(goblinMd.UserAddress, _userFactory);
            return this.ModelToInfo(goblinMd);
        }

        public void UpdateStatus(long tokenId, GoblinStatusEnum status, DateTime? cooldown = null)
        {
            var goblinMd = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            if (STATUS_INVALID.Contains(goblinMd.Status))
            {
                throw new Exception("Cant change status of this goblin.");
            }
            goblinMd.Status = status;
            if (cooldown.HasValue)
            {
                goblinMd.CooldownTime = cooldown;
            }
            _goblinRep.Update(goblinMd);
        }

        public void CheckImageMine(long tokenId)
        {
            var goblinMd = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            goblinMd.HasImageMine = true;
            _goblinRep.Update(goblinMd);
        }

        public async Task<long> SonsBalance(BigInteger tokenId)
        {
            var goblinDNA = _goblinDNAFactory.BuildGoblinModel();
            goblinDNA.TokenId = tokenId;
            return await goblinDNA.SonsBalance();
        }

        public async Task<long> BrothersBalance(BigInteger tokenId)
        {
            var goblinDNA = _goblinDNAFactory.BuildGoblinModel();
            goblinDNA.TokenId = tokenId;
            await goblinDNA.LoadGoblinFamily();
            var motherDNA = _goblinDNAFactory.BuildGoblinModel();
            //O Goblin é monogâmico, então não precisa buscar irmãos só de pai ou de mãe.
            motherDNA.TokenId = goblinDNA.MotherId;
            return await motherDNA.SonsBalance();
        }

        public GoblinListResult ListByCursor(string userAddress, int cursor)
        {
            _log.Log("List goblins by user.", Core.Levels.Debug);
            var user = _userFactory.BuildUserModel().GetUser(userAddress, _userFactory);
            var md = _goblinFactory.BuildGoblinModel();
            var qtdeRegistros = int.Parse(_configuration["Contract:ItensForPage"]);
            var goblins = md.ListByUserWithCursor(user.Id, cursor, qtdeRegistros);
            return new GoblinListResult()
            {
                Goblins = goblins.Select(x => ModelToInfo(x)).ToList(),
                CursorGob = cursor + goblins.Count()
            };
        }

        public GoblinListResult ListMiningByCursor(long userId, int cursorGob)
        {
            var lstGoblinRet = new List<GoblinInfo>();
            var lstGoblins = _goblinRep.ListMiningByUser(_goblinFactory, userId, cursorGob, 9999);
            foreach (var goblin in lstGoblins)
            {
                var goblinAux = this.ModelToInfo(goblin);
                lstGoblinRet.Add(goblinAux);
            }
            return new GoblinListResult
            {
                CursorGob = cursorGob + lstGoblinRet.Count,
                Goblins = lstGoblinRet
            };
        }

        public GoblinListResult ListCanMiningByCursor(long userId, int cursorGob)
        {
            var lstGoblinRet = new List<GoblinInfo>();
            var lstGoblins = _goblinRep.ListCanMiningByUser(_goblinFactory, userId, cursorGob, 10);
            foreach (var goblin in lstGoblins)
            {
                lstGoblinRet.Add(this.ModelToInfo(goblin));
            }
            return new GoblinListResult
            {
                CursorGob = cursorGob + lstGoblinRet.Count,
                Goblins = lstGoblinRet
            };
        }


        public IEnumerable<IGoblinModel> GetAllUserGoblins(long idUser)
        {
            return _goblinRep.GetAllUserGoblins(idUser, _goblinFactory);
        }

        [Obsolete]
        public GoblinInfo GetLastUserGoblin(string userAddress)
        {
            throw new NotImplementedException();
        }

        private double CalculateLevel(int xp)
        {
            double currentXp = (double)xp;
            //int i = 0;
            double level = 0;
            double currentLvl = 0;
            while (currentXp > 0)
            {
                currentLvl = LEVEL_XP * (1 + (LEVEL_INCREASE * level));
                currentXp += currentLvl;
                if (currentXp > 0)
                {
                    level++;
                }
                else
                {
                    level += Math.Abs(currentXp) / currentLvl;
                }
            }
            return level;
        }

        public IEnumerable<GoblinInfo> ListGoblinsCanFuse(long idUser, long idGoblin)
        {
            var goblins = _goblinRep.GetGoblinsCanFuse(idGoblin, idUser, _goblinFactory);
            return goblins.Where(x => x.IsAvaliable()).Select(x => ModelToInfo(x));
        }

        public void AddPerk(long tokenId, GoblinPerkEnum perk)
        {
            var md = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            var perks = md.ListPerks().Select(x => x.Perk).ToList();
            var level = (int)Math.Truncate(CalculateLevel(md.Xp));
            if (level - perks.Count() <= 0)
            {
                throw new Exception("Dont have any perk avaliable.");
            }
            switch (perk)
            {
                case GoblinPerkEnum.MiningForce1:
                    break;
                case GoblinPerkEnum.MiningForce2:
                    if (!perks.Contains(GoblinPerkEnum.MiningForce1))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningForce1;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningForce3:
                    if (!perks.Contains(GoblinPerkEnum.MiningForce2))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningForce2;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningPersistence1:
                    if (!perks.Contains(GoblinPerkEnum.MiningForce1))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningForce1;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningPersistence2:
                    if (!perks.Contains(GoblinPerkEnum.MiningPersistence1))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningPersistence1;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningPersistence3:
                    if (!perks.Contains(GoblinPerkEnum.MiningPersistence2))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningPersistence2;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningWill1:
                    if (!perks.Contains(GoblinPerkEnum.MiningForce1))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningForce1;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningWill2:
                    if (!perks.Contains(GoblinPerkEnum.MiningWill1))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningWill1;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
                case GoblinPerkEnum.MiningWill3:
                    if (!perks.Contains(GoblinPerkEnum.MiningWill2))
                    {
                        var mdPerk = _perkFactory.BuildGoblinPerkModel();
                        mdPerk.Perk = GoblinPerkEnum.MiningWill2;
                        throw new Exception(string.Format("You need {0} perk before.", mdPerk.Name));
                    }
                    break;
            }
            md.AddPerk(perk);
        }

        public void ClearPerk(long tokenId)
        {
            var mdGoblin = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            _financeService.DebitGobi(mdGoblin.IdUser, RESPERK_COST, null, string.Format(RESPERK_MSG, RESPERK_COST, tokenId), LogType.Resperk);
            var md = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            md.ClearPerks();
        }

        public void Transfer(long tokenId, string userAddress) {
            var newUser = _userFactory.BuildUserModel().GetUser(userAddress, _userFactory);
            if (newUser == null)
            {
                throw new Exception("No user with this address in game.");
            }
            var md = _goblinRep.GetByTokenId(_goblinFactory, tokenId);
            if (md == null)
            {
                throw new Exception("Goblin not found.");
            }
            if (!md.IsAvaliable())
            {
                throw new Exception("Goblin not avaliable.");
            }
            var gobi = _financeService.GetGobiOnCloud(md.IdUser);
            if (gobi < TRANSFER_GOBI_COST)
            {
                throw new Exception("Dont have enougth balance to transfer.");
            }
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    string msgTo = string.Format(MSG_TRANSFER_TO, md.Id, newUser.Id, TRANSFER_GOBI_COST);
                    string msgFrom = string.Format(MSG_TRANSFER_FROM, newUser.Id, md.Id);
                    _financeService.DebitGobi(md.IdUser, TRANSFER_GOBI_COST, null, msgTo, LogType.Transfer);
                    _glogService.AddLog(newUser.Id, msgFrom, LogType.Transfer);
                    md.ChangeUser(newUser.Id);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

    }
}
