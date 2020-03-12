using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class ListFilesContinueRequest : PutIoPostRequest
    {
        public ListFilesContinueRequest(string cursor)
        {
            Cursor = cursor;
        }

        public ListFilesContinueRequest(string cursor, int resultsPerPage) : this(cursor)
        {
            ResultsPerPage = resultsPerPage;
        }
        
        /// <summary>
        /// Cursor value from /files/list response
        /// </summary>
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

        /// <summary>
        /// Number of files to be returned in a response
        /// </summary>
        [JsonPropertyName("per_page")]
        public int? ResultsPerPage { get; set; }

        internal override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}