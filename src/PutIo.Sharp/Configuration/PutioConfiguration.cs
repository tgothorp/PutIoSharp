using System.Net.Http;

namespace PutIo.Sharp.Configuration
{
    public class PutioConfiguration
    {
        public PutioConfiguration() { }
        
        public PutioConfiguration(string token)
        {
            Token = token;
        }

        public PutioConfiguration(string baseUrl, string baseUploadUrl, string token) : this(token)
        {
            BaseUrl = baseUrl;
            BaseUploadUrl = baseUploadUrl;
        }

        /// <summary>
        /// Your api token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The base Put.io api url
        /// </summary>
        public string BaseUrl { get; set; } = "https://api.put.io/v2/";
        
        /// <summary>
        /// The base Put.io api url used specifically for file uploads
        /// </summary>
        public string BaseUploadUrl { get; set; } = "https://upload.put.io/v2/";

        /// <summary>
        /// If you want to provide your own HttpClient for the api to use, set it here
        /// </summary>
        public HttpClient ApiHttpClient { get; set; }
        
        /// <summary>
        /// If you want to provide your own HttpClient for the upload api to use, set it here
        /// </summary>
        public HttpClient UploadHttpClient { get; set; }
    }
}