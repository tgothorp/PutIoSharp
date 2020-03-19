using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Shares.Requests
{
    public class ShareFilesRequest : PutIoPostRequest
    {
        /// <summary>
        /// Share a file with everyone
        /// </summary>
        /// <param name="fileId">Id of the file to share</param>
        public ShareFilesRequest(long fileId)
        {
            FileIds = new List<long> { fileId };
            FriendNames = new List<string> { "everyone" };
        }

        /// <summary>
        /// Share files with everyone
        /// </summary>
        /// <param name="fileIds">Ids of the files to share</param>
        public ShareFilesRequest(IEnumerable<long> fileIds)
        {
            FileIds = fileIds;
            FriendNames = new List<string> { "everyone" };
        }
        
        /// <summary>
        /// Share file(s) with one or more friends
        /// </summary>
        /// <param name="fileId">Id of the file to be shared</param>
        /// <param name="friend">Friend to share the file with</param>
        public ShareFilesRequest(long fileId, Friend friend)
        {
            FileIds = new List<long> { fileId };
            FriendNames = new List<string> { friend.Name };
        }

        /// <summary>
        /// Share file(s) with one or more friends
        /// </summary>
        /// <param name="fileId">Id of the file to be shared</param>
        /// <param name="friends">List of friends to share the file with</param>
        public ShareFilesRequest(long fileId, IEnumerable<Friend> friends)
        {
            FileIds = new List<long> { fileId };
            FriendNames = friends.Select(x => x.Name);
        }

        /// <summary>
        /// Share file(s) with one or more friends
        /// </summary>
        /// <param name="fileIds">List of files to share</param>
        /// <param name="friend">Friend to share the files with</param>
        public ShareFilesRequest(IEnumerable<long> fileIds, Friend friend)
        {
            FileIds = fileIds;
            FriendNames = new List<string> { friend.Name };
        }

        /// <summary>
        /// Share file(s) with one or more friends
        /// </summary>
        /// <param name="fileIds">List of files to share</param>
        /// <param name="friends">List of friends to share the file with</param>
        public ShareFilesRequest(IEnumerable<long> fileIds, IEnumerable<Friend> friends)
        {
            FileIds = fileIds;
            FriendNames = friends.Select(x => x.Name);
        }

        public IEnumerable<long> FileIds { get; set; }

        public IEnumerable<string> FriendNames { get; set; }
        
        internal override HttpContent GenerateRequestBody()
        {
            return new MultipartFormDataContent {
            {
                new StringContent(string.Join(",", FileIds)), "file_ids"
            },
            {
                new StringContent(string.Join(",", FriendNames)), "friends"
            }};
        }
    }
}