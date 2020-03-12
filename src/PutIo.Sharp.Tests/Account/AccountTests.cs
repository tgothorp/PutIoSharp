using System.IO;
using System.Net;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Account.Requests;
using PutIo.Sharp.Models.Shared;
using PutIo.Sharp.Tests.Error;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Account
{
    public class AccountTests : BaseTest
    {
        [Fact]
        public async Task ListAccountInfo()
        {
            OverrideApiResponse(HttpStatusCode.OK, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Account/Data/get_account_info.json"));

            var accountInfo = await PutioApiClient.Account.GetAccountInfo();
            accountInfo.ShouldNotBeNull();
            accountInfo.Status.ShouldBe("OK");
            accountInfo.AccountInfo.ShouldNotBeNull();
            accountInfo.AccountInfo.Disk.ShouldNotBeNull();
            accountInfo.AccountInfo.AccountSettings.ShouldNotBeNull();
        }

        [Fact]
        public async Task ListAccountSettings()
        {
            OverrideApiResponse(HttpStatusCode.OK, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Account/Data/get_account_settings.json"));

            var accountSettings = await PutioApiClient.Account.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
            accountSettings.Status.ShouldBe("OK");
            accountSettings.Settings.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateAccountSettings()
        {
            var request = new UpdateAccountSettingsRequest
            {
                IsInvisible = true,
                DefaultDownloadFolder = 0,
                DefaultSubtitleLanguage = SubtitleLanguage.English,
                SecondarySubtitleLanguage = SubtitleLanguage.Spanish
            };

            OverrideApiResponse(HttpStatusCode.OK, "{}");
            await PutioApiClient.Account.UpdateAccountSettings(request);
        }
    }
}