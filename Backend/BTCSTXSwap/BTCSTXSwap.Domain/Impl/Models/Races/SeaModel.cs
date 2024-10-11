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
    public class SeaModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Sea;
            Goblin.Skin = RaceEnum.Sea;
            Goblin.Hair = RaceEnum.Sea;
            Goblin.Ear = RaceEnum.Sea;
            Goblin.Eye = RaceEnum.Sea;
            Goblin.Mount = RaceEnum.Sea;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Sea)
            {
                Goblin.Charism++;
                Goblin.Perception++;
                Goblin.Strength--;
                Goblin.Vigor--;
            }
            if (Goblin.Skin == RaceEnum.Sea)
            {
                Goblin.Charism++;
                Goblin.Strength--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Empathy,
                    Description = "Empathy"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Sea)
            {
                Goblin.Charism++;
                Goblin.Intelligence--;

                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.LowCardio,
                    Description = "Low Cardio"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Sea)
            {
                Goblin.Strength++;
                Goblin.Agility--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Amphibian,
                    Description = "Amphibian"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Sea)
            {
                Goblin.Vigor++;
                Goblin.Intelligence--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Disastrous,
                    Description = "Disastrous"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Sea)
            {
                Goblin.Strength++;
                Goblin.Vigor--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.MelodiousVoice,
                    Description = "Melodious Voice"
                });
                */
            }
        }
    }
}
