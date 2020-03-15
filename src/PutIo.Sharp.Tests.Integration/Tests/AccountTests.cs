using System.Threading.Tasks;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;
using PutIo.Sharp.Models.Account.Requests;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Integration.Tests
{
    public class AccountTests
    {
        [Fact]
        public async Task UpdateAccountSettings()
        {
            var token = "YOUR_TOKEN_HERE";
            var config = new PutioConfiguration(token);
            var client = new PutioApiClient(config);

            // Get account info for the user
            var accountInfo = await client.Account.GetAccountInfo();
            accountInfo.ShouldNotBeNull();

            // Get account settings
            var accountSettings = await client.Account.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
            
            // Set IsInvisible to true
            var updateAccountSettings = new UpdateAccountSettingsRequest
            {
                IsInvisible = true
            };

            await client.Account.UpdateAccountSettings(updateAccountSettings);
            
            // Verify setting has been updated
            accountSettings = await client.Account.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
            accountSettings.Settings.IsInvisible.ShouldBeTrue();
            
            // Set IsInvisible to false
            updateAccountSettings = new UpdateAccountSettingsRequest
            {
                IsInvisible = false
            };

            await client.Account.UpdateAccountSettings(updateAccountSettings);
            
            // Verify settings has been updated
            accountSettings = await client.Account.GetAccountSettings();
            accountSettings.ShouldNotBeNull();
            accountSettings.Settings.IsInvisible.ShouldBeFalse();
        }
    }
}