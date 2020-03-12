using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Exceptions;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Models.Files.Response;

namespace PutIo.Sharp.Clients
{
    public class PutioApiClient
    {
        private readonly HttpClient _client;

        public PutIoAccountClient Account;
        public PutIoFileClient Files;

        public PutioApiClient(PutioConfiguration putioConfiguration)
        {
            _client = putioConfiguration.HttpClient ?? new HttpClient();
            _client.BaseAddress = new Uri(putioConfiguration.BaseUrl);
            _client.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");
            
            Account = new PutIoAccountClient(this);
            Files = new PutIoFileClient(this);
        }

        internal async Task ExecutePostAsync(string url, PutIoPostRequest requestObject)
        {
            var body = new StringContent(requestObject.Serialize(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, body);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }
        }
        
        internal async Task ExecutePostAsync(string url)
        {
            var body = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, body);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }
        }

        internal async Task<T> ExecutePostAsync<T>(string url, PutIoPostRequest requestObject)
        {
            var body = new StringContent(requestObject.Serialize(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, body);

            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }

            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(rawResponse);
        }

        internal async Task<T> ExecuteGetAsync<T>(string url, PutIoGetRequest requestObject = null)
        {
            if (requestObject != null)
                url = $"{url}?{requestObject.BuildQueryString()}";

            var response = await _client.GetAsync(url);
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
    }
}