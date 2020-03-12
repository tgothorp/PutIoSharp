using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    public class CreateFolderResponse
    {
        [JsonPropertyName("file")]
        public File NewFolder { get; set; }
    }
}