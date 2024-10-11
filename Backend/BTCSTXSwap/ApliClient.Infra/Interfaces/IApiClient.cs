using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApliClient.Infra.Impl;

namespace ApliClient.Infra.Interfaces
{
    public interface IApiClient
    {
        Task<ServiceResponse<T>> PostAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers);
        Task<ServiceResponse<T>> GetAsync<T>(string url, List<KeyValuePair<string, string>> headers);
        Task<ServiceResponse<T>> PutAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers);
        Task<ServiceResponse<T>> DeleteAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers);
        Task<ServiceResponse<T>> PostMultiFormAsync<T>(MultipartFormDataContent form, string url, List<KeyValuePair<string, string>> headers);
    }
}