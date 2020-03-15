using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class SetVideoPositionRequest : PutIoPostRequest
    {
        public SetVideoPositionRequest(long fileId, long timeInSeconds)
        {
            FileId = fileId;
            TimeInSeconds = timeInSeconds;
        }
        
        [JsonIgnore]
        public long FileId { get; set; }

        [JsonPropertyName("time")]
        public long TimeInSeconds { get; set; }

        internal override HttpContent GenerateRequestBody()
        {
            return new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");
        }
    }
}