using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shares.Response
{
    internal class SharedWithResponse
    {
        [JsonPropertyName("shared-with")]
        public List<SharedWith> SharedWith { get; set; }
    }
}