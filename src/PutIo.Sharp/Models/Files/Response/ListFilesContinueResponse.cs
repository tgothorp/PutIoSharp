using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    public class ListFilesContinueResponse
    {
        [JsonPropertyName("files")]
        public List<File> Files { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}