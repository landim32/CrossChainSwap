using System;
using System.Collections.Generic;
using ApliClient.Infra.Impl;
using Xunit;

namespace ApliClient.Infra.Testes
{
    public class ApiClientTeste
    {
        [Fact]
        public async System.Threading.Tasks.Task SuccessPostAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "200" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PostAsync<Usuario>(objeto, url, headers);

                if (response.Success)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task SuccessGetAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var url = "http://localhost:3001/colaboracao?StatusCodeEsperadoConsiderandoUsuarioLogado=200";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.GetAsync<Usuario>(url, headers);

                if (response.Success)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task SuccessPutAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "200" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PutAsync<Usuario>(objeto, url, headers);

                if (response.Success)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task SuccessDeleteAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "200" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.DeleteAsync<Usuario>(objeto, url, headers);

                if (response.Success)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task UnauthorizedPostAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "401" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PostAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "Unauthorized")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task UnauthorizedGetAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var url = "http://localhost:3001/colaboracao?StatusCodeEsperadoConsiderandoUsuarioLogado=401";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.GetAsync<Usuario>(url, headers);

                if (response.HttpStatus == "Unauthorized")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task UnauthorizedPutAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "401" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PutAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "Unauthorized")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task UnauthorizedDeleteAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "401" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.DeleteAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "Unauthorized")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task NotFoundMockPostAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "404" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PostAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "NotFound")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task NotFoundMockGetAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var url = "http://localhost:3001/colaboracao?StatusCodeEsperadoConsiderandoUsuarioLogado=404";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.GetAsync<Usuario>(url, headers);

                if (response.HttpStatus == "NotFound")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task NotFoundMockPutAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "404" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PutAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "NotFound")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task NotFoundMockDeleteAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "404" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.DeleteAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "NotFound")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task InternalServerErrorPostAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "500" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PostAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "InternalServerError")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task InternalServerErrorGetAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var url = "http://localhost:3001/colaboracao?StatusCodeEsperadoConsiderandoUsuarioLogado=500";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.GetAsync<Usuario>(url, headers);

                if (response.HttpStatus == "InternalServerError")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task InternalServerErrorPutAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "500" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.PutAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "InternalServerError")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task InternalServerErrorDeleteAsyncTeste()
        {
            try
            {
                var apiClient = new ApiClient();
                var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "500" };
                var url = "http://localhost:3001/colaboracao";
                var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

                var response = await apiClient.DeleteAsync<Usuario>(objeto, url, headers);

                if (response.HttpStatus == "InternalServerError")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
    }
}
