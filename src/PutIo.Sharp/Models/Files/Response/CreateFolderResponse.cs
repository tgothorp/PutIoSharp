using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    internal class CreateFolderResponse
    {
        [JsonPropertyName("file")]
        public File NewFolder { get; set; }
    }
}