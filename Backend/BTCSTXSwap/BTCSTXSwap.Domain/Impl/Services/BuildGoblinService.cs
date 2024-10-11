using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class BuildGoblinService : IBuildGoblinService
    {
        private readonly IRaceDomainFactory _raceFactory;
        private readonly IGoblinDomainFactory _goblinFactory;
        public BuildGoblinService(IRaceDomainFactory raceFactory, IGoblinDomainFactory goblinFactory)
        {
            _raceFactory = raceFactory;
            _goblinFactory = goblinFactory;
        }
        public IBuildGoblinModel BuildGoblin(GeneInfo gene)
        {
            var gMd = _goblinFactory.BuildGoblinBuildModel();
            gMd.DoBasic();
            _raceFactory.BuildRaceModel(gene.Race).DoPureRace(gMd);
            gMd.Ear = gene.Ear;
            gMd.Eye = gene.Eyes;
            gMd.EyeColor = gene.EyesColor;
            gMd.Genre = gene.Genre;
            gMd.Hair = gene.Hair;
            gMd.Mount = gene.Mouth;
            gMd.Race = gene.Race;
            gMd.Skin = gene.Skin;
            gMd.SkinColor = gene.SkinColor;
            gMd.Rarity = gene.Rarity;

            foreach (var ra in Enum.GetValues(typeof(RaceEnum)))
            {
                _raceFactory.BuildRaceModel((RaceEnum)ra).Generate(gMd);
            }
            return gMd;
        }
    }
}
