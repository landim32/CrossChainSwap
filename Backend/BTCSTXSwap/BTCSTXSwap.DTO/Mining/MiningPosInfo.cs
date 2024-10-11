using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Mining
{
    public class MiningPosInfo
    {
        public MiningPosInfo(int px, int py, bool pright)
        {
            x = px;
            y = py;
            Right = pright;
        }

        public MiningPosInfo(): this(0, 0, true)
        {

        }

        public int x { get; set; }
        public int y { get; set; }
        public bool Right { get; set; } = true;
    }
}
