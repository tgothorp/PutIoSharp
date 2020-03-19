using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Friends.Responses
{
    public class ListFriendsResponse
    {
        [JsonPropertyName("friends")]
        public List<Friend> Friends { get; set; }
    }
}