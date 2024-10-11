using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Factory
{
    public class RaceDomainFactory : IRaceDomainFactory
    {
        public IRaceModel BuildRaceModel(RaceEnum r)
        {
            IRaceModel race = null;
            switch (r)
            {
                case RaceEnum.Forest:
                    race = new FlorestModel();
                    break;
                case RaceEnum.Mountain:
                    race = new MountainModel();
                    break;
                case RaceEnum.Desert:
                    race = new DesertModel();
                    break;
                case RaceEnum.Sea:
                    race = new SeaModel();
                    break;
                case RaceEnum.Cave:
                    race = new CaveModel();
                    break;
                case RaceEnum.Dark:
                    race = new DarkGoblinModel();
                    break;
            }
            return race;
        }
    }
}
