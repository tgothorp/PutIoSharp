using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Zips
{
    public class MissingFile
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("missing")]
        public bool Missing { get; set; }
    }
}