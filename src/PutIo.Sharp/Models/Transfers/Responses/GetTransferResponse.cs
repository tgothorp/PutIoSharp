using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    internal class GetTransferResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}