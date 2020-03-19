using System.Threading.Tasks;
using PutIo.Sharp.Models.Account;
using PutIo.Sharp.Models.Account.Requests;
using PutIo.Sharp.Models.Account.Response;

namespace PutIo.Sharp.Clients
{
    public class PutIoAccountClient
    {
        private readonly PutioApiClient _apiClient;

        public PutIoAccountClient(PutioApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        
        /// <summary>
        /// Get account info
        /// </summary>
        public async Task<AccountInfo> GetAccountInfo()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<GetAccountInfoResponse>("account/info");
            return response.AccountInfo;
        }

        /// <summary>
        /// Get account settings (these are included when calling <see cref="GetAccountInfo"/>)
        /// </summary>
        public async Task<AccountSettings> GetAccountSettings()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<GetAccountSettingsResponse>("account/settings");
            return response.Settings;
        }
        
        /// <summary>
        /// Update account settings
        /// </summary>
        public async Task UpdateAccountSettings(UpdateAccountSettingsRequest request)
        {
            await _apiClient.ExecutePostAsync("account/settings", request);
        }
    }
}