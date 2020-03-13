using System.IO;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class UploadFileRequest
    {
        /// <summary>
        /// Uploads a file to put.io
        /// </summary>
        /// <param name="fileStream">file to upload</param>
        /// <param name="fileName">What the name of the file should be when uploaded</param>
        /// <param name="parentId">The folder the file should be uploaded to, leaving this as null will upload it to the root directory</param>
        public UploadFileRequest(byte[] fileContent, string fileName, long? parentId = null)
        {
            File = fileContent;
            FileName = fileName;
            ParentId = parentId;
        }

        internal string FileName { get; set; }

        internal byte[] File { get; set; }

        internal long? ParentId { get; set; }
    }
}