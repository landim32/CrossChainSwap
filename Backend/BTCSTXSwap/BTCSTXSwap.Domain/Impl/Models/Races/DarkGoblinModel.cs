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
    public class DarkGoblinModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Dark;
            Goblin.Skin = RaceEnum.Dark;
            Goblin.Hair = RaceEnum.Dark;
            Goblin.Ear = RaceEnum.Dark;
            Goblin.Eye = RaceEnum.Dark;
            Goblin.Mount = RaceEnum.Dark;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Dark)
            {
                Goblin.Agility++;
                Goblin.Intelligence++;
                Goblin.Strength--;
                Goblin.Vigor--;
            }
            if (Goblin.Skin == RaceEnum.Dark)
            {
                Goblin.Intelligence++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Occultist,
                    Description = "Occultist"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Dark)
            {
                Goblin.Perception++;
                Goblin.Vigor--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Intolerant,
                    Description = "Intolerant"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Dark)
            {
                Goblin.Intelligence++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.BornChemist,
                    Description = "Born Chemist"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Dark)
            {
                Goblin.Charism++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Depression,
                    Description = "Depression"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Dark)
            {
                Goblin.Perception++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Elitist,
                    Description = "Elitist"
                });
                */
            }
        }

    }
}
