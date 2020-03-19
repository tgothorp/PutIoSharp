using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shared
{
    public class Friend
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}