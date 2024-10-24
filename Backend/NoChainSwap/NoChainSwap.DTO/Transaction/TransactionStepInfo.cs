using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.DTO.Transaction
{
    public class TransactionStepInfo
    {
        public bool Success { get; set; }
        public bool DoNextStep { get; set; }
    }
}
