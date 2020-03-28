using PutIo.Sharp.Models.Auth.Request;
using PutIo.Sharp.Models.Auth.Response;
using PutIo.Sharp.Models.Exceptions;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PutIo.Sharp.Clients
{
    public class PutIoAuthClient : IDisposable
    {
        private readonly HttpClient _apiClient;

        public PutIoAuthClient() : this("https://api.put.io/v2/") { }

        public PutIoAuthClient(string baseUrl)
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// User must visit http://put.io/link and enter the code.
        /// </summary>
        public async Task<string> GetCode(GetCodeRequest request)
        {
            var response = await ExecuteGetWithResponseAsync<GetCodeResponse>("oauth2/oob/code", request);
            return response.Code;
        }

        /// <summary>
        /// Check if the code is linked to the user's account
        /// </summary>
        public async Task<string> GetToken(string code)
        {
            var response = await ExecuteGetWithResponseAsync<GetTokenResponse>($"/oauth2/oob/code/{code}");
            return response.OAuthToken;
        }

        private async Task<T> ExecuteGetWithResponseAsync<T>(string url, PutIoGetRequest requestObject = null)
        {
            if (requestObject != null)
                url = $"{url}?{requestObject.BuildQueryString()}";

            var response = await _apiClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }

            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(rawResponse);
        }

        private async Task HandleApiError(HttpResponseMessage responseMessage)
        {
            PutioError error;

            try
            {
                var rawResponse = await responseMessage.Content.ReadAsStringAsync();
                error = JsonSerializer.Deserialize<PutioError>(rawResponse);
            }
            catch (Exception e)
            {
                throw new PutioException(e);
            }

            throw new PutioException(error);
        }

        public void Dispose()
        {
            _apiClient.Dispose();
        }
    }
}
