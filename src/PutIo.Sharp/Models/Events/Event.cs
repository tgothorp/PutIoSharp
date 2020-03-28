using System;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Events
{
    public class Event
    {
        // TODO: Once all possible events have been identified this should be split into different
        // classes based upon the event type

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("file_id")]
        public long? FileId { get; set; }

        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("file_size")]
        public long? FileSize { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("transfer_name")]
        public string TransferName { get; set; }

        [JsonPropertyName("transfer_size")]
        public long? TransferSize { get; set; }

        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        [JsonPropertyName("zip_size")]
        public long? ZipSize { get; set; }

        [JsonPropertyName("zip_id")]
        public long? ZipId { get; set; }
    }
}
