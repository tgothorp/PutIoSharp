using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PutIo.Sharp.Models.Rss.Requests
{
    public class CreateFeedRequest : PutIoPostRequest
    {
        /// <summary>
        /// Title of the RSS feed as will appear on the site
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL of the RSS feed to be watched
        /// </summary>
        public string RssSourceUrl { get; set; }

        /// <summary>
        /// The file id of the folder to place the RSS feed files in
        /// </summary>
        public long? ParentDirectoryId { get; set; }

        /// <summary>
        /// Should old files be deleted when space is low
        /// </summary>
        public bool? DeleteOldFiles { get; set; }

        /// <summary>
        /// Should the current items in the feed, at creation time, be ignored
        /// </summary>
        public bool? DontProcessWholeFeed { get; set; }

        /// <summary>
        /// Only items with titles that contain any of these words will be transferred
        /// </summary>
        public IEnumerable<string> Keywords { get; set; }

        /// <summary>
        /// No items with titles that contain any of these words will be transferred
        /// </summary>
        public IEnumerable<string> UnwantedKeywords { get; set; }

        /// <summary>
        /// Should the RSS feed be paused
        /// </summary>
        public bool? Paused { get; set; }

        internal override HttpContent GenerateRequestBody()
        {
            var form = new MultipartFormDataContent();

            if (Title != null)
                form.Add(new StringContent(Title), "title");

            if (RssSourceUrl != null)
                form.Add(new StringContent(RssSourceUrl), "rss_source_url");

            if (ParentDirectoryId != null)
                form.Add(new StringContent(ParentDirectoryId.Value.ToString()), "parent_dir_id");

            if (DeleteOldFiles != null)
                form.Add(new StringContent(DeleteOldFiles.ToString()), "delete_old_files");

            if (DontProcessWholeFeed != null)
                form.Add(new StringContent(DontProcessWholeFeed.ToString()), "dont_process_whole_feed");

            if (Keywords.Any())
                form.Add(new StringContent(string.Join(",", Keywords)), "keyword");

            if (UnwantedKeywords.Any())
                form.Add(new StringContent(string.Join(",", UnwantedKeywords)), "unwanted_keywords");

            if (Paused != null)
                form.Add(new StringContent(Paused.ToString()), "paused");

            return form;
        }
    }
}
