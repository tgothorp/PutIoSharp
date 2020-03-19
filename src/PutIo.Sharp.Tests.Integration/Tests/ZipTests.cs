using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Models.Zips.Requests;
using PutIo.Sharp.Tests.Integration.Utils;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Integration.Tests
{
    public class ZipTests
    {
        [Fact]
        public async Task CreateZip()
        {
            var token = "YOUR_TOKEN_HERE";
            var config = new PutioConfiguration(token);
            var client = new PutioApiClient(config);
            var folderName = RandomStringGenerator.Generate(10);
            var fileName = RandomStringGenerator.Generate(10);
            
            // Create new folder in root directory
            var newFolder = await client.Files.CreateFolder(new CreateFolderRequest(folderName, 0));
            newFolder.ShouldNotBeNull();
            var folderId = newFolder.Id;

            // Upload image to the new folder
            var fileBytes = System.IO.File.ReadAllBytes($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(FileTests)).Location)}/Data/testimage.jpg");
            await client.Files.UploadFile(new UploadFileRequest(fileBytes, fileName, folderId));

            // Verify the image exists in the folder
            var filesInFolder = await client.Files.ListFiles(new ListFilesRequest
            {
                ParentId = folderId
            });
            filesInFolder.ShouldNotBeNull();
            filesInFolder.Files.ShouldNotBeNull();
            filesInFolder.Files.Count().ShouldBe(1);
            
            // Put the image in a zip
            var zipId = await client.Zips.CreateZip(new CreateZipRequest(filesInFolder.Files.First().Id));
            zipId.ShouldNotBeNull();
            
            // Lis active zip operations
            var zipOperations = await client.Zips.ListZips();
            zipOperations.ShouldNotBeNull();
            zipOperations.Count().ShouldBe(1);

            // Get the status of the zip
            var zip = await client.Zips.GetZip(zipId);
            zip.ShouldNotBeNull();
        }
        
    }
}