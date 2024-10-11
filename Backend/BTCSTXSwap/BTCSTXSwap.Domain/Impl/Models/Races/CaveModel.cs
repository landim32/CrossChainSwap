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
    public class CaveModel: IRaceModel
    {
        public void DoPureRace(IBuildGoblinModel Goblin)
        {
            Goblin.Race = RaceEnum.Cave;
            Goblin.Skin = RaceEnum.Cave;
            Goblin.Hair = RaceEnum.Cave;
            Goblin.Ear = RaceEnum.Cave;
            Goblin.Eye = RaceEnum.Cave;
            Goblin.Mount = RaceEnum.Cave;
        }

        public void Generate(IBuildGoblinModel Goblin)
        {
            if (Goblin.Race == RaceEnum.Cave)
            {
                Goblin.Strength++;
                Goblin.Vigor++;
                Goblin.Charism--;
                Goblin.Perception--;
            }
            if (Goblin.Skin == RaceEnum.Cave)
            {
                Goblin.Agility++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Rigidity,
                    Description = "Rigidity"
                });
                */
            }
            if (Goblin.Hair == RaceEnum.Cave)
            {
                Goblin.Strength++;
                Goblin.Charism++;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Dyslexia,
                    Description = "Dyslexia"
                });
                */
            }
            if (Goblin.Ear == RaceEnum.Cave)
            {
                Goblin.Intelligence++;
                Goblin.Perception--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Sonar,
                    Description = "Sonar"
                });
                */
            }
            if (Goblin.Eye == RaceEnum.Cave)
            {
                Goblin.Agility++;
                Goblin.Intelligence--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.Myopic,
                    Description = "Myopic"
                });
                */
            }
            if (Goblin.Mount == RaceEnum.Cave)
            {
                Goblin.Vigor++;
                Goblin.Charism--;
                /*
                Goblin.Features.Add(new GoblinFeatureModel
                {
                    FeatureType = FeatureTypeEnum.IronStomach,
                    Description = "Iron Stomach"
                });
                */
            }
        }
    }
}
