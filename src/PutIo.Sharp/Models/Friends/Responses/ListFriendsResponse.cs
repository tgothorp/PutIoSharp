using System.Collections.Generic;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Friends.Responses
{
    public class ListFriendsResponse
    {
        [JsonPropertyName("friends")]
        public List<Friend> Friends { get; set; }
    }
}