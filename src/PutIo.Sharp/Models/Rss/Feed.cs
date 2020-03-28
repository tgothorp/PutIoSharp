using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Rss
{
    public class Feed
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("rss_source_url")]
        public string RssSourceUrl { get; set; }

        [JsonPropertyName("parent_dir_id")]
        public long ParentDirectoryId { get; set; }

        [JsonPropertyName("delete_old_files")]
        public bool DeleteOldFiles { get; set; }

        [JsonPropertyName("keyword")]
        public string Keyword { get; set; }

        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        [JsonPropertyName("paused_at")]
        public DateTime? PausedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }

    }
}
