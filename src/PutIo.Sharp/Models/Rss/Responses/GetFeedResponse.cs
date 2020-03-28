using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Rss.Responses
{
    internal class GetFeedResponse
    {
        [JsonPropertyName("feed")]
        public Feed Feed { get; set; }
    }
}
