using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Mining
{
    public class GoblinImgModel
    {
        public Image Stop1 { get; set; }
        public Image Stop2 { get; set; }
        public Image Up1 { get; set; }
        public Image Up2 { get; set; }
        public Image Up3 { get; set; }
        public Image UpWithSpark1 { get; set; }
        public Image UpWithSpark2 { get; set; }
        public Image Down1 { get; set; }
        public Image Down2 { get; set; }
        public Image Down3 { get; set; }
        public int FrameIndex { get; set; }
    }
}
