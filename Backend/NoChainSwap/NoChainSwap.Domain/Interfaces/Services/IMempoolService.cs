﻿using NoChainSwap.DTO.Mempool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoChainSwap.Domain.Interfaces.Services
{
    public interface IMempoolService
    {
        Task<long> GetBalance(string address);
        Task<RecommendedFeeInfo> GetRecommededFee();
        Task<MemPoolTxInfo> GetTransaction(string txid);
    }
}
