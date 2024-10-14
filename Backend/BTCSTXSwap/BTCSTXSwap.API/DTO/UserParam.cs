using System;
using System.Text.Json.Serialization;

namespace BTCSTXSwap.API.DTO
{
    public class UserParam
    {
     
        public string BtcAddress { get; set; }
        public string StxAddress { get; set; }

    }
}
