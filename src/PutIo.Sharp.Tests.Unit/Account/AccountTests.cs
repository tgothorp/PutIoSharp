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

            var info = await PutioApiClient.Account.GetAccountInfo();
            info.ShouldNotBeNull();
            info.Disk.ShouldNotBeNull();
            info.AccountSettings.ShouldNotBeNull();
            
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
            
            accountSettings.BetaUser.ShouldBeTrue();
            accountSettings.CallbackUrl.ShouldBeNull();
            accountSettings.DarkTheme.ShouldBeTrue();
            accountSettings.DefaultDownloadFolder.ShouldBe(0);
            accountSettings.FluidLayout.ShouldBeFalse();
            accountSettings.HistoryEnabled.ShouldBeTrue();
            accountSettings.IsInvisible.ShouldBeTrue();
            accountSettings.Locale.ShouldBeNull();
            accountSettings.LoginMailsEnabled.ShouldBeTrue();
            accountSettings.NextEpisode.ShouldBeTrue();
            accountSettings.PushoverToken.ShouldBeNull();
            accountSettings.SortBy.ShouldBe(FileSort.DateCreatedDescending);
            accountSettings.StartFrom.ShouldBeFalse();
            
            accountSettings.SubtitleLanguages.Count.ShouldBe(1);
            accountSettings.SubtitleLanguages.ShouldContain(SubtitleLanguage.English);
            
            accountSettings.TheaterMode.ShouldBeTrue();
            accountSettings.TransferSortBy.ShouldBeNull();
            accountSettings.TrashEnabled.ShouldBeTrue();
            accountSettings.TunnelRouteName.ShouldBe("London");
            accountSettings.UsePrivateDownloadIp.ShouldBeFalse();
            accountSettings.VideoPlayer.ShouldBeNull();
        }
    }
}