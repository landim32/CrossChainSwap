using System;
using System.Text.Json.Serialization;

namespace Auth.API.DTOs
{
    public class UserParam
    {
     
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }

    }
}
