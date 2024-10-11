using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IWorkToolModel
    {
        public int ItemKey { get; set; }
        public int TimeBonus { get; set; }
        public int TimeReduce { get; set; }
        public int DifficultReduce { get; set; }
        public bool Required { get; set; }
    }
}
