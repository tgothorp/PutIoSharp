using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    internal class RetryTransferResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}