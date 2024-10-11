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
    public class DesertModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Desert;
            Goblin.Skin = RaceEnum.Desert;
            Goblin.Hair = RaceEnum.Desert;
            Goblin.Ear = RaceEnum.Desert;
            Goblin.Eye = RaceEnum.Desert;
            Goblin.Mount = RaceEnum.Desert;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Desert)
            {
                Goblin.Agility++;
                Goblin.Intelligence++;
                Goblin.Vigor--;
                Goblin.Perception--;
            }
            if (Goblin.Skin == RaceEnum.Desert)
            {
                Goblin.Vigor++;
                Goblin.Intelligence--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.ImprovedReflections,
                    Description = "Improved Reflections"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Desert)
            {
                Goblin.Perception++;
                Goblin.Charism--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Reckless,
                    Description = "Reckless"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Desert)
            {
                Goblin.Charism++;
                Goblin.Strength--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.PerfectBalance,
                    Description = "Perfect Balance"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Desert)
            {
                Goblin.Perception++;
                Goblin.Vigor--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Shyness,
                    Description = "Shyness"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Desert)
            {
                Goblin.Agility++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.SoftJoints,
                    Description = "Soft Joints"
                });
                */
            }
        }
    }
}
