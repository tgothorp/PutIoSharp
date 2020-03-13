using System;
using System.Collections.Generic;
using System.Linq;
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

        [JsonPropertyName("remove_filter")]
        public string RemoveFilter { get; set; }

        [JsonPropertyName("transfer_ids")]
        public IEnumerable<long> TransferIds { get; set; }

        internal override string Serialize()
        {
            if (RemoveFilter is null && (TransferIds is null || !TransferIds.Any()))
                throw new ArgumentException("If no filter is provided then at least one transfer id must be provided");

            return JsonSerializer.Serialize(this);
        }
    }
}