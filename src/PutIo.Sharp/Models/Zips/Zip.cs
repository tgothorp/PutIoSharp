using System;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Zips
{
    public class Zip
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}