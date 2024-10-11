using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Services;
using Core.Domain;
using Core.Domain.Cloud;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Goblin;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GoblinBreedService : IGoblinBreedService
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoblinRepository<IGoblinModel, IGoblinDomainFactory> _goblinRep;
        private readonly IGoblinDomainFactory _goblinFactory;
        private readonly IConfiguration _configuration;
        private readonly IGoblinDNADomainFactory _goblinDNAFactory;
        private readonly IUserDomainFactory _userFactory;
        private readonly IUserService _userService;
        private readonly IGoblinService _goblinService;
        private readonly IBuildGoblinService _buildService;
        private readonly IFinanceService _financeService;
        private readonly IGeneService _geneService;

        private const string MSG_BREED = "__GOBLIN({0})__ and __GOBLIN({1})__ breed and have __GOBLIN({2})__.";
        private const string MSG_FUSION = "__GOBLIN({0})__ as upgrade on fuse with __GOBLIN({1})__.";

        public GoblinBreedService(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IGoblinDomainFactory goblinFactory,
            IGoblinRepository<IGoblinModel, IGoblinDomainFactory> globinRep,
            IGoblinDNADomainFactory goblinDNAFactory, IUserDomainFactory userFactory,
            IUserService userService,
            IGoblinService goblinService,
            IFinanceService financeService,
            IGeneService geneService,
            IBuildGoblinService buildService
        ) {
            _log = log;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _goblinFactory = goblinFactory;
            _goblinRep = globinRep;     
            _goblinDNAFactory = goblinDNAFactory;
            _userFactory = userFactory;
            _userService = userService;
            _goblinService = goblinService;
            _financeService = financeService;
            _geneService = geneService;
            _buildService = buildService;
        }

        private decimal _GetBreedCost(IGoblinModel parent1, IGoblinModel parent2)
        {
            var box = _geneService.GetBoxByBreed(parent1.RarityEnum, parent2.RarityEnum);
            decimal cost = 0;
            switch (box)
            {
                case GoboxEnum.GoboxCommon:
                    cost = 350;
                    cost += parent1.GetSonsCount() * 100;
                    cost += parent2.GetSonsCount() * 100;
                    break;
                case GoboxEnum.GoboxUncommon:
                    cost = 700;
                    cost += parent1.GetSonsCount() * 200;
                    cost += parent2.GetSonsCount() * 200;
                    break;
                case GoboxEnum.GoboxRare:
                    cost = 2000;
                    cost += parent1.GetSonsCount() * 500;
                    cost += parent2.GetSonsCount() * 500;
                    break;
                default:
                    throw new Exception("Breed const invalid");
            }
            return cost;
        }

        public decimal GetBreedCost(long tokenId1, long tokenId2)
        {
            var parent1 = GetParentByToken(tokenId1);
            var parent2 = GetParentByToken(tokenId2);
            return _GetBreedCost(parent1, parent2);
            /*
            var goblinDNA = _goblinDNAFactory.BuildGoblinModel();
            goblinDNA.TokenId = parent1;
            var breedCost = (await goblinDNA.BreedCost(parent2)).ToString();
            return double.Parse(breedCost.Insert(breedCost.Length - 18, "."), new CultureInfo("en-US"));
            */
        }

        public GoboxEnum GetBreedRarity(long tokenId1, long tokenId2)
        {
            var parent1 = GetParentByToken(tokenId1);
            var parent2 = GetParentByToken(tokenId2);
            return _geneService.GetBoxByBreed(parent1.RarityEnum, parent2.RarityEnum);
        }

        public GoblinListResult ListGoblinCanBreed(long tokenId, int cursorGob)
        {
            var idGoblin = _goblinRep.GetIdByTokenId(tokenId);
            var md = _goblinFactory.BuildGoblinModel();
            var qtdeRegistros = int.Parse(_configuration["Contract:ItensForPage"]);
            var goblins = md.ListGoblinCanBreed(idGoblin, cursorGob, qtdeRegistros)
                .Select(x => _goblinService.ModelToInfo(x))
                .ToList();
            return new GoblinListResult()
            {
                Goblins = goblins,
                CursorGob = cursorGob + goblins.Count()
            };
            /*
            var goblinDNA = _goblinDNAFactory.BuildGoblinModel();
            goblinDNA.TokenId = tokenId;
            var lstGoblinRet = new List<GoblinInfo>();
            var qtdeRegistros = int.Parse(_configuration["Contract:ItensForPage"]);
            var pageLstGoblin = (int)Math.Floor(double.Parse(cursorGob.ToString()) / double.Parse(qtdeRegistros.ToString()));
            if (pageLstGoblin == 0)
                pageLstGoblin++;
            var lstCanBreed = new List<IGoblinDNA>();
            var flagEnd = false;
            var maxCursorGob = cursorGob;
            while (lstCanBreed.Count() < qtdeRegistros && !flagEnd)
            {
                var lstGoblinDNA = await _goblinDNAFactory.BuildGoblinModel().ListByAddress(userAddress, pageLstGoblin, _goblinDNAFactory);
                if (lstGoblinDNA == null || lstGoblinDNA.Count() == 0)
                {
                    flagEnd = true;
                }
                else
                {
                    lstGoblinDNA = lstGoblinDNA.Where(x => x.CursorGob > cursorGob || (cursorGob == 0 && x.CursorGob == 0)).ToList();
                    var lstCanBreedAux = await goblinDNA.ListCanBreed(userAddress, lstGoblinDNA.Select(x => x.TokenId));
                    if (lstCanBreedAux != null && lstCanBreedAux.Count() > 0)
                    {
                        foreach(var canBreed in lstCanBreedAux)
                        {
                            long _tokenId = Convert.ToInt64(canBreed.ToByteArray());
                            var goblinMdDb = _goblinService.GetGoblinFromDatabase(_tokenId);
                            if (goblinMdDb == null || goblinMdDb.IsAvaliable == false)
                                continue;
                            if (lstCanBreed.Where(x => x.TokenId == canBreed).Count() != 0)
                                continue;
                            if (lstCanBreed.Count() < qtdeRegistros)
                                lstCanBreed.Add(lstGoblinDNA.Where(x => x.TokenId == canBreed).FirstOrDefault());
                            else
                                break;
                        }
                        if(lstCanBreed.Count > 0)
                            maxCursorGob = lstCanBreed.Last().CursorGob;
                    }
                    pageLstGoblin++;
                }
            }
            
            if (lstCanBreed != null & lstCanBreed.Count() > 0)
            {
                foreach (var candidate in lstCanBreed)
                {
                    var user = _userFactory.BuildUserModel().GetUser(userAddress, _userFactory);
                    var goblinInfo = await _goblinService.buildGoblinByDNA(candidate, user.Id, user.PublicAddress);
                    lstGoblinRet.Add(_goblinService.ModelToInfo(goblinInfo));
                }

            }
            return new GoblinListResult()
            {
                Goblins = lstGoblinRet,
                CursorGob = long.Parse(maxCursorGob.ToString())
            };
            */
        }

        private void ElegibleForBreed(IGoblinModel parent1, IGoblinModel parent2, ref IGoblinModel male, ref IGoblinModel female)
        {
            if (parent1.CooldownTime >= DateTime.UtcNow)
            {
                throw new Exception(string.Format("{0} is on cooldown.", parent1.Name));
            }
            if (parent2.CooldownTime >= DateTime.UtcNow)
            {
                throw new Exception(string.Format("{0} is on cooldown.", parent2.Name));
            }
            if (parent1.Genre == GenreEnum.Male)
            {
                male = parent1;
            }
            else if (parent2.Genre == GenreEnum.Male)
            {
                male = parent2;
            }
            if (parent1.Genre == GenreEnum.Female)
            {
                female = parent1;
            }
            else if (parent2.Genre == GenreEnum.Female)
            {
                female = parent2;
            }
            if (male == null)
            {
                throw new Exception("You need a father");
            }
            if (female == null)
            {
                throw new Exception("You need a mother");
            }
            if (
                (male.IdFather.HasValue && female.IdFather.HasValue && male.IdFather == female.IdFather) ||
                (male.IdMother.HasValue && female.IdMother.HasValue && male.IdMother == female.IdMother)
            )
            {
                throw new Exception("Cant be brother");
            }
            if (
                (male.IdFather.HasValue && male.IdFather == female.Id) || (female.IdFather.HasValue && female.IdFather == male.Id) ||
                (male.IdMother.HasValue && male.IdMother == female.Id) || (female.IdMother.HasValue && female.IdMother == male.Id)
            )
            {
                throw new Exception("Cant be parent");
            }
        }

        private IGoblinModel GetParentByToken(long tokenId)
        {
            var idGoblin = _goblinRep.GetIdByTokenId(tokenId);
            if (idGoblin <= 0)
            {
                throw new Exception(string.Format("Parent with tokenId {0} not found.", tokenId));
            }
            var parent = _goblinService.GetByUid(idGoblin);
            if (parent == null)
            {
                throw new Exception(string.Format("Goblin with id {0} not found.", idGoblin));
            }
            return parent;
        }

        private IGoblinModel ExecuteBreed(IGoblinModel male, IGoblinModel female)
        {
            var newTokenId = _goblinRep.GetLastToken() + 1;

            var geneMale = _geneService.ConvertInt256ToGene(male.Genes);
            var geneFemale = _geneService.ConvertInt256ToGene(female.Genes);
            var geneSon = _geneService.MixGenes(geneMale, geneFemale);

            var dateNow = DateTime.UtcNow;
            var cooldownSon = DateTime.UtcNow.AddDays(5);
            var cooldownParents = DateTime.UtcNow.AddDays(5);

            var son = _goblinFactory.BuildGoblinModel();
            Utils.Copy(_buildService.BuildGoblin(geneSon), son);
            son.IdUser = male.IdUser;
            son.TokenId = newTokenId;
            son.IdFather = male.Id;
            son.IdMother = female.Id;
            son.Genes = _geneService.ConvertGeneToInt256(geneSon);
            son.Genre = geneSon.Genre;
            son.Skin = geneSon.Skin;
            son.Hair = geneSon.Hair;
            son.Ear = geneSon.Ear;
            son.Eye = geneSon.Eyes;
            son.Mount = geneSon.Mouth;
            son.Race = geneSon.Race;
            son.Rarity = geneSon.Rarity;
            son.SkinColor = geneSon.SkinColor;
            son.HairColor = geneSon.HairColor;
            son.EyeColor = geneSon.EyesColor;
            son.Name = "Goblin " + newTokenId.ToString();
            son.Birthday = dateNow;
            son.LastUserChange = dateNow;
            son.CooldownTime = cooldownSon;
            son.Xp = 0;

            _goblinRep.Insert(son);

            male.IdSpouse = female.Id;
            male.CooldownTime = cooldownParents;
            _goblinRep.Update(male);

            female.IdSpouse = male.Id;
            female.CooldownTime = cooldownParents;
            _goblinRep.Update(female);

            return son;
        }

        public long Breed(long idUser, long tokenId1, long tokenId2)
        {

            var parent1 = GetParentByToken(tokenId1);
            var parent2 = GetParentByToken(tokenId2);

            var gobi = _financeService.GetGobiOnCloud(idUser);
            var gobiCost = _GetBreedCost(parent1, parent2);

            if (gobi < gobiCost)
            {
                throw new Exception(string.Format("You have only {0:N4} GOBI, you need {0:N4}.", gobi, gobiCost));
            }
            var user = _userService.GetUSerByID(idUser);
            IGoblinModel son = null;
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    IGoblinModel male = null;
                    IGoblinModel female = null;
                    ElegibleForBreed(parent1, parent2, ref male, ref female);
                    son = ExecuteBreed(male, female);

                    var msgBreed = string.Format(MSG_BREED, male.TokenId, female.TokenId, son.TokenId);
                    _financeService.DebitGobi(idUser, gobiCost, null, msgBreed, LogType.Breed);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            _goblinService.GenerateImage(_goblinRep.GetByTokenId(_goblinFactory, son.TokenId).Id);

            return son.TokenId;
        }

        public decimal GetFusionCost(long tokenId)
        {
            var parent1 = GetParentByToken(tokenId);
            return GetFusionCost(parent1);
        }

        private decimal GetFusionCost(IGoblinModel parent1)
        {
            int cost = 200;
            switch (GoblinUtils.GetGoblinEnumRarity(parent1.Rarity))
            {
                case RarityEnum.Uncommon:
                    cost = 500;
                    break;
                case RarityEnum.Rare:
                    cost = 1000;
                    break;
                case RarityEnum.Epic:
                    cost = 3000;
                    break;
                case RarityEnum.Legendary:
                    throw new Exception("Legendary cant fuse.");
                    break;
                default:
                    cost = 200;
                    break;
            }
            return cost;
        }

        private RarityEnum GetNextRarity(RarityEnum rarity)
        {
            RarityEnum retorno = RarityEnum.Common;
            switch (rarity)
            {
                case RarityEnum.Uncommon:
                    retorno = RarityEnum.Rare;
                    break;
                case RarityEnum.Rare:
                    retorno = RarityEnum.Epic;
                    break;
                case RarityEnum.Epic:
                    retorno = RarityEnum.Legendary;
                    break;
                case RarityEnum.Legendary:
                    throw new Exception("Cant fuse a legendary.");
                    break;
                default:
                    retorno = RarityEnum.Uncommon;
                    break;
            }
            return retorno;
        }

        public long Fusion(long idUser, long tokenId1, long tokenId2)
        {
            var parent1 = GetParentByToken(tokenId1);
            var parent2 = GetParentByToken(tokenId2);

            var gobi = _financeService.GetGobiOnCloud(idUser);
            var gobiCost = GetFusionCost(parent1);

            if (parent1.RarityEnum != parent2.RarityEnum)
            {
                throw new Exception("Need to be same rarity.");
            }

            if (gobi < gobiCost)
            {
                throw new Exception(string.Format("You have only {0:N4} GOBI, you need {0:N4}.", gobi, gobiCost));
            }

            var user = _userService.GetUSerByID(idUser);

            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    //var dateNow = DateTime.UtcNow;
                    var cooldown = DateTime.UtcNow.AddHours(1);

                    parent1.Rarity = GoblinUtils.GetRarityFromEnum(GetNextRarity(parent1.RarityEnum));
                    parent1.SkinColor = _geneService.MixColor(parent1.SkinColor, parent2.SkinColor);
                    parent1.HairColor = _geneService.MixColor(parent1.HairColor, parent2.HairColor);
                    parent1.EyeColor = _geneService.MixColor(parent1.EyeColor, parent2.EyeColor);
                    parent1.CooldownTime = cooldown;
                    _goblinRep.Update(parent1);

                    parent2.Status = GoblinStatusEnum.Fused;
                    _goblinRep.Update(parent2);

                    var msgBreed = string.Format(MSG_FUSION, parent1.Id, parent2.Id);
                    _financeService.DebitGobi(idUser, gobiCost, null, msgBreed, LogType.Fusion);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            _goblinService.GenerateImage(_goblinRep.GetByTokenId(_goblinFactory, parent1.TokenId).Id);
            return parent1.TokenId;
        }

        private RaceEnum GetRandomGeneEnum()
        {
            var genes = Enum.GetValues<RaceEnum>();
            genes.Shuffle();
            return genes[0];
        }

        private GenreEnum GetRandomGenreEnum()
        {
            var genre = new List<GenreEnum>() { GenreEnum.Male, GenreEnum.Female };
            genre.Shuffle();
            return genre[0];
        }

        private Color GetRandomColor()
        {
            var r = new Random();
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        private GeneInfo GetRandomGene()
        {
            var g = new GeneInfo
            {
                Genre = GetRandomGenreEnum(),
                Skin = GetRandomGeneEnum(),
                SkinR1 = GetRandomGeneEnum(),
                SkinR2 = GetRandomGeneEnum(),
                Hair = GetRandomGeneEnum(),
                HairR1 = GetRandomGeneEnum(),
                HairR2 = GetRandomGeneEnum(),
                Ear = GetRandomGeneEnum(),
                EarR1 = GetRandomGeneEnum(),
                EarR2 = GetRandomGeneEnum(),
                Eyes = GetRandomGeneEnum(),
                EyesR1 = GetRandomGeneEnum(),
                EyesR2 = GetRandomGeneEnum(),
                Mouth = GetRandomGeneEnum(),
                MouthR1 = GetRandomGeneEnum(),
                MouthR2 = GetRandomGeneEnum(),
                HairColor = GetRandomColor(),
                SkinColor = GetRandomColor(),
                EyesColor = GetRandomColor()
            };
            return g;

        }

        public IGoblinModel GenerateRandom(long idUser, int rarity)
        {
            var user = _userService.GetUSerByID(idUser);

            var newTokenId = _goblinRep.GetLastToken() + 1;

            var gene = GetRandomGene();

            var dateNow = DateTime.UtcNow;

            var son = _goblinFactory.BuildGoblinModel();
            Utils.Copy(_buildService.BuildGoblin(gene), son);
            son.IdUser = idUser;
            son.TokenId = newTokenId;
            son.IdFather = null;
            son.IdMother = null;
            son.Genes = _geneService.ConvertGeneToInt256(gene);
            son.Genre = gene.Genre;
            son.Skin = gene.Skin;
            son.Hair = gene.Hair;
            son.Ear = gene.Ear;
            son.Eye = gene.Eyes;
            son.Mount = gene.Mouth;
            son.Race = gene.Race;
            son.Rarity = gene.Rarity;
            son.SkinColor = gene.SkinColor;
            son.HairColor = gene.HairColor;
            son.EyeColor = gene.EyesColor;
            son.Name = "Goblin " + newTokenId.ToString();
            son.Birthday = dateNow;
            son.LastUserChange = dateNow;
            son.Xp = 0;
            son.Rarity = rarity;

            _goblinRep.Insert(son);

            //_goblinService.GenerateImage(son, user.PublicAddress);

            return _goblinRep.GetByTokenId(_goblinFactory, son.TokenId);
        }
        
    }
}
