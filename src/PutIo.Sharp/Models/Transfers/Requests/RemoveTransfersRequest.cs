using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Requests
{
    public class RemoveTransfersRequest : PutIoPostRequest
    {
        public RemoveTransfersRequest(string removeFilter)
        {
            RemoveFilter = removeFilter;
        }

        public RemoveTransfersRequest(IEnumerable<long> transferIds)
        {
            TransferIds = transferIds;
        }

        public RemoveTransfersRequest(string removeRemoveFilter, IEnumerable<long> transferIds)
        {
            RemoveFilter = removeRemoveFilter;
            TransferIds = transferIds;
        }

        public string RemoveFilter { get; set; }

        public IEnumerable<long> TransferIds { get; set; }

        internal override HttpContent GenerateRequestBody()
        {
            if (RemoveFilter is null && (TransferIds is null || !TransferIds.Any()))
                throw new ArgumentException("If no filter is provided then at least one transfer id must be provided");

            var body = new MultipartFormDataContent();
            
            if (TransferIds != null)
                body.Add(new StringContent(string.Join(",", TransferIds)), "transfer_ids");
            
            if (RemoveFilter != null)
                body.Add(new StringContent(RemoveFilter), "remove_filter");

            return body;
        }
    }
}