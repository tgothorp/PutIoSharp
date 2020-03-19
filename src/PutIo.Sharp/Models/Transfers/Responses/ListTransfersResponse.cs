using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    internal class ListTransfersResponse
    {
        [JsonPropertyName("transfers")]
        public List<Transfer> Transfers { get; set; }
    }
}