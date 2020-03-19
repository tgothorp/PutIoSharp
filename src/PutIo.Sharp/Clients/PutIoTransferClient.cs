using System.Collections.Generic;
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
        public async Task<List<Transfer>> ListTransfers()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListTransfersResponse>("transfers/list");
            return response.Transfers;
        }

        /// <summary>
        /// Get a specific transfer
        /// </summary>
        public async Task<Transfer> Transfer(long transferId)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<GetTransferResponse>($"transfers/{transferId}");
            return response.Transfer;
        }

        /// <summary>
        /// Add a transfer from url, If you want to upload a torrent file, use /files/upload endpoint.
        /// </summary>
        public async Task<Transfer> AddTransfer(AddTransferRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<AddTransferResponse>("transfers/add", request);
            return response.Transfer;
        }

        /// <summary>
        /// Retry failed transfer 
        /// </summary>
        public async Task<Transfer> RetryTransfer(long transferId)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<RetryTransferResponse>($"transfers/retry?id={transferId}");
            return response.Transfer;
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
        public async Task<CleanTransfersResponse> CleanTransfers(CleanTransfersRequest request)
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