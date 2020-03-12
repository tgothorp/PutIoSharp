using System.Threading.Tasks;
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
        public async Task<GetAccountInfoResponse> GetAccountInfo()
        {
            return await _apiClient.ExecuteGetAsync<GetAccountInfoResponse>("account/info");
        }

        /// <summary>
        /// Get account settings (these are included when calling <see cref="GetAccountInfo"/>)
        /// </summary>
        public async Task<GetAccountSettingsResponse> GetAccountSettings()
        {
            return await _apiClient.ExecuteGetAsync<GetAccountSettingsResponse>("account/settings");
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