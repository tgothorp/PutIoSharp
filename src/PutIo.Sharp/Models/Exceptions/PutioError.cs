using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Exceptions
{
    public class PutioError
    {
        [JsonPropertyName("error_id")]
        public long? Id { get; set; }
        
        [JsonPropertyName("error_message")]
        public string Message { get; set; }
        
        [JsonPropertyName("error_type")]
        public string Type { get; set; }
        
        [JsonPropertyName("error_uri")]
        public string Uri { get; set; }
        
        [JsonPropertyName("extra")]
        public object Extra { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
    }
}