using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models
{
    public interface IWorkItemMaterialModel
    {
        public int ItemKey { get; set; }
        public int Qtde { get; set; }
    }
}
