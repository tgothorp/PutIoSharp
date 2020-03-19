using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    internal class AddTransferResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}