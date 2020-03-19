using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Files;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Models.Shared;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Files
{
    public class FileTests : BaseTest
    {
        [Fact]
        public async Task ListFiles()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/get_list_files.json"));

            var listFilesResponse = await PutioApiClient.Files.ListFiles(new ListFilesRequest());
            listFilesResponse.ShouldNotBeNull();
            listFilesResponse.Status.ShouldBe("OK");
            listFilesResponse.Total.ShouldBe(1);
            listFilesResponse.Files.Count().ShouldBe(1);

            var file = listFilesResponse.Files.First();
            file.ShouldNotBeNull();
            
            file.ContentType.ShouldBe("video/x-matroska");
            file.CRC32Checksum.ShouldBe("ed7a4f07");
            
            file.CreatedAt.Year.ShouldBe(2020);
            file.CreatedAt.Month.ShouldBe(03);
            file.CreatedAt.Day.ShouldBe(06);
            file.CreatedAt.Hour.ShouldBe(18);
            file.CreatedAt.Minute.ShouldBe(50);
            file.CreatedAt.Second.ShouldBe(03);
            
            file.Extension.ShouldBe("mkv");
            file.FileType.ShouldBe(FileType.Video);
            
            file.FirstAccessedAt.ShouldNotBeNull();
            file.FirstAccessedAt.Value.Year.ShouldBe(2020);
            file.FirstAccessedAt.Value.Month.ShouldBe(03);
            file.FirstAccessedAt.Value.Day.ShouldBe(06);
            file.FirstAccessedAt.Value.Hour.ShouldBe(18);
            file.FirstAccessedAt.Value.Minute.ShouldBe(50);
            file.FirstAccessedAt.Value.Second.ShouldBe(13);
            
            file.FolderType.ShouldBe("REGULAR");
            file.Icon.ShouldBe("https://example.com");
            file.Id.ShouldBe(710522366);
            file.IsHidden.ShouldBeFalse();
            file.IsMp4Available.ShouldBeTrue();
            file.IsShared.ShouldBeFalse();
            file.Mp4Size.ShouldBe(610555094);
            file.ConversionNeeded.ShouldBeFalse();
            file.Name.ShouldBe("Star.Wars.The.Clone.Wars.S07E03.mkv");
            file.OpenSubtitlesHash.ShouldBe("93e4aa412345b47f");
            file.ParentId.ShouldBe(710522365);
            file.Screenshot.ShouldBe("https://example.com");
            file.Size.ShouldBe(618709468);
            file.StartFrom.ShouldBe(0);

            file.UpdatedAt.Year.ShouldBe(2020);
            file.UpdatedAt.Month.ShouldBe(03);
            file.UpdatedAt.Day.ShouldBe(06);
            file.UpdatedAt.Hour.ShouldBe(18);
            file.UpdatedAt.Minute.ShouldBe(50);
            file.UpdatedAt.Second.ShouldBe(03);
        }

        [Fact]
        public async Task SearchFiles()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/get_search_files.json"));

            var searchFilesResponse = await PutioApiClient.Files.SearchFiles(new SearchFilesRequest("Star Wars"));
            searchFilesResponse.ShouldNotBeNull();
            searchFilesResponse.Status.ShouldBe("OK");
            searchFilesResponse.Cursor.ShouldBeNull();
            searchFilesResponse.Total.ShouldBe(1);

            var file = searchFilesResponse.Files.SingleOrDefault();
            file.ShouldNotBeNull();
            
            file.ContentType.ShouldBe("video/x-matroska");
            file.CRC32Checksum.ShouldBe("0356056d");
            
            file.CreatedAt.Year.ShouldBe(2019);
            file.CreatedAt.Month.ShouldBe(12);
            file.CreatedAt.Day.ShouldBe(18);
            file.CreatedAt.Hour.ShouldBe(18);
            file.CreatedAt.Minute.ShouldBe(51);
            file.CreatedAt.Second.ShouldBe(45);
            
            file.Extension.ShouldBe("mkv");
            file.FileType.ShouldBe(FileType.Video);
            
            file.FirstAccessedAt.ShouldNotBeNull();
            file.FirstAccessedAt.Value.Year.ShouldBe(2019);
            file.FirstAccessedAt.Value.Month.ShouldBe(12);
            file.FirstAccessedAt.Value.Day.ShouldBe(18);
            file.FirstAccessedAt.Value.Hour.ShouldBe(18);
            file.FirstAccessedAt.Value.Minute.ShouldBe(52);
            file.FirstAccessedAt.Value.Second.ShouldBe(09);
            
            file.FolderType.ShouldBe("REGULAR");
            file.Icon.ShouldBe("https://example.com");
            file.Id.ShouldBe(686077953);
            file.IsHidden.ShouldBeFalse();
            file.IsMp4Available.ShouldBeTrue();
            file.IsShared.ShouldBeFalse();
            file.Name.ShouldBe("The.Mandalorian.S01E07.mkv");
            file.OpenSubtitlesHash.ShouldBe("26a6b68a24dd31aa");
            file.ParentId.ShouldBe(686077952);
            file.Screenshot.ShouldBe("https://example.com");
            file.SenderName.ShouldBe("exampleUser");
            file.Size.ShouldBe(1438362013);
            file.StartFrom.ShouldBe(0);

            file.UpdatedAt.Year.ShouldBe(2019);
            file.UpdatedAt.Month.ShouldBe(12);
            file.UpdatedAt.Day.ShouldBe(18);
            file.UpdatedAt.Hour.ShouldBe(18);
            file.UpdatedAt.Minute.ShouldBe(51);
            file.UpdatedAt.Second.ShouldBe(45);
        }

        [Fact]
        public async Task CreateFolder()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/post_create_folder.json"));
            
            var createFolderResponse = await PutioApiClient.Files.CreateFolder(new CreateFolderRequest("ExampleFolder", 0));
            createFolderResponse.ShouldNotBeNull();
            createFolderResponse.ShouldNotBeNull();
            createFolderResponse.ContentType.ShouldBe("application/x-directory");
            createFolderResponse.CRC32Checksum.ShouldBeNull();
            
            createFolderResponse.CreatedAt.Year.ShouldBe(2020);
            createFolderResponse.CreatedAt.Month.ShouldBe(03);
            createFolderResponse.CreatedAt.Day.ShouldBe(13);
            createFolderResponse.CreatedAt.Hour.ShouldBe(09);
            createFolderResponse.CreatedAt.Minute.ShouldBe(17);
            createFolderResponse.CreatedAt.Second.ShouldBe(01);
            
            createFolderResponse.Extension.ShouldBeNull();
            createFolderResponse.FileType.ShouldBe(FileType.Folder);
            createFolderResponse.FirstAccessedAt.ShouldBeNull();
            createFolderResponse.FolderType.ShouldBe("REGULAR");
            createFolderResponse.Icon.ShouldBe("https://api.put.io/images/file_types/folder.png");
            createFolderResponse.Id.ShouldBe(711970231);
            createFolderResponse.IsHidden.ShouldBeFalse();
            createFolderResponse.IsMp4Available.ShouldBeFalse();
            createFolderResponse.IsShared.ShouldBeFalse();
            createFolderResponse.Name.ShouldBe("ExampleFolder");
            createFolderResponse.OpenSubtitlesHash.ShouldBeNull();
            createFolderResponse.ParentId.ShouldBe(0);
            createFolderResponse.Screenshot.ShouldBeNull();
            createFolderResponse.Size.ShouldBe(0);
            createFolderResponse.SortBy.ShouldBe(FileSort.DateCreatedDescending);
            
            createFolderResponse.UpdatedAt.Year.ShouldBe(2020);
            createFolderResponse.UpdatedAt.Month.ShouldBe(03);
            createFolderResponse.UpdatedAt.Day.ShouldBe(13);
            createFolderResponse.UpdatedAt.Hour.ShouldBe(09);
            createFolderResponse.UpdatedAt.Minute.ShouldBe(17);
            createFolderResponse.UpdatedAt.Second.ShouldBe(01);
            
        }

        [Fact]
        public async Task Mp4ConversionStatus()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/get_mp4_conversion_status.json"));

            var mp4ConversionStatus = await PutioApiClient.Files.Mp4ConversionStatus(new Mp4ConversionStatusRequest(12345));
            mp4ConversionStatus.ShouldNotBeNull();
            mp4ConversionStatus.Size.ShouldBe(86544545);
            mp4ConversionStatus.PercentageComplete.ShouldBe(56);
            mp4ConversionStatus.Status.ShouldBe("IN_QUEUE");
        }

        [Fact]
        public async Task ListSubtitles()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/get_list_subtitles.json"));

            var listSubtitles = await PutioApiClient.Files.ListSubtitles(new SubtitlesRequest(12345));

            listSubtitles.ShouldNotBeNull();
            listSubtitles.Count().ShouldBe(2);
            
            var englishSubs = listSubtitles.SingleOrDefault(x => x.Language == "English");
            englishSubs.ShouldNotBeNull();
            englishSubs.Key.ShouldBe("V7mVadfvq34erarjy9tqj0435hgare");
            englishSubs.Name.ShouldBe("MyEnglishSubs.srt");
            englishSubs.Source.ShouldBe("folder");
            
            var koreanSubs = listSubtitles.SingleOrDefault(x => x.Language == "Korean");
            koreanSubs.ShouldNotBeNull();
            koreanSubs.Key.ShouldBe("gggfVAthkFJJKdAd75VVssfdfdMi8As3");
            koreanSubs.Name.ShouldBe("MyKoreanSubs.srt");
            koreanSubs.Source.ShouldBe("folder");
        }

        [Fact]
        public async Task ListExtractions()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Files/Data/get_list_extractions.json"));

            var listExtractions = await PutioApiClient.Files.ListExtractions();
            listExtractions.ShouldNotBeNull();
            listExtractions.Count().ShouldBe(1);

            var extraction = listExtractions.SingleOrDefault();
            extraction.ShouldNotBeNull();
            extraction.Id.ShouldBe(24336726735);
            extraction.Name.ShouldBe("The.Clone.Wars.TV.Season.7.zip");
            extraction.Status.ShouldBe("IN_QUEUE");
            extraction.Message.ShouldBe("Added to queue");
            extraction.Parts.ShouldBe(1);
            extraction.Files.ShouldNotBeNull();
            extraction.Files.Count().ShouldBe(1);
            
            var file = extraction.Files.SingleOrDefault();
            file.ShouldNotBeNull();
            
            file.ContentType.ShouldBe("video/x-matroska");
            file.CRC32Checksum.ShouldBe("ed7a4f07");
            
            file.CreatedAt.Year.ShouldBe(2020);
            file.CreatedAt.Month.ShouldBe(03);
            file.CreatedAt.Day.ShouldBe(06);
            file.CreatedAt.Hour.ShouldBe(18);
            file.CreatedAt.Minute.ShouldBe(50);
            file.CreatedAt.Second.ShouldBe(03);
            
            file.Extension.ShouldBe("mkv");
            file.FileType.ShouldBe(FileType.Video);
            
            file.FirstAccessedAt.ShouldNotBeNull();
            file.FirstAccessedAt.Value.Year.ShouldBe(2020);
            file.FirstAccessedAt.Value.Month.ShouldBe(03);
            file.FirstAccessedAt.Value.Day.ShouldBe(06);
            file.FirstAccessedAt.Value.Hour.ShouldBe(18);
            file.FirstAccessedAt.Value.Minute.ShouldBe(50);
            file.FirstAccessedAt.Value.Second.ShouldBe(13);
            
            file.FolderType.ShouldBe("REGULAR");
            file.Icon.ShouldBe("https://example.com");
            file.Id.ShouldBe(710522366);
            file.IsHidden.ShouldBeFalse();
            file.IsMp4Available.ShouldBeTrue();
            file.IsShared.ShouldBeFalse();
            file.Mp4Size.ShouldBe(610555094);
            file.ConversionNeeded.ShouldBeFalse();
            file.Name.ShouldBe("Star.Wars.The.Clone.Wars.S07E03.mkv");
            file.OpenSubtitlesHash.ShouldBe("93e4aa412345b47f");
            file.ParentId.ShouldBe(710522365);
            file.Screenshot.ShouldBe("https://example.com");
            file.Size.ShouldBe(618709468);
            file.StartFrom.ShouldBe(0);

            file.UpdatedAt.Year.ShouldBe(2020);
            file.UpdatedAt.Month.ShouldBe(03);
            file.UpdatedAt.Day.ShouldBe(06);
            file.UpdatedAt.Hour.ShouldBe(18);
            file.UpdatedAt.Minute.ShouldBe(50);
            file.UpdatedAt.Second.ShouldBe(03);
        }
    }
}