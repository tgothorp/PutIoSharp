using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Response
{
    internal class ListExtractionsResponse
    {
        [JsonPropertyName("extractions")]
        public List<Extraction> Extractions { get; set; }
    }
}