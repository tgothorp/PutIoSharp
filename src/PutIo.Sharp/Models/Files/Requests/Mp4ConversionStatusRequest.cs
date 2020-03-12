using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class Mp4ConversionStatusRequest
    {
        public Mp4ConversionStatusRequest(long fileId)
        {
            FileId = fileId;
        }
        
        /// <summary>
        /// The id of the file to get MP4 conversion status of
        /// </summary>
        public long FileId { get; set; }
    }
}