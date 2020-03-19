using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shares.Response
{
    internal class ListSharedFilesResponse
    {
        [JsonPropertyName("shared")]
        public List<Share> Shared { get; set; }
    }
}