﻿using System;
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
        private readonly HttpClient _apiClient;
        private readonly HttpClient _uploadClient;

        public PutIoAccountClient Account;
        public PutIoFileClient Files;

        public PutioApiClient(PutioConfiguration putioConfiguration)
        {
            _apiClient = putioConfiguration.ApiHttpClient ?? new HttpClient();
            _apiClient.BaseAddress = new Uri(putioConfiguration.BaseUrl);
            _apiClient.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");

            _uploadClient = putioConfiguration.UploadHttpClient ?? new HttpClient();
            _apiClient.BaseAddress = new Uri(putioConfiguration.BaseUploadUrl);
            _apiClient.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");
            
            Account = new PutIoAccountClient(this);
            Files = new PutIoFileClient(this);
        }

        internal async Task ExecutePostAsync(string url, PutIoPostRequest requestObject = null)
        {
            var body = requestObject is null 
                ? new StringContent("", Encoding.UTF8, "application/json") 
                : new StringContent(requestObject.Serialize(), Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(url, body);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }
        }

        internal async Task<T> ExecutePostWithResponseAsync<T>(string url, PutIoPostRequest requestObject)
        {
            var body = new StringContent(requestObject.Serialize(), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(url, body);

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
            using (var body = new MultipartContent())
            {
                body.Add(new StringContent(request.Serialize(), Encoding.UTF8, "application/json"));
                body.Add(new StreamContent(request.FileStream));

                var response = await _uploadClient.PutAsync("files/upload", body);
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