# PutIO Sharp

![PutIO](docs/img/logo_black.png)

PutIO Sharp is a C# library for the popular cloud storage service [put.io](https://put.io). This library aims for 100% integration with the public [put.io api](https://app.swaggerhub.com/apis-docs/putio/putio/2.7.0)

## Installation

### Nuget

*NuGet package coming soon*

### Build from Source

If you would prefer to build from source (I recommend using the NuGet package) then simple clone the repo and build with Visual Studio / JetBrains Rider

## Usage

Once you have either installed the NuGet package or manually added a reference to the PutIOSharp DLL you can create a new 'PutIoApiClient` by passing in a new 'PutIoConfiguration'. See the [API Documentation](https://app.swaggerhub.com/apis-docs/putio/putio/2.7.0) for full details.

```csharp
public class Program
{
	public static void Main()
	{
		// Create configuration passing in your api token
		var configuration = new PutIoConfiguration("YOUR_TOKEN_HERE");
        
		// Create the api client passing in the configuration
        	var apiClient = new PutioApiClient(configuration);

		// list account details and setting for the user associated with the api token
        	var accountDetails = apiClient.Account.GetAccountInfo();
		var accountSettings = apiClient.Account.GetAccountSettings();
	}
}
```

## Contributing

If you encounter any issues with this library please open an issue describing your problem in as much details as possible or if you want to make a contribution then open a pull request and I will get back to you as soon as I can.

_This library is not affiliated with put.io is any way_