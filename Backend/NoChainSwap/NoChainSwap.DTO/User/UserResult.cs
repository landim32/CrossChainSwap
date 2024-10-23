using System;
using NoChainSwap.DTO.Domain;

namespace NoChainSwap.DTO.User
{
    public class UserResult : StatusResult
    {
        public UserInfo User { get; set; }
    }
}
