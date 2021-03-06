﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Requests
{
    public class CancelTransfersRequest : PutIoPostRequest
    {
        /// <param name="transferIds">List of transfer ids to stop</param>
        public CancelTransfersRequest(IEnumerable<long> transferIds)
        {
            TransferIds = transferIds;
        }

        /// <param name="transferIds">List of transfer ids to stop</param>
        public CancelTransfersRequest(params long[] transferIds)
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