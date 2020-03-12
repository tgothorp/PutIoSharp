using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Files
{
    public class Subtitle
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
        
        [JsonPropertyName("language")]
        public SubtitleLanguage Language { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}