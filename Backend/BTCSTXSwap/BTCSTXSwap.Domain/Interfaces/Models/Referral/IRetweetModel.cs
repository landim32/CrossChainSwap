using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Referral
{
    public interface IRetweetModel
    {
        int Id { get; set; }
        long IdUser { get; set; }
        string Tweet { get; set; }

        string GetCurrentTweet();
        void AddTweet(long idUser, string tweetUrl);
    }
}
