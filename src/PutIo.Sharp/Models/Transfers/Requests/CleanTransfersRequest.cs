using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Requests
{
    public class CleanTransfersRequest : PutIoPostRequest
    {
        /// <summary>
        /// Clean all completed transfers
        /// </summary>
        public CleanTransfersRequest() { }

        /// <summary>
        /// removes selected complete transfers
        /// </summary>
        public CleanTransfersRequest(IEnumerable<long> transferIds)
        {
            TransferIds = transferIds;
        }

        /// <summary>
        /// removes selected complete transfers
        /// </summary>
        public CleanTransfersRequest(params long[] transferIds)
        {
            TransferIds = transferIds;
        }

        [JsonPropertyName("transfer_ids")]
        public IEnumerable<long> TransferIds { get; set; }
        
        internal override HttpContent GenerateRequestBody()
        {
            return new MultipartFormDataContent {{new StringContent(string.Join(",", TransferIds)), "transfer_ids"}};
        }
    }
}