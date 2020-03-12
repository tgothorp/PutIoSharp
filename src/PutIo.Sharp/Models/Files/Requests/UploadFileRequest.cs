using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class UploadFileRequest : PutIoPostRequest
    {
        /// <summary>
        /// Uploads a file to put.io
        /// </summary>
        /// <param name="fileStream">file to upload</param>
        /// <param name="fileName">What the name of the file should be when uploaded</param>
        /// <param name="parentId">The folder the file should be uploaded to, leaving this as null will upload it to the root directory</param>
        public UploadFileRequest(byte[] fileContent, string fileName, long? parentId = null)
        {
            FileStream = new MemoryStream(fileContent);
            FileName = fileName;
            ParentId = parentId;
        }

        /// <summary>
        /// Uploads a file to put.io
        /// </summary>
        /// <param name="fileStream">file to upload</param>
        /// <param name="fileName">What the name of the file should be when uploaded</param>
        /// <param name="parentId">The folder the file should be uploaded to, leaving this as null will upload it to the root directory</param>
        public UploadFileRequest(Stream fileStream, string fileName, long? parentId = null)
        {
            FileStream = fileStream;
            FileName = fileName;
            ParentId = parentId;
        }

        [JsonPropertyName("filename")]
        internal string FileName { get; set; }

        [JsonIgnore]
        internal Stream FileStream { get; set; }

        [JsonPropertyName("parent_id")]
        internal long? ParentId { get; set; }

        internal override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}