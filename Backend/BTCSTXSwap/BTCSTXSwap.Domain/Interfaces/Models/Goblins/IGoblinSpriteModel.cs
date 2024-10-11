using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinSpriteModel
    {
        Bitmap MiningSprite { get; set; }
        Bitmap TiredSprite { get; set; }
        string MiningSpriteUrl { get; set; }
        string TiredSpriteUrl { get; set; }
    }
}
