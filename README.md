# MattiasCibien.Extensions.Logging.Logcat
A Microsoft.Extensions.Logging implementation using Android Logcat as output

![Nuget](https://github.com/mattiascibien/MattiasCibien.Extensions.Logging.Logcat/actions/workflows/nuget.yml/badge.svg)

## Usage

Install the package using Nuget:

```dotnet add package MattiasCibien.Extensions.Logging.Logcat```

or add it to your project (the `Condition` tag is used to ensure that the library is only available on Android).

```xml
<PackageReference Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'" 
                  Include="MattiasCibien.Extensions.Logging.Logcat" Version="1.0.0" />
```

After that initialize the library using the provided method in `AddLoggging()`.

```csharp

#if ANDROID
using MattiasCibien.Extensions.Logging.Logcat;
#endif

[...]

builder.Services.AddLogging(configure =>
{
	#if ANDROID
	configure.AddLogcat(nameof(MyApp));
	#endif
});
```

The only parameter of the `AddLogcat()` method is the Tag parameter that is desidered. Remember to wrap the definition inside an `#if ANDROID` block as the library
is only available on Android.
