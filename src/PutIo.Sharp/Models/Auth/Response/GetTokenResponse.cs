using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Auth.Response
{
    internal class GetTokenResponse
    {
        [JsonPropertyName("oauth_token")]
        public string OAuthToken { get; set; }
    }
}
