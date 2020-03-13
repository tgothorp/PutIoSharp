﻿using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class DeleteFilesRequest : PutIoPostRequest
    {
        public DeleteFilesRequest(IEnumerable<long> fileIds)
        {
            FileIds = fileIds;
        }

        public DeleteFilesRequest(params long[] fileIds)
        {
            FileIds = fileIds;
        }
        
        [JsonPropertyName("file_ids")]
        public IEnumerable<long> FileIds { get; set; }
        
        internal override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}