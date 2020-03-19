using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Zips.Responses
{
    internal class ListZipResponse
    {
        [JsonPropertyName("zips")]
        public List<Zip> Zips { get; set; }
    }
}