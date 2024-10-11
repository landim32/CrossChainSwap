using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IRetweetRepository<TModel, TFactory>
    {
        string GetCurrentTweet();
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser);
        void AddRetweet(long idUser, string retweet);
    }
}
