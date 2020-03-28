using System.Text;

namespace PutIo.Sharp.Models.Auth.Request
{
    public class GetCodeRequest : PutIoGetRequest
    {
        /// <summary>
        /// Get code for user to exchange for an Auth token
        /// </summary>
        /// <param name="appId">Your app id</param>
        public GetCodeRequest(string appId)
        {
            AppId = appId;
        }

        /// <summary>
        /// Get code for user to exchange for an Auth token
        /// </summary>
        /// <param name="appId">Your app id</param>
        /// <param name="clientName">The name of your application for the user to link to</param>
        public GetCodeRequest(string appId, string clientName)
        {
            AppId = appId;
            ClientName = clientName;
        }

        public string AppId { get; set; }

        public string ClientName { get; set; }

        internal override string BuildQueryString()
        {
            var builder = new StringBuilder();

            builder.Append($"app_id={AppId}");

            if (ClientName != null)
                builder.Append($"$client_name={ClientName}");

            return builder.ToString();
        }
    }
}
