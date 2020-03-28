using PutIo.Sharp.Models.Events;
using PutIo.Sharp.Models.Events.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PutIo.Sharp.Clients
{
    public class PutIoEventClient
    {
        private readonly PutIoApiClient _apiClient;

        public PutIoEventClient(PutIoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// List events
        /// </summary>
        public async Task<List<Event>> ListEvents()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListEventsResponse>("events/list");
            return response.Events;
        }

        /// <summary>
        /// Clear events
        /// </summary>
        public async Task DeleteEvents()
        {
            await _apiClient.ExecutePostAsync("events/delete");
        }
    }
}
