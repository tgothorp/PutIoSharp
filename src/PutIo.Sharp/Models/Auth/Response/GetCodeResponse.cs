using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Auth.Response
{
    internal class GetCodeResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
