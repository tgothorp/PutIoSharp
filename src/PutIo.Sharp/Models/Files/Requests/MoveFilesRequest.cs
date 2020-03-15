using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class MoveFilesRequest : PutIoPostRequest
    {
        public MoveFilesRequest(long parentId, params long[] fileIds)
        {
            ParentId = parentId;
            FileIds = fileIds.ToList();
        }

        public MoveFilesRequest(long parentId, List<long> fileIds)
        {
            ParentId = parentId;
            FileIds = fileIds;
        }
        
        /// <summary>
        /// The id of the destination folder
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// Ids of the files to be moved
        /// </summary>
        [JsonPropertyName("file_ids")]
        public List<long> FileIds { get; set; }
        
        internal override HttpContent GenerateRequestBody()
        {
            return new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");
        }
    }
}