using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class ListFilesRequest : PutIoGetRequest
    {
        /// <summary>
        /// List files under a folder. If not specified, files at root folder will be listed. Listing is not recursive.
        /// However, if you pass "-1", all files of the user will be returned. If you pass "-1", make sure that you also
        /// specify per_page param to make use of cursor.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Number of files to be returned in response. If not specified cursor will always be null and no more than
        /// 1000 items will be returned.
        /// </summary>
        public int? FilePerPage { get; set; }

        /// <summary>
        /// Sort order of files in response. If not specified, the value saved in user settings will be used
        /// </summary>
        public FileSort? SortBy { get; set; }

        /// <summary>
        /// Filter files by content type, this should be a valid MIME type, for example; 'application/pdf'
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Filter by provided file types
        /// </summary>
        public IEnumerable<FileType> FileTypes { get; set; }

        /// <summary>
        /// Include stream url in returned files 
        /// </summary>
        public bool IncludeStreamUrl { get; set; }

        /// <summary>
        /// Include stream url in returned parent object
        /// </summary>
        public bool IncludeStreamUrlForParent { get; set; }
        
        /// <summary>
        /// Include MP4 stream url in returned files
        /// </summary>
        public bool IncludeMp4StreamUrl { get; set; }

        /// <summary>
        /// Include MP4 stream url in returned parent object
        /// </summary>
        public bool IncludeMp4StreamUrlForParent { get; set; }

        /// <summary>
        /// Folders such as "Your friends files" at root and folders in it are hidden by default if they are empty.
        /// If you want to include them in response then set this property to 'true'
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Include mp4_size and need_convert fileds in response.
        /// </summary>
        public bool Mp4Status { get; set; }

        internal override string BuildQueryString()
        {
            var builder = new StringBuilder();

            builder.Append(ParentId == null ? "parent_id=-1" : $"parent_id={ParentId}");

            if (FilePerPage != null)
                builder.Append($"&per_page={FilePerPage}");

            if (SortBy != null)
                switch (SortBy)
                {
                    case FileSort.NameAscending:
                        builder.Append("&sort_by=NAME_ASC");
                        break;
                    case FileSort.NameDescending:
                        builder.Append("&sort_by=NAME_DESC");
                        break;
                    case FileSort.SizeAscending:
                        builder.Append("&sort_by=SIZE_ASC");
                        break;
                    case FileSort.SizeDescending:
                        builder.Append("&sort_by=SIZE_DESC");
                        break;
                    case FileSort.DateCreatedAscending:
                        builder.Append("&sort_by=DATE_ASC");
                        break;
                    case FileSort.DateCreatedDescending:
                        builder.Append("&sort_by=DATE_DESC");
                        break;
                    case FileSort.DateModifiedAscending:
                        builder.Append("&sort_by=MODIFIED_ASC");
                        break;
                    case FileSort.DateModifiedDescending:
                        builder.Append("&sort_by=MODIFIED_DESC");
                        break;
                }

            if (ContentType != null)
                builder.Append($"&content_type={FilePerPage}");

            if (FileTypes != null && FileTypes.Any())
                builder.Append($"&file_type={string.Join(",", FileTypes.Select(x => x.ToString().ToUpper()))}");

            if (IncludeStreamUrl)
                builder.Append($"&stream_url=true");

            if (IncludeStreamUrlForParent)
                builder.Append($"&stream_url_parent=true");

            if (IncludeMp4StreamUrl)
                builder.Append($"&mp4_stream_url=true");

            if (IncludeMp4StreamUrlForParent)
                builder.Append($"&mp4_stream_url_parent=true");

            if (Hidden)
                builder.Append($"&hidden=true");

            if (Mp4Status)
                builder.Append($"&mp4_status=true");

            return builder.ToString();
        }
        
    }
}