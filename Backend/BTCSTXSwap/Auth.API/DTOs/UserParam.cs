using System;
using System.Text.Json.Serialization;

namespace Auth.API.DTOs
{
    public class UserParam
    {
        public string FromReferralCode { get; set; }
        
        public string PublicAddress { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
    }
}
