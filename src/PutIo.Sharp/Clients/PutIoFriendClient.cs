using System.Collections.Generic;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Friends;
using PutIo.Sharp.Models.Friends.Responses;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Clients
{
    public class PutIoFriendClient
    {
        private readonly PutioApiClient _apiClient;

        public PutIoFriendClient(PutioApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// List friends
        /// </summary>
        public async Task<List<Friend>> ListFriends()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListFriendsResponse>("friends/list");
            return response.Friends;
        }

        /// <summary>
        /// List pending friend requests
        /// </summary>
        public async Task<List<Friend>> ListPendingFriendRequests()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListFriendsResponse>("friends/waiting-requests");
            return response.Friends;
        }

        /// <summary>
        /// Send friend request
        /// </summary>
        public async Task SendFriendRequest(Friend friend) => await SendFriendRequest(friend.Name);
        
        /// <summary>
        /// Send friend request
        /// </summary>
        public async Task SendFriendRequest(string username)
        {
            await _apiClient.ExecutePostAsync($"friends/{username}/request");
        }
        
        /// <summary>
        /// Approve a friend request
        /// </summary>
        public async Task ApproveFriendRequest(Friend friend) => await ApproveFriendRequest(friend.Name);
        
        /// <summary>
        /// Approve a friend request
        /// </summary>
        public async Task ApproveFriendRequest(string username)
        {
            await _apiClient.ExecutePostAsync($"friends/{username}/approve");
        }
        
        /// <summary>
        /// Deny a friend request
        /// </summary>
        public async Task DenyFriendRequest(Friend friend) => await DenyFriendRequest(friend.Name);
        
        /// <summary>
        /// Deny a friend request
        /// </summary>
        public async Task DenyFriendRequest(string username)
        {
            await _apiClient.ExecutePostAsync($"friends/{username}/deny");
        }
        
        /// <summary>
        /// Remove friend, Files shared with all friends will be automatically removed from old friend’s directory.
        /// </summary>
        public async Task Unfriend(Friend friend) => await Unfriend(friend.Name);
        
        /// <summary>
        /// Remove friend, Files shared with all friends will be automatically removed from old friend’s directory.
        /// </summary>
        public async Task Unfriend(string username)
        {
            await _apiClient.ExecutePostAsync($"friends/{username}/unfriend");
        }
    }
}