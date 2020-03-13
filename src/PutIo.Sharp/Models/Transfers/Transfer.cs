using System;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers
{
    public class Transfer
    {
        [JsonPropertyName("availability")]
        public long Availability { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("current_ratio")]
        public long CurrentRatio { get; set; }
        
        [JsonPropertyName("downloaded")]
        public long Downloaded { get; set; }
        
        [JsonPropertyName("uploaded")]
        public long Uploaded { get; set; }
        
        [JsonPropertyName("down_speed")]
        public long DownSpeed { get; set; }
        
        [JsonPropertyName("up_speed")]
        public long UpSpeed { get; set; }
        
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
        
        [JsonPropertyName("estimated_time")]
        public long EstimatedTime { get; set; }
        
        [JsonPropertyName("file_id")]
        public long FileId { get; set; }
        
        [JsonPropertyName("finished_at")]
        public DateTime? FinishedAt { get; set; }
        
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("peers")]
        public long Peers { get; set; }
        
        [JsonPropertyName("percent_done")]
        public int PercentDone { get; set; }
        
        [JsonPropertyName("save_parent_id")]
        public long SaveParentId { get; set; }
        
        [JsonPropertyName("seconds_seeding")]
        public long SecondsSeeding { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }
        
        [JsonPropertyName("source")]
        public string Source { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("subscription_id")]
        public long SubscriptionId { get; set; }
        
        [JsonPropertyName("tracker_message")]
        public string TrackerMessage { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}