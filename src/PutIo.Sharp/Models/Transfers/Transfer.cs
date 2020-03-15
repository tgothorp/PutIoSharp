using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers
{
    public class Transfer
    {
        [JsonPropertyName("availability")]
        public long? Availability { get; set; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("client_ip")]
        public string ClientIp { get; set; }

        [JsonPropertyName("completion_percent")]
        public long? CompletionPercent { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_torrent")]
        public bool CreatedTorrent { get; set; }
        
        [JsonPropertyName("current_ratio")]
        public long? CurrentRatio { get; set; }

        [JsonPropertyName("down_speed")]
        public long? DownSpeed { get; set; }

        [JsonPropertyName("download_id")]
        public long? DownloadId { get; set; }
        
        [JsonPropertyName("downloaded")]
        public long? Downloaded { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
        
        [JsonPropertyName("estimated_time")]
        public long? EstimatedTime { get; set; }
        
        [JsonPropertyName("file_id")]
        public long? FileId { get; set; }
        
        [JsonPropertyName("finished_at")]
        public DateTime? FinishedAt { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("links")]
        public string[] Links { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("peers")]
        public long? Peers { get; set; }

        [JsonPropertyName("peers_connected")]
        public long? PeersConnected { get; set; }
        
        [JsonPropertyName("peers_getting_from_us")]
        public long? PeersGettingFromUs { get; set; }
        
        [JsonPropertyName("peers_sending_to_us")]
        public long? PeersSendingToUs { get; set; }

        [JsonPropertyName("percent_done")]
        public long? PercentDone { get; set; }

        [JsonPropertyName("save_parent_id")]
        public long? SaveParentId { get; set; }

        [JsonPropertyName("seconds_seeding")]
        public long? SecondsSeeding { get; set; }

        [JsonPropertyName("simulated")]
        public bool Simulated { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; }

        [JsonPropertyName("subscription_id")]
        public long? SubscriptionId { get; set; }

        [JsonPropertyName("torrent_link")]
        public string TorrentLink { get; set; }

        [JsonPropertyName("tracker")]
        public string Tracker { get; set; }

        [JsonPropertyName("tracker_message")]
        public string TrackerMessage { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("up_speed")]
        public long? UpSpeed { get; set; }

        [JsonPropertyName("uploaded")]
        public long? Uploaded { get; set; }
    }
}