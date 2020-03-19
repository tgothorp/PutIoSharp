using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shares
{
    public class SharedWith
    {
        [JsonPropertyName("user_name")]
        public string Username { get; set; }

        [JsonPropertyName("user_avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("share_id")]
        public long ShareId { get; set; }
    }
}