using Core.Domain;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class GoblinPerkModel: IGoblinPerkModel
    {
        private readonly IDictionary<GoblinPerkEnum, string> _NAMES = new Dictionary<GoblinPerkEnum, string>() {
            { GoblinPerkEnum.MiningForce1, "Mining Force 1" },
            { GoblinPerkEnum.MiningForce2, "Mining Force 2" },
            { GoblinPerkEnum.MiningForce3, "Mining Force 3" },
            { GoblinPerkEnum.MiningPersistence1, "Mining Persistence 1" },
            { GoblinPerkEnum.MiningPersistence2, "Mining Persistence 2" },
            { GoblinPerkEnum.MiningPersistence3, "Mining Persistence 3" },
            { GoblinPerkEnum.MiningWill1, "Mining Will 1" },
            { GoblinPerkEnum.MiningWill2, "Mining Will 2" },
            { GoblinPerkEnum.MiningWill3, "Mining Will 3" },
        };

        private readonly IDictionary<GoblinPerkEnum, string> _DESCRIPTIONS = new Dictionary<GoblinPerkEnum, string>() {
            { GoblinPerkEnum.MiningForce1, "Mine 5% more GOBI" },
            { GoblinPerkEnum.MiningForce2, "Mine 10% more GOBI" },
            { GoblinPerkEnum.MiningForce3, "Mine 15% more GOBI" },
            { GoblinPerkEnum.MiningPersistence1, "Spend 5% less energy" },
            { GoblinPerkEnum.MiningPersistence2, "Spend 10% less energy" },
            { GoblinPerkEnum.MiningPersistence3, "Spend 15% less energy" },
            { GoblinPerkEnum.MiningWill1, "Increases hash power by 5%" },
            { GoblinPerkEnum.MiningWill2, "Increases hash power by 10%" },
            { GoblinPerkEnum.MiningWill3, "Increases hash power by 15%" },
        };

        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;

        public GoblinPerkModel(ILogCore log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public long Id { get; set; }
        public long IdGoblin { get; set; }
        public string Name { 
            get
            {
                if (_NAMES.ContainsKey(Perk))
                {
                    return _NAMES[Perk];
                }
                return string.Empty;
            } 
        }
        public string Description {
            get
            {
                if (_DESCRIPTIONS.ContainsKey(Perk))
                {
                    return _DESCRIPTIONS[Perk];
                }
                return string.Empty;
            }
        }
        public GoblinPerkEnum Perk { get; set; }
    }
}
