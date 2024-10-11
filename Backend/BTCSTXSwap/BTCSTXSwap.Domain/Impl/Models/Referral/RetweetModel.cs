using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Referral
{
    public class RetweetModel: IRetweetModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRetweetRepository<IRetweetModel, IRetweetDomainFactory> _repRetweet;

        public RetweetModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IRetweetRepository<IRetweetModel, IRetweetDomainFactory> repRetweet
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _repRetweet = repRetweet;
        }

        public int Id { get; set; }
        public long IdUser { get; set; }
        public string Tweet { get; set; }

        public string GetCurrentTweet()
        {
            return _repRetweet.GetCurrentTweet();
        }

        public void AddTweet(long idUser, string tweetUrl)
        {
            _repRetweet.AddRetweet(idUser, tweetUrl);
        }
    }
}
