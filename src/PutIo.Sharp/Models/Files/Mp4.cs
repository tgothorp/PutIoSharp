using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files
{
    public class Mp4
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } // todo: Convert this to an enum when I learn what the possible options are

        [JsonPropertyName("percent_done")]
        public decimal PercentageComplete { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }
    }
}