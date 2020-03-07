using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Account.Response
{
    internal class GetAccountSettingsResponse
    {
        [JsonPropertyName("settings")]
        public AccountSettings Settings { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}