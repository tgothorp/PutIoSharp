using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Shares
{
    public class ShareTests : BaseTest
    {
        [Fact]
        public async Task ListShares()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ShareTests)).Location)}/Shares/Data/get_list_shares.json"));

            var sharedFiles = await PutioApiClient.Shares.ListSharedFiles();
            sharedFiles.Count.ShouldBe(2);

            var firstShare = sharedFiles.SingleOrDefault(x => x.Id == 1546);
            firstShare.ShouldNotBeNull();
            firstShare.Name.ShouldBe("FirstShare");
            firstShare.Size.ShouldBe(8768678);
            
            var secondShare = sharedFiles.SingleOrDefault(x => x.Id == 546587);
            secondShare.ShouldNotBeNull();
            secondShare.Name.ShouldBe("SecondShare");
            secondShare.Size.ShouldBe(3242352);
        }

        [Fact]
        public async Task SharedWith()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ShareTests)).Location)}/Shares/Data/get_shared_with.json"));

            var sharedWith = await PutioApiClient.Shares.SharedWith(123);
            sharedWith.Count().ShouldBe(2);

            var firstSharedWith = sharedWith.SingleOrDefault(x => x.ShareId == 3913572317);
            firstSharedWith.ShouldNotBeNull();
            firstSharedWith.Username.ShouldBe("FirstUser");
            firstSharedWith.AvatarUrl.ShouldBe("/avatars/firstuser.png");
            
            var secondSharedWith = sharedWith.SingleOrDefault(x => x.ShareId == 3913572318);
            secondSharedWith.ShouldNotBeNull();
            secondSharedWith.Username.ShouldBe("SecondUser");
            secondSharedWith.AvatarUrl.ShouldBe("/avatars/seconduser.png");
        }
    }
}