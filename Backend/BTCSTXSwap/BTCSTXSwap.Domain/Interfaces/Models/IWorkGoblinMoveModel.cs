using BTCSTXSwap.Domain.Impl.Models.Goblins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IWorkGoblinMoveModel
    {
        public AttributeEnum Attribute { get; set; }
        public int SkillKey { get; set; }
        public int MinNH { get; set; }
    }
}
