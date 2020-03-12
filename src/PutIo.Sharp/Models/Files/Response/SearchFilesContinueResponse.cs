using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    public class SearchFilesContinueResponse
    {
        [JsonPropertyName("files")]
        public List<File> Files { get; set; }

        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}