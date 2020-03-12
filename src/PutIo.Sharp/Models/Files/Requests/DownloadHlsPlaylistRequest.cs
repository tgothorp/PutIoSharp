namespace PutIo.Sharp.Models.Files.Requests
{
    public class DownloadHlsPlaylistRequest : PutIoGetRequest
    {
        public DownloadHlsPlaylistRequest(long fileId, string subtitleKey)
        {
            FileId = fileId;
            SubtitleKey = subtitleKey;
        }
        
        public long FileId { get; set; }

        public string SubtitleKey { get; set; }
        
        internal override string BuildQueryString()
        {
            return $"subtitle_key={SubtitleKey}";
        }
    }
}