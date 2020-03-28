using System.Collections.Generic;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Zips;
using PutIo.Sharp.Models.Zips.Requests;
using PutIo.Sharp.Models.Zips.Responses;

namespace PutIo.Sharp.Clients
{
    public class PutIoZipClient
    {
        private readonly PutIoApiClient _apiClient;

        public PutIoZipClient(PutIoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Creates a zip link 
        /// </summary>
        /// <returns>The id of the ZIP created</returns>
        public async Task<long> CreateZip(CreateZipRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<CreateZipResponse>("zips/create", request);
            return response.ZipId;
        }

        /// <summary>
        /// List active zipping jobs
        /// </summary>
        public async Task<List<Zip>> ListZips()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListZipResponse>("zips/list");
            return response.Zips;
        }

        /// <summary>
        /// Gives detailed information about the give zip file id. Check the zip creation process status with your zip_id.
        /// When the process is done, you will get url value along with size and missing_files. You might need to poll this end point
        /// until you get an url value. missing_files is an array of file names which are not included into the zip file for some reason.
        /// </summary>
        public async Task<GetZipResponse> GetZip(long zipId)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<GetZipResponse>($"zips/{zipId}");
        }
        
    }
}