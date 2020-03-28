using Shouldly;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Events
{
    public class EventTests : BaseTest
    {
        [Fact]
        public async Task ListEvents()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(EventTests)).Location)}/Events/Data/get_list_events.json"));

            var events = await PutioApiClient.Events.ListEvents();
            events.Count.ShouldBe(3);

            var transferEvent = events[0];
            transferEvent.Id.ShouldBe(98886715);
            transferEvent.CreatedAt.ShouldNotBeNull();
            transferEvent.FileId.ShouldBe(712019933);
            transferEvent.Source.ShouldBe("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            transferEvent.TransferName.ShouldBe("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            transferEvent.TransferSize.ShouldBe(86230061);
            transferEvent.Type.ShouldBe("transfer_completed");
            transferEvent.UserId.ShouldBe(11223344);

            var uploadEvent = events[1];
            uploadEvent.Id.ShouldBe(98880821);
            uploadEvent.CreatedAt.ShouldNotBeNull();
            uploadEvent.FileId.ShouldBe(711981933);
            uploadEvent.FileName.ShouldBe("SSG9F61GYH");
            uploadEvent.Type.ShouldBe("upload");
            uploadEvent.UserId.ShouldBe(11223344);

            var zipEvent = events[2];
            zipEvent.Id.ShouldBe(99075924);
            zipEvent.CreatedAt.ShouldNotBeNull();
            zipEvent.Type.ShouldBe("zip_created");
            zipEvent.UserId.ShouldBe(11223344);
            zipEvent.ZipId.ShouldBe(24010881);
            zipEvent.ZipSize.ShouldBe(2826293);
        }
    }
}
