using System.Threading.Tasks;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Models.Transfers.Requests;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Integration.Tests
{
    public class TransferTests
    {
        [Fact(Skip = "Test should be run locally")]
        public async Task CreateNewTransfer()
        {
            var token = "YOUR_TOKEN_HERE";
            var config = new PutioConfiguration(token);
            var client = new PutIoApiClient(config);

            await client.Transfers.CancelTransfers(new CancelTransfersRequest(59289953));

            // List all transfers
            var allTransfersResponse = await client.Transfers.ListTransfers();
            allTransfersResponse.ShouldNotBeNull();

            // Add transfer
            var addTransferResponse = await client.Transfers.AddTransfer(new AddTransferRequest("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
            addTransferResponse.ShouldNotBeNull();

            // Wait a bit for the transfer to complete
            await Task.Delay(5000);

            // Get status of transfer, it should have completed
            var transferResponse = await client.Transfers.Transfer(addTransferResponse.Id);
            transferResponse.ShouldNotBeNull();

            // Delete the resulting file
            await client.Files.DeleteFiles(new DeleteFilesRequest(transferResponse.FileId.Value));

            // Remove the transfer
            await client.Transfers.CleanTransfers(new CleanTransfersRequest(transferResponse.Id));
        }
    }
}