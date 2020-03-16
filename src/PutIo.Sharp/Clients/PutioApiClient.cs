using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Exceptions;
using PutIo.Sharp.Models.Files.Requests;

namespace PutIo.Sharp.Clients
{
    public class PutioApiClient
    {
        private readonly HttpClient _apiClient;
        private readonly HttpClient _uploadClient;

        public readonly PutIoAccountClient Account;
        public readonly PutIoFileClient Files;
        public readonly PutIoTransferClient Transfers;
        public readonly PutIoZipClient Zips;

        public PutioApiClient(PutioConfiguration putioConfiguration)
        {
            _apiClient = putioConfiguration.ApiHttpClient ?? new HttpClient();
            _apiClient.BaseAddress = new Uri(putioConfiguration.BaseUrl);
            _apiClient.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");

            _uploadClient = putioConfiguration.UploadHttpClient ?? new HttpClient();
            _uploadClient.BaseAddress = new Uri(putioConfiguration.BaseUploadUrl);
            _uploadClient.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");
            
            Account = new PutIoAccountClient(this);
            Files = new PutIoFileClient(this);
            Transfers = new PutIoTransferClient(this);
            Zips = new PutIoZipClient(this);
        }

        internal async Task ExecutePostAsync(string url, PutIoPostRequest requestObject = null)
        {
            var body = requestObject is null 
                ? new StringContent("", Encoding.UTF8, "application/json") 
                : requestObject.GenerateRequestBody();

            var response = await _apiClient.PostAsync(url, body);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }
        }

        internal async Task<T> ExecutePostWithResponseAsync<T>(string url, PutIoPostRequest requestObject)
        {
            var response = await _apiClient.PostAsync(url, requestObject.GenerateRequestBody());

            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }

            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(rawResponse);
        }

        internal async Task<T> ExecuteGetWithResponseAsync<T>(string url, PutIoGetRequest requestObject = null)
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

        internal async Task UploadFileAsync(UploadFileRequest request)
        {
            using (var body = new MultipartFormDataContent())
            {
                if (request.ParentId != null)
                    body.Add(new StringContent(request.ParentId.Value.ToString()), "parent_id");
                
                body.Add(new ByteArrayContent(request.File), "file", request.FileName);

                var response = await _uploadClient.PostAsync("files/upload", body);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleApiError(response);
                }
            }
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