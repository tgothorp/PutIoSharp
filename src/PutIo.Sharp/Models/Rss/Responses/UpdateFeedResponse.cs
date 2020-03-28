using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Rss.Responses
{
    internal class UpdateFeedResponse
    {
        [JsonPropertyName("feed")]
        public Feed Feed { get; set; }
    }
}
