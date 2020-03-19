using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Friends
{
    public class FriendTests : BaseTest
    {
        [Fact]
        public async Task ListFriends()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FriendTests)).Location)}/Friends/Data/get_list_friends.json"));

            var friends = await PutioApiClient.Friends.ListFriends();
            friends.Count.ShouldBe(2);

            var friendOne = friends.SingleOrDefault(x => x.Id == 1);
            friendOne.ShouldNotBeNull();
            friendOne.Name.ShouldBe("MyBestFriend");
            friendOne.AvatarUrl.ShouldBe("http://www.example.com/image1.jpg");
            
            var friendTwo = friends.SingleOrDefault(x => x.Id == 2); 
            friendTwo.ShouldNotBeNull();
            friendTwo.Name.ShouldBe("MySecondBestFriend");
            friendTwo.AvatarUrl.ShouldBe("http://www.example.com/image2.jpg");
        }

        [Fact]
        public async Task ListFriendRequests()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FriendTests)).Location)}/Friends/Data/get_list_friend_requests.json"));

            var friendRequests = await PutioApiClient.Friends.ListPendingFriendRequests();
            friendRequests.Count.ShouldBe(2);
            
            var friendOne = friendRequests.SingleOrDefault(x => x.Id == 3);
            friendOne.ShouldNotBeNull();
            friendOne.Name.ShouldBe("APendingFriend");
            friendOne.AvatarUrl.ShouldBe("http://www.example.com/image3.jpg");
            
            var friendTwo = friendRequests.SingleOrDefault(x => x.Id == 4); 
            friendTwo.ShouldNotBeNull();
            friendTwo.Name.ShouldBe("ASecondPendingFriend");
            friendTwo.AvatarUrl.ShouldBe("http://www.example.com/image4.jpg");
        }
    }
}