using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    public class ListFilesResponse
    {
        [JsonPropertyName("parent")]
        public File Parent { get; set; }
        
        [JsonPropertyName("files")]
        public List<File> Files { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}