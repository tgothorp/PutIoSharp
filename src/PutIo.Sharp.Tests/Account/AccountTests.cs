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

            var accountInfo = await PutioApiClient.GetAccountInfo();
            accountInfo.ShouldNotBeNull();
            accountInfo.Disk.ShouldNotBeNull();
            accountInfo.AccountSettings.ShouldNotBeNull();
        }

        [Fact]
        public async Task ListAccountSettings()
        {
            OverrideApiResponse(HttpStatusCode.OK, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Account/Data/get_account_settings.json"));

            var accountSettings = await PutioApiClient.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
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
            await PutioApiClient.UpdateAccountSettings(request);
        }
    }
}