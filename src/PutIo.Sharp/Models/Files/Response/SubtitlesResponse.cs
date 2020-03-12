using System.Collections.Generic;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Files.Response
{
    public class SubtitlesResponse
    {
        [JsonPropertyName("subtitles")]
        public List<Subtitle> Subtitles { get; set; }
    }
}