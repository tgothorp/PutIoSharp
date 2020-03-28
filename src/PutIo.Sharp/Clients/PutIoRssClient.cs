using PutIo.Sharp.Models.Rss;
using PutIo.Sharp.Models.Rss.Requests;
using PutIo.Sharp.Models.Rss.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PutIo.Sharp.Clients
{
    public class PutIoRssClient
    {
        private readonly PutIoApiClient _apiClient;

        public PutIoRssClient(PutIoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Lists all RSS feeds for the user
        /// </summary>
        public async Task<List<Feed>> ListFeeds()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListFeedsResponse>("rss/list");
            return response.Feeds;
        }

        /// <summary>
        /// List details of a single RSS feed
        /// </summary>
        public async Task<Feed> GetFeed(int feedId) => await GetFeed((long)feedId);

        /// <summary>
        /// List details of a single RSS feed
        /// </summary>
        public async Task<Feed> GetFeed(long feedId)
        {
            var result = await _apiClient.ExecuteGetWithResponseAsync<GetFeedResponse>($"rss/{feedId}");
            return result.Feed;
        }

        /// <summary>
        /// Updates an RSS feed with the given parameters
        /// </summary>
        public async Task<Feed> UpdateFeed(UpdateFeedRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<UpdateFeedResponse>($"rss/{request.Id}", request);
            return response.Feed;
        }

        /// <summary>
        /// Creates an RSS feed with the given parameters. The created feed object is returned.
        /// </summary>
        public async Task<Feed> CreateFeed(CreateFeedRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<CreateFeedResponse>($"rss/create", request);
            return response.Feed;
        }


        /// <summary>
        /// Pauses the RSS feed, so that it is not polled for new items anymore.
        /// </summary>
        public async Task PauseFeed(int feedId) => await PauseFeed((long)feedId);

        /// <summary>
        /// Pauses the RSS feed, so that it is not polled for new items anymore.
        /// </summary>
        public async Task PauseFeed(long feedId)
        {
            await _apiClient.ExecutePostAsync($"rss/{feedId}/pause");
        }


        /// <summary>
        /// Resumes the RSS feed, so that it starts being polled for new items again.
        /// </summary>
        public async Task ResumeFeed(int feedId) => await ResumeFeed((long)feedId);

        /// <summary>
        /// Resumes the RSS feed, so that it starts being polled for new items again.
        /// </summary>
        public async Task ResumeFeed(long feedId)
        {
            await _apiClient.ExecutePostAsync($"rss/{feedId}/resume");
        }


        /// <summary>
        /// Delete RSS feed
        /// </summary>
        public async Task DeleteFeed(int feedId) => await DeleteFeed((long)feedId);

        /// <summary>
        /// Delete RSS feed
        /// </summary>
        public async Task DeleteFeed(long feedId)
        {
            await _apiClient.ExecutePostAsync($"rss/{feedId}/resume");
        }
    }
}
