using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Goblins
{
    public class GoblinSpriteModel: IGoblinSpriteModel
    {
        public Bitmap MiningSprite { get; set; }
        public Bitmap TiredSprite { get; set; }
        public string MiningSpriteUrl { get; set; }
        public string TiredSpriteUrl { get; set; }
    }
}
