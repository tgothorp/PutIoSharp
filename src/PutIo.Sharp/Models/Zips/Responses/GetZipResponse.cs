using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Zips.Responses
{
    public class GetZipResponse
    {
        [JsonPropertyName("missing_files")]
        public List<MissingFile> MissingFiles { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("zip_status")]
        public string ZipStatus { get; set; }
    }
}