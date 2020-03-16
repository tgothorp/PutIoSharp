using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Zips.Responses
{
    public class CreateZipResponse
    {
        [JsonPropertyName("zip_id")]
        public long ZipId { get; set; }
    }
}