using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Account.Response
{
    public class GetAccountInfoResponse
    {
        [JsonPropertyName("info")]
        public AccountInfo AccountInfo { get; set; }
        
        [JsonPropertyName("status")] 
        public string Status { get; set; }
    }
}