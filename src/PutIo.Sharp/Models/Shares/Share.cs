using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shares
{
    public class Share
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }
    }
}