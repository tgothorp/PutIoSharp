using System.Threading.Tasks;
using PutIo.Sharp.Models.Transfers;
using PutIo.Sharp.Models.Transfers.Requests;
using PutIo.Sharp.Models.Transfers.Responses;

namespace PutIo.Sharp.Clients
{
    public class PutIoTransferClient
    {
        private readonly PutioApiClient _apiClient;

        public PutIoTransferClient(PutioApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// List all transfers for user
        /// </summary>
        public async Task<ListTransfersResponse> ListTransfers()
        {
            return await _apiClient.ExecuteGetWithResponseAsync<ListTransfersResponse>("transfers/list");
        }

        /// <summary>
        /// Get a specific transfer
        /// </summary>
        public async Task<Transfer> Transfer(long transferId)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<Transfer>($"transfers/{transferId}");
        }

        /// <summary>
        /// Add a transfer from url, If you want to upload a torrent file, use /files/upload endpoint.
        /// </summary>
        public async Task<Transfer> AddTransfer(AddTransferRequest request)
        {
            return await _apiClient.ExecutePostWithResponseAsync<Transfer>("transfers/add", request);
        }

        /// <summary>
        /// Retry failed transfer 
        /// </summary>
        public async Task<Transfer> RetryTransfer(long transferId)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<Transfer>($"transfers/retry?id={transferId}");
        }

        /// <summary>
        /// Cancels or removes transfers. If transfer is in SEEDING state, stops seeding. Else, removes transfer entry. Does not remove their files.
        /// </summary>
        public async Task CancelTransfers(CancelTransfersRequest request)
        {
            await _apiClient.ExecutePostAsync("transfers/cancel", request);
        }

        /// <summary>
        /// Only removes transfer entries, does not remove files.
        /// </summary>
        public async Task<CleanTransfersResponse> CleanTransfers(CancelTransfersRequest request)
        {
            return await _apiClient.ExecutePostWithResponseAsync<CleanTransfersResponse>("transfers/clean", request);
        }

        /// <summary>
        /// Removes transfers
        /// </summary>
        public async Task RemoveTransfers(RemoveTransfersRequest request)
        {
            await _apiClient.ExecutePostAsync("transfers/remove", request);
        }
    }
}