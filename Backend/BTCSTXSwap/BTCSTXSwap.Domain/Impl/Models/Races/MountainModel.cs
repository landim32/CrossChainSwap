using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Races
{
    public class MountainModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Mountain;
            Goblin.Skin = RaceEnum.Mountain;
            Goblin.Hair = RaceEnum.Mountain;
            Goblin.Ear = RaceEnum.Mountain;
            Goblin.Eye = RaceEnum.Mountain;
            Goblin.Mount = RaceEnum.Mountain;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Mountain)
            {
                Goblin.Vigor++;
                Goblin.Perception++;
                Goblin.Charism--;
                Goblin.Intelligence--;
            }
            if (Goblin.Skin == RaceEnum.Mountain)
            {
                Goblin.Vigor++;
                Goblin.Charism--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Hypoalgia,
                    Description = "Hypoalgia"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Mountain)
            {
                Goblin.Strength++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Greed,
                    Description = "Greed"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Mountain)
            {
                Goblin.Agility++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.BornArtisan,
                    Description = "Born Artisan"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Mountain)
            {
                Goblin.Vigor++;
                Goblin.Intelligence--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.TiredVision,
                    Description = "Tired Vision"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Mountain)
            {
                Goblin.Perception++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.BornNegotiator,
                    Description = "Born Negotiator"
                });
                */
            }
        }
    }
}
