using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    public class CleanTransfersResponse
    {
        [JsonPropertyName("deleted_ids")]
        public List<long> DeletedIds { get; set; }
    }
}