using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Account.Response
{
    internal class GetAccountInfoResponse
    {
        [JsonPropertyName("info")]
        public AccountInfo AccountInfo { get; set; }
    }
}