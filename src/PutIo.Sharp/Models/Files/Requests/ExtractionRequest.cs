﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class ExtractionRequest : PutIoPostRequest
    {
        public ExtractionRequest(params long[] fileIds)
        {
            FileIds = fileIds;
        }

        public ExtractionRequest(IEnumerable<long> fileIds, string password = null)
        {
            FileIds = fileIds;
            Password = password;
        }
        
        [JsonPropertyName("file_ids")]
        public IEnumerable<long> FileIds { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        internal override HttpContent GenerateRequestBody()
        {
            if (FileIds is null || !FileIds.Any())
                throw new ArgumentException("You must provide at least one file to extract");
            
            return new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");
        }
    }
}