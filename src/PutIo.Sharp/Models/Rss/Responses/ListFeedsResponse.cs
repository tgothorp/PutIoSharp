using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Rss.Responses
{
    internal class ListFeedsResponse
    {
        [JsonPropertyName("feeds")]
        public List<Feed> Feeds { get; set; }
    }
}
