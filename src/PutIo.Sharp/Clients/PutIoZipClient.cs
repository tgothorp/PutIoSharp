using System.Threading.Tasks;
using PutIo.Sharp.Models.Zips.Requests;
using PutIo.Sharp.Models.Zips.Responses;

namespace PutIo.Sharp.Clients
{
    public class PutIoZipClient
    {
        private readonly PutioApiClient _apiClient;

        public PutIoZipClient(PutioApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Creates a zip link 
        /// </summary>
        public async Task<CreateZipResponse> CreateZip(CreateZipRequest request)
        {
            return await _apiClient.ExecutePostWithResponseAsync<CreateZipResponse>("zips/create", request);
        }

        /// <summary>
        /// List active zipping jobs
        /// </summary>
        public async Task<ListZipResponse> ListZips()
        {
            return await _apiClient.ExecuteGetWithResponseAsync<ListZipResponse>("zips/list");
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