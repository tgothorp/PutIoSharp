<p align="center">
	<img src="docs/img/logo_black.png" alt="Put.io Logo" title="The Put.io logo" width="410" height="100" />
</p>

___
# PutIO Sharp <img src="https://img.shields.io/nuget/dt/PutIoSharp"/>

PutIO Sharp is a C# library for the popular cloud storage service [put.io](https://put.io). This library aims for 100% integration with the public [put.io api.](https://app.swaggerhub.com/apis-docs/putio/putio/2.7.0)

**Note: The config endpoints are not current implemented.**

## Installation

### Nuget

Visit the [Nuget Page](https://www.nuget.org/packages/PutIoSharp/) or run the package manager command:

	Install-Package PutIoSharp

or run the dotnet command from the dotnet cli:

	dotnet add package PutIoSharp

### Build from Source

If you would prefer to build from source (I recommend using the NuGet package) then simply clone the repo and build with Visual Studio / JetBrains Rider.

## Usage

### Authentication

You will need to authenticate users so you can request a OAuth token to make subsequent calls.

**Prerequisites**
 - You will need a put.io account, you can [create one here](https://put.io/plans/).
 - You will need to create a new OAuth app from your [app settings](https://app.put.io/settings/account/oauth/apps) (Make a note of your app id).

Once you have you application setup with put.io you can start the authentication procedure.
```csharp
public class Program
{
	static async Task Main(string[] args)
	{
		using (var putIoAuthClient = new PutIoAuthClient())
		{
			// Generate a code for the user to enter at http://put.io/link
			var code = await putIoAuthClient.GetCode(new GetCodeRequest("YOUR_APP_ID"));

			// One the user has entered the code you can exchange it for a OAuth Token
			var token = await putIoAuthClient.GetToken(code);
		}
	}
}
```


### Making Requests

Once you have a valid api token for a user, you can proceed to make calls against their account

```csharp
public class Program
{
	static async Task Main(string[] args)
	{
		var configuration = new PutioConfiguration("YOUR_TOKEN_HERE");

		// Create the api client passing in the configuration
		using (var apiClient = new PutIoApiClient(configuration))
		{
			// list account details and setting for the user associated with the api token
			var accountDetails = await apiClient.Account.GetAccountInfo();
			var accountSettings = await apiClient.Account.GetAccountSettings();
		}
	}
}
```

## Contributing

If you encounter any issues with this library please open an issue describing your problem in as much details as possible or if you want to make a contribution then open a pull request and I will get back to you as soon as I can.

_This library is not affiliated with put.io is any way_