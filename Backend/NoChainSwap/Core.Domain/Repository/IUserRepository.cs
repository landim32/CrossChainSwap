using System;
using System.Collections.Generic;

namespace Core.Domain.Repository
{
    public interface IUserRepository<TModel, TFactory>
    {
        TModel SaveUser(TModel model);
        TModel LoadUser(string btcAddress, TFactory factory);
        TModel UpdateUser(TModel model);
        IEnumerable<TModel> ListUsers(TFactory factory);
        TModel GetById(long userId, TFactory factory);
        TModel GetOrCreateByAddress(string btcAddress, string StxAddress, TFactory factory);
    }
}
