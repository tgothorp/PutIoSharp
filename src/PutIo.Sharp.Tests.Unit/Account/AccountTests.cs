using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Account.Requests;
using PutIo.Sharp.Models.Shared;
using PutIo.Sharp.Tests.Unit.Error;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Account
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

            var info = accountInfo.AccountInfo;
            info.AccountActive.ShouldBeTrue();
            info.AvatarUrl.ShouldBe("https://www.gravatar.com/avatar/00000000000000000000000000000000.jpg?s=50");
            info.CanCreateSubAccount.ShouldBeFalse();
            info.CanInviteFriend.ShouldBeTrue();
            info.DaysUntilFilesDeletion.ShouldBe(0);
            info.FamilyOwner.ShouldBe("ExampleUsername");
            info.FilesWillBeDeletedAt.ShouldBeNull();
            info.HasVoucher.ShouldBeFalse();
            info.IsInvitedFriend.ShouldBeFalse();
            info.IsSubAccount.ShouldBeFalse();
            info.Mail.ShouldBe("example@email.com");
            info.OauthTokenId.ShouldBe(1234567);
            
            info.PlanExpirationDate.ShouldNotBeNull();
            info.PlanExpirationDate.Value.Year.ShouldBe(2020);
            info.PlanExpirationDate.Value.Month.ShouldBe(03);
            info.PlanExpirationDate.Value.Day.ShouldBe(13);
            info.PlanExpirationDate.Value.Hour.ShouldBe(1);
            info.PlanExpirationDate.Value.Minute.ShouldBe(53);
            info.PlanExpirationDate.Value.Second.ShouldBe(27);
            
            info.PrivateDownloadHostIp.ShouldBeNull();
            info.SimultaneousDownloadLimit.ShouldBe(15);
            
            info.SubtitleLanguages.Count.ShouldBe(1);
            info.SubtitleLanguages.ShouldContain(SubtitleLanguage.English);
            
            info.UserId.ShouldBe(123456);
            info.Username.ShouldBe("ExampleUsername");
            
            info.Disk.Available.ShouldBe(16794461277);
            info.Disk.Size.ShouldBe(53687091200);
            info.Disk.Used.ShouldBe(36892629923);
            
            info.AccountSettings.BetaUser.ShouldBeTrue();
            info.AccountSettings.CallbackUrl.ShouldBeNull();
            info.AccountSettings.DarkTheme.ShouldBeFalse();
            info.AccountSettings.DefaultDownloadFolder.ShouldBe(0);
            info.AccountSettings.FluidLayout.ShouldBeFalse();
            info.AccountSettings.HistoryEnabled.ShouldBeTrue();
            info.AccountSettings.IsInvisible.ShouldBeTrue();
            info.AccountSettings.Locale.ShouldBeNull();
            info.AccountSettings.LoginMailsEnabled.ShouldBeTrue();
            info.AccountSettings.NextEpisode.ShouldBeTrue();
            info.AccountSettings.PushoverToken.ShouldBeNull();
            info.AccountSettings.SortBy.ShouldBe(FileSort.DateCreatedDescending);
            info.AccountSettings.StartFrom.ShouldBeFalse();
            
            info.AccountSettings.SubtitleLanguages.Count.ShouldBe(1);
            info.AccountSettings.SubtitleLanguages.ShouldContain(SubtitleLanguage.English);
            
            info.AccountSettings.TheaterMode.ShouldBeTrue();
            info.AccountSettings.TransferSortBy.ShouldBeNull();
            info.AccountSettings.TrashEnabled.ShouldBeTrue();
            info.AccountSettings.TunnelRouteName.ShouldBe("London");
            info.AccountSettings.UsePrivateDownloadIp.ShouldBeFalse();
            info.AccountSettings.VideoPlayer.ShouldBeNull();
        }

        [Fact]
        public async Task ListAccountSettings()
        {
            OverrideApiResponse(HttpStatusCode.OK, File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ErrorTests)).Location)}/Account/Data/get_account_settings.json"));

            var accountSettings = await PutioApiClient.Account.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
            accountSettings.Status.ShouldBe("OK");
            accountSettings.Settings.ShouldNotBeNull();
            
            accountSettings.Settings.BetaUser.ShouldBeTrue();
            accountSettings.Settings.CallbackUrl.ShouldBeNull();
            accountSettings.Settings.DarkTheme.ShouldBeTrue();
            accountSettings.Settings.DefaultDownloadFolder.ShouldBe(0);
            accountSettings.Settings.FluidLayout.ShouldBeFalse();
            accountSettings.Settings.HistoryEnabled.ShouldBeTrue();
            accountSettings.Settings.IsInvisible.ShouldBeTrue();
            accountSettings.Settings.Locale.ShouldBeNull();
            accountSettings.Settings.LoginMailsEnabled.ShouldBeTrue();
            accountSettings.Settings.NextEpisode.ShouldBeTrue();
            accountSettings.Settings.PushoverToken.ShouldBeNull();
            accountSettings.Settings.SortBy.ShouldBe(FileSort.DateCreatedDescending);
            accountSettings.Settings.StartFrom.ShouldBeFalse();
            
            accountSettings.Settings.SubtitleLanguages.Count.ShouldBe(1);
            accountSettings.Settings.SubtitleLanguages.ShouldContain(SubtitleLanguage.English);
            
            accountSettings.Settings.TheaterMode.ShouldBeTrue();
            accountSettings.Settings.TransferSortBy.ShouldBeNull();
            accountSettings.Settings.TrashEnabled.ShouldBeTrue();
            accountSettings.Settings.TunnelRouteName.ShouldBe("London");
            accountSettings.Settings.UsePrivateDownloadIp.ShouldBeFalse();
            accountSettings.Settings.VideoPlayer.ShouldBeNull();
        }
    }
}