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
    public class FlorestModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Forest;
            Goblin.Skin = RaceEnum.Forest;
            Goblin.Hair = RaceEnum.Forest;
            Goblin.Ear = RaceEnum.Forest;
            Goblin.Eye = RaceEnum.Forest;
            Goblin.Mount = RaceEnum.Forest;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Forest)
            {
                Goblin.Intelligence++;
                Goblin.Perception++;
                Goblin.Strength--;
                Goblin.Agility--;
            }
            if (Goblin.Skin == RaceEnum.Forest)
            {
                Goblin.Charism++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.MagicAbtitude,
                    Description = "Magic Abtitude"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Forest)
            {
                Goblin.Intelligence++;
                Goblin.Vigor--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.NatureDefender,
                    Description = "Nature Defenser"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Forest)
            {
                Goblin.Strength++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.HighSenses,
                    Description = "High senses"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Forest)
            {
                Goblin.Perception++;
                Goblin.Strength--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Vegan,
                    Description = "Vegan"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Forest)
            {
                Goblin.Agility++;
                Goblin.Intelligence--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Survivalist,
                    Description = "Survivalist"
                });
                */
            }
        }
    }
}
