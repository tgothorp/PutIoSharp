using System.Collections.Generic;
using System.Threading.Tasks;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Files;
using PutIo.Sharp.Models.Files.Requests;
using Xunit;

namespace PutIo.Sharp.Tests.Files
{
    public class FileTests : BaseTest
    {
        [Fact]
        public async Task ListFiles_NoParameters()
        {
            var request = new ListFilesRequest
            {
                Hidden = true,
                FileTypes = new List<FileType>
                {
                    FileType.Video,
                },
                Mp4Status = true,
                ParentId = -1,
                SortBy = FileSort.NameAscending,
                FilePerPage = 1
            };

            //await PutioApiClient.ListFiles(request);
            var config = new PutioConfiguration("VVVHGKJWNJXVEWEUOW4O");
            var client = new PutioApiClient(config);

            var result = await client.Files.SearchFiles(new SearchFilesRequest("Star Wars", 10));
            var result2 = await client.Files.SearchFilesContinue(new SearchFilesContinueRequest(result.Cursor));
            // var response = await client.ListFiles(request);
            // response.ShouldNotBeNull();
            //
            // var response2 = await client.ListFilesContinue(new ListFilesContinueRequest
            // {
            //     Cursor = response.Cursor
            // });
        }
        
    }
}