using System.Text.Json;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Transfers.Requests
{
    public class AddTransferRequest : PutIoPostRequest
    {
        /// <param name="url">HTTP url or magnet link</param>
        /// <param name="parentId">Where to save the files for this transfer</param>
        /// <param name="callbackUrl">Transfer’s metadata will be POSTed to this URL after the download is finished.</param>
        public AddTransferRequest(string url, long? parentId = null, string callbackUrl = null)
        {
            Url = url;
            ParentId = parentId;
            CallbackUrl = callbackUrl;
        }
        
        /// <summary>
        /// HTTP Url or Magnet link
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Where to save the files for this transfer
        /// </summary>
        [JsonPropertyName("save_parent_id")]
        public long? ParentId { get; set; }

        /// <summary>
        /// Transfer’s metadata will be POSTed to this URL after the download is finished.
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        
        internal override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}