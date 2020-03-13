using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    public class ListTransfersResponse
    {
        [JsonPropertyName("transfers")]
        public List<Transfer> Transfers { get; set; }
    }
}