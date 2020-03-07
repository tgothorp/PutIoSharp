using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Account;
using PutIo.Sharp.Models.Account.Requests;
using PutIo.Sharp.Models.Account.Response;
using PutIo.Sharp.Models.Exceptions;

namespace PutIo.Sharp
{
    public class PutioApiClient
    {
        private readonly HttpClient _client;

        public PutioApiClient(PutioConfiguration putioConfiguration)
        {
            _client = putioConfiguration.HttpClient ?? new HttpClient();
            _client.BaseAddress = new Uri(putioConfiguration.BaseUrl);
            _client.DefaultRequestHeaders.Add("authorization", $"bearer {putioConfiguration.Token}");
        }

        /// <summary>
        /// Get account info
        /// </summary>
        /// <returns>Account information for the user, see <see cref="AccountInfo"/> for details</returns>
        public async Task<AccountInfo> GetAccountInfo()
        {
            var accountInfoResponse = await ExecuteGetAsync<GetAccountInfoResponse>("account/info");
            return accountInfoResponse.AccountInfo;
        }

        /// <summary>
        /// Get account settings (these are included when calling <see cref="GetAccountInfo"/>)
        /// </summary>
        /// <returns>Account setting for the user, see <see cref="AccountSettings"/></returns>
        public async Task<AccountSettings> GetAccountSettings()
        {
            var accountSettingsResponse = await ExecuteGetAsync<GetAccountSettingsResponse>("account/settings");
            return accountSettingsResponse.Settings;
        }
        
        /// <summary>
        /// Update account settings
        /// </summary>
        /// <param name="request">See <see cref="UpdateAccountSettings"/> for individual settings</param>
        /// <returns>Task</returns>
        public async Task UpdateAccountSettings(UpdateAccountSettingsRequest request)
        {
            await ExecutePostAsync("account/settings", request);
        }

        private async Task ExecutePostAsync(string url, object requestObject)
        {
            var requestJson = JsonSerializer.Serialize(requestObject);
            var body = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, body);
            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }
        }

        private async Task<T> ExecutePostAsync<T>(string url, object requestObject)
        {
            var body = new StringContent(JsonSerializer.Serialize(requestObject), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, body);

            if (!response.IsSuccessStatusCode)
            {
                await HandleApiError(response);
            }

            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(rawResponse);
        }

        private async Task<T> ExecuteGetAsync<T>(string url)
        {
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