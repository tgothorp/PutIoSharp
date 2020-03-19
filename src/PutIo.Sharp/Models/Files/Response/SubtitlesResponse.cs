using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    internal class SubtitlesResponse
    {
        [JsonPropertyName("subtitles")]
        public List<Subtitle> Subtitles { get; set; }
    }
}