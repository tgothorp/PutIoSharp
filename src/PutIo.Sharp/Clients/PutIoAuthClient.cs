using PutIo.Sharp.Models.Auth.Request;
using PutIo.Sharp.Models.Auth.Response;
using System.Threading.Tasks;

namespace PutIo.Sharp.Clients
{
    public class PutIoAuthClient
    {
        private readonly PutIoApiClient _apiClient;

        public PutIoAuthClient(PutIoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// User must visit http://put.io/link and enter the code.
        /// </summary>
        public async Task<string> GetCode(GetCodeRequest request)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<GetCodeResponse>("oauth2/oob/code", request);
            return response.Code;
        }

        /// <summary>
        /// Check if the code is linked to the user's account
        /// </summary>
        public async Task<string> GetToken(string code)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<GetTokenResponse>($"/oauth2/oob/code/{code}");
            return response.OAuthToken;
        }
    }
}
