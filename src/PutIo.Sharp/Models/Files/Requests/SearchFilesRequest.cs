using System;
using System.Net;
using System.Text;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class SearchFilesRequest : PutIoGetRequest
    {
        public SearchFilesRequest(string query)
        {
            Query = query;
        }

        public SearchFilesRequest(string query, int resultsPerPage) : this(query)
        {
            ResultsPerPage = resultsPerPage;
        }
        
        /// <summary>
        /// Your search query
        /// </summary>
        public string Query { get; set; }
        
        /// <summary>
        /// Number of results to return per page
        /// </summary>
        public int? ResultsPerPage { get; set; }

        internal override string BuildQueryString()
        {
            var builder = new StringBuilder();
            
            if (Query is null)
                throw new ArgumentException("You must provide a query to search files by");
            
            builder.Append($"query={WebUtility.UrlEncode(Query)}");

            builder.Append(ResultsPerPage == null ? "&per_page=1000" : $"&per_page={ResultsPerPage}");

            return builder.ToString();
        }
    }
}