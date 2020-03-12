using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class RenameFileRequest : PutIoPostRequest
    {
        public RenameFileRequest(string name, long fileId)
        {
            Name = name;
            FileId = fileId;
        }
        
        /// <summary>
        /// The new name of the file or folder
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The id of the file or folder to be renamed
        /// </summary>
        [JsonPropertyName("file_id")]
        public long FileId { get; set; }
        
        internal override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}