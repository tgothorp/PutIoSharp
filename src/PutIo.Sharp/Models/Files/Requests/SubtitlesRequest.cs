using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class SubtitlesRequest
    {
        public SubtitlesRequest(long fileId)
        {
            FileId = fileId;
        }

        /// <summary>
        /// Id of the file to download the subtitles for
        /// </summary>
        public long FileId { get; set; }
    }
}