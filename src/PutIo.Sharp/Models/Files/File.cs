using System;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Files
{
    public class File
    {
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }
        
        [JsonPropertyName("crc32")]
        public string CRC32Checksum { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("extension")]
        public string Extension { get; set; }
        
        [JsonPropertyName("file_type")]
        public FileType FileType { get; set; }
        
        [JsonPropertyName("first_accessed_at")]
        public DateTime? FirstAccessedAt { get; set; }
        
        [JsonPropertyName("folder_type")]
        public string FolderType { get; set; }
        
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
        
        [JsonPropertyName("is_mp4_available")]
        public bool IsMp4Available { get; set; }
        
        [JsonPropertyName("is_shared")]
        public bool IsShared { get; set; }

        [JsonPropertyName("need_convert")]
        public bool ConversionNeeded { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("opensubtitles_hash")]
        public string OpenSubtitlesHash { get; set; }
        
        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }
        
        [JsonPropertyName("screenshot")]
        public string Screenshot { get; set; }

        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("mp4_size")]
        public long? Mp4Size { get; set; }
        
        [JsonPropertyName("sort_by")]
        public FileSort SortBy { get; set; }
        
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("start_from")]
        public int? StartFrom { get; set; }
    }
}