using System;
using System.Net.Http;

namespace ApliClient.Infra.Impl
{
    public class ServiceResponse<T>
    {
        public string HttpStatus { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}

