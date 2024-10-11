using System;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.DTO.User
{
    public class UserResult : StatusResult
    {
        public UserInfo User { get; set; }
    }
}
