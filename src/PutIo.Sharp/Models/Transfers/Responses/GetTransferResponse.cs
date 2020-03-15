using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Responses
{
    public class GetTransferResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}