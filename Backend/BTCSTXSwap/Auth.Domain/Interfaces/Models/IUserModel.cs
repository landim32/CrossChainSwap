﻿using System;
using System.Collections.Generic;
using Auth.Domain.Impl.Models;
using Auth.Domain.Interfaces.Factory;

namespace Auth.Domain.Interfaces.Models
{
    public interface IUserModel
    {
        long Id { get; set; }
        string Hash { get; set; }
        string BtcAddress { get; set; }
        string StxAddress { get; set; }
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }

        IUserModel Save();
        IUserModel Update();
        IUserModel GetUser(string BtcAddress, string StxAddress, IUserDomainFactory factory);
        IUserModel GetById(long userId, IUserDomainFactory factory);
        IEnumerable<IUserModel> ListUsers(IUserDomainFactory factory);
    }
}
