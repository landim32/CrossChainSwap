using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinPerkModel
    {
        long Id { get; set; }
        long IdGoblin { get; set; }
        string Name { get; }
        string Description { get; }
        GoblinPerkEnum Perk { get; set; }
    }
}
