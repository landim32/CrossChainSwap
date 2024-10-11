using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApliClient.Infra.Interfaces;

namespace ApliClient.Infra.Impl
{
    public class ApiClient : IApiClient
    {
        public async Task<ServiceResponse<T>> PostAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.PostAsync(url, conteudo))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new ServiceResponse<T>
                            {
                                Response = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Success = true,
                                Message = ""
                            };
                        }
                        else
                        {
                            return new ServiceResponse<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Success = false,
                                Message = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = "400",
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<T>> GetAsync<T>(string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new ServiceResponse<T>
                            {
                                Response = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Success = true,
                                Message = ""
                            };
                        }
                        else
                        {
                            return new ServiceResponse<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Success = false,
                                Message = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = "400",
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<T>> PutAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.PutAsync(url, conteudo))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new ServiceResponse<T>
                            {
                                Response = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Success = true,
                                Message = ""
                            };
                        }
                        else
                        {
                            return new ServiceResponse<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Success = false,
                                Message = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = "400",
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<T>> DeleteAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    var request = new HttpRequestMessage
                    {
                        Content = conteudo,
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(url)
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new ServiceResponse<T>
                            {
                                Response = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Success = true,
                                Message = ""
                            };
                        }
                        else
                        {
                            return new ServiceResponse<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Success = false,
                                Message = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = "400",
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<T>> PostMultiFormAsync<T>(MultipartFormDataContent form, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.PostAsync(url, form))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new ServiceResponse<T>
                            {
                                Response = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Success = true,
                                Message = ""
                            };
                        }
                        else
                        {
                            return new ServiceResponse<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Success = false,
                                Message = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    HttpStatus = "400",
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
