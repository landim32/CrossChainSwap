using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository.Referral
{
    public class RetweetRepository : IRetweetRepository<IRetweetModel, IRetweetDomainFactory>
    {

        private GoblinWarsContext _goblinContext;

        private const string LAST_TWEET_URL = "LAST_TWEET_URL";

        public RetweetRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        public string GetCurrentTweet()
        {
            return _goblinContext.Configurations
                .Where(x => x.Name == LAST_TWEET_URL)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        private IRetweetModel DbToModel(IRetweetDomainFactory factory, ReTweet info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildRetweetModel();
            md.Id = info.Id;
            md.IdUser = info.IdUser;
            md.Tweet = info.Tweet;
            return md;
        }

        public IEnumerable<IRetweetModel> ListByUser(IRetweetDomainFactory factory, long idUser)
        {
            return _goblinContext.ReTweets
                .Where(x => x.IdUser == idUser)
                .ToList()
                .Select(x => DbToModel(factory, x));
        }

        public void AddRetweet(long idUser, string retweet)
        {
            var info = new ReTweet();
            info.IdUser = idUser;
            info.Tweet = retweet;
            _goblinContext.ReTweets.Add(info);
            _goblinContext.SaveChanges();
        }
    }
}
