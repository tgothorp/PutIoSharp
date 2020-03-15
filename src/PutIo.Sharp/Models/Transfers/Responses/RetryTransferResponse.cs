using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    public class RetryTransferResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Type { get; set; }
    }
}