using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    internal class Mp4ConversionStatusResponse
    {
        [JsonPropertyName("mp4")]
        public Mp4 Mp4 { get; set; }
    }
}