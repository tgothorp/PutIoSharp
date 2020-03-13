using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Files;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Tests.Integration.Utils;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Integration.Tests
{
    public class FileTests
    {
        [Fact]
        public async Task FolderAndFileUpload()
        {
            var token = "YOUR_TOKEN_HERE";
            var config = new PutioConfiguration(token);
            var client = new PutioApiClient(config);
            var folderName = RandomStringGenerator.Generate(10);
            var fileName = RandomStringGenerator.Generate(10);

            // Create new folder in root directory
            var folder = await client.Files.CreateFolder(new CreateFolderRequest(folderName, 0));
            folder.ShouldNotBeNull();
            folder.NewFolder.ShouldNotBeNull();
            var folderId = folder.NewFolder.Id;

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
            
            var uploadedFile = filesInFolder.Files.First();
            uploadedFile.Name.ShouldStartWith(fileName);
            uploadedFile.FileType.ShouldBe(FileType.File);
            
            // Delete the file
            await client.Files.DeleteFiles(new DeleteFilesRequest(uploadedFile.Id));

            // Verify file no longer exists
            filesInFolder = await client.Files.ListFiles(new ListFilesRequest
            {
                ParentId = folderId
            });
            filesInFolder.ShouldNotBeNull();
            filesInFolder.Files.ShouldNotBeNull();
            filesInFolder.Files.Count().ShouldBe(0);
            
            // Delete the folder
            await client.Files.DeleteFiles(new DeleteFilesRequest(folderId));
        }

        [Fact]
        public async Task ListEveryFileAndFolder()
        {
            var token = "YOUR_TOKEN_HERE";
            var config = new PutioConfiguration(token);
            var client = new PutioApiClient(config);

            var allFileName = new List<string>();
            
            // Start to list files based on the following parameters
            var listFilesResponse = await client.Files.ListFiles(new ListFilesRequest
            {
                ParentId = -1,
                FilePerPage = 25,
            });

            var cursor = listFilesResponse.Cursor;
            allFileName.AddRange(listFilesResponse.Files.Select(x => x.Name));

            // If we have a cursor then continue to list everything until we are done
            while (cursor != null)
            {
                var listFilesContinue = await client.Files.ListFilesContinue(new ListFilesContinueRequest(cursor, 25));
                allFileName.AddRange(listFilesContinue.Files.Select(x => x.Name));
                cursor = listFilesContinue.Cursor;
            }

            allFileName.ForEach(x => Debug.WriteLine(x));
        }
    }
}