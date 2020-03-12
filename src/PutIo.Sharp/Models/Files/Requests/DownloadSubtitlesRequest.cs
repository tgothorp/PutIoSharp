using System;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class DownloadSubtitlesRequest : PutIoGetRequest
    {
        public DownloadSubtitlesRequest(long fileId, string key, SubtitleFormat subtitleFormat = SubtitleFormat.SRT)
        {
            FileId = fileId;
            Key = key;
            SubtitleFormat = subtitleFormat;
        }
        
        public long FileId { get; set; }
        public string Key { get; set; }
        public SubtitleFormat SubtitleFormat { get; set; }

        internal override string BuildQueryString()
        {
            switch (SubtitleFormat)
            {
                case SubtitleFormat.SRT:
                    return $"format=srt";
                case SubtitleFormat.WEBVTT:
                    return $"format=webvtt";
                default:
                    throw new ArgumentException();
            }
        }
    }
}