using BTCSTXSwap.Domain.Impl.Models.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Mining
{
    public interface IMiningRewardModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        DateTime InsertDate { get; set; }
        DateTime? ClaimDate { get; set; }
        decimal GobiValue { get; set; }
        decimal Credit { get; set; }
        decimal Fee { get; set; }
        long HashValue { get; set; }
        MiningRewardStatusEnum Status { get; set; }

        IEnumerable<IMiningRewardModel> List(long idUser, int limit);
        IMiningRewardModel GetById(long id);
        decimal GetBalanceClaimable(long idUser);
        void Update();

    }
}
