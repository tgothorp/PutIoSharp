using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Account.Requests;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Error
{
    public class ErrorTests : BaseTest
    {
        [Fact]
        public async Task OnPostAsyncBadRequest_ErrorMappedSuccessfully_ThrowsPutIoException()
        {
            OverrideApiResponse(HttpStatusCode.BadRequest, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Error/Data/data_error.json"));
            
            var exception = await Should.ThrowAsync<PutioException>(async () => await PutioApiClient.UpdateAccountSettings(new UpdateAccountSettingsRequest()));
            exception.ShouldNotBeNull();
            exception.Error.ShouldNotBeNull();
            exception.Error.Id.ShouldBeNull();
            exception.Error.Message.ShouldBe("The browser (or proxy) sent a request that this server could not understand.");
            exception.Error.Type.ShouldBe("BadRequest");
            exception.Error.Uri.ShouldBe("http://api.put.io/v2/docs");
            exception.Error.Status.ShouldBe("ERROR");
            exception.Error.StatusCode.ShouldBe(400);
        }

        [Fact]
        public async Task OnPostAsyncBadRequest_ErrorMessageJsonBadlyFormatted_ExceptionWrappedThrowsPutIoException()
        {
            OverrideApiResponse(HttpStatusCode.BadRequest, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Error/Data/data_bad_error.json"));
            
            var exception = await Should.ThrowAsync<PutioException>(async () => await PutioApiClient.UpdateAccountSettings(new UpdateAccountSettingsRequest()));
            exception.ShouldNotBeNull();
            exception.InnerException.ShouldNotBeNull();
            exception.InnerException.GetType().ShouldBe(typeof(JsonException));
            exception.Error.ShouldBeNull();
        }
    }
}