using System.Collections.Generic;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Shares;
using PutIo.Sharp.Models.Shares.Requests;
using PutIo.Sharp.Models.Shares.Response;

namespace PutIo.Sharp.Clients
{
    public class PutIoShareClient
    {
        private readonly PutIoApiClient _apiClient;

        public PutIoShareClient(PutIoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Share file(s) with one or more friends
        /// </summary>
        public async Task ShareFiles(ShareFilesRequest request)
        {
            await _apiClient.ExecutePostAsync("files/share", request);
        }

        /// <summary>
        /// List all your shared files
        /// </summary>
        public async Task<List<Share>> ListSharedFiles()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListSharedFilesResponse>("files/shared");
            return response.Shared;
        }

        /// <summary>
        /// List all users that the file is shared with
        /// </summary>
        public async Task<List<SharedWith>> SharedWith(long fileId)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<SharedWithResponse>($"files/{fileId}/shared-with");
            return response.SharedWith;
        }
    }
}