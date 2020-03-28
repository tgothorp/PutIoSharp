using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Events.Response
{
    internal class ListEventsResponse
    {
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }
    }
}
