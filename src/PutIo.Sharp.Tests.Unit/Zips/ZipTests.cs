using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Zips.Requests;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Zips
{
    public class ZipTests : BaseTest
    {

        [Fact]
        public async Task CreateZip()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ZipTests)).Location)}/Zips/Data/post_create_zip.json"));

            var zip = await PutioApiClient.Zips.CreateZip(new CreateZipRequest(123));
            zip.ShouldBe(12345);
        }

        [Fact]
        public async Task ListZips()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ZipTests)).Location)}/Zips/Data/get_list_zips.json"));

            var allZips = await PutioApiClient.Zips.ListZips();
            allZips.ShouldNotBeNull();
            allZips.ShouldNotBeNull();
            allZips.Count().ShouldBe(1);

            var zip = allZips.Single();
            zip.Id.ShouldBe(12345);
            
            zip.CreatedAt.Year.ShouldBe(2020);
            zip.CreatedAt.Month.ShouldBe(03);
            zip.CreatedAt.Day.ShouldBe(16);
            zip.CreatedAt.Hour.ShouldBe(12);
            zip.CreatedAt.Minute.ShouldBe(43);
            zip.CreatedAt.Second.ShouldBe(58);
        }
        
        [Fact]
        public async Task GetZip()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ZipTests)).Location)}/Zips/Data/get_zip.json"));

            var zip = await PutioApiClient.Zips.GetZip(12345);
            zip.ShouldNotBeNull();
            
            zip.Size.ShouldBe(2826293);
            zip.Url.ShouldBe("http://example.com");
            zip.ZipStatus.ShouldBe("DONE");
            zip.MissingFiles.ShouldNotBeNull();
            zip.MissingFiles.Count().ShouldBe(1);

            var missingFile = zip.MissingFiles.Single();
            missingFile.Id.ShouldBe(67372947);
            missingFile.Name.ShouldBe("A Missing File");
            missingFile.Missing.ShouldBeTrue();
        }
    }
}