# .NET Framework - Mono NUnit PoC

## Usage

Start .NET mono docker environment to build the project:
```shell
docker pull mono:latest

docker run -it -v $(pwd):/home -w /home mono bash
```

Restore packages:
```shell
nuget restore
```

Build project:
```shell
msbuild ExampleDotNetLib.sln /t:Build
```



## .NET tricks

```shell
docker run -it -v $(pwd):/home -w /home mcr.microsoft.com/dotnet/core/sdk:3.1 bash

docker run -it -v $(pwd):/home -w /home mcr.microsoft.com/dotnet/sdk:6.0 bash

dotnet new nunit -o ExampleDotNetLib.Tests

dotnet sln add ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj

nuget locals all -clear

mono packages/NUnit.ConsoleRunner.*/tools/nunit3-console.exe ExampleDotNetLib.Tests/bin/Debug/net48/ExampleDotNetLib.Tests.dll

mono packages/NUnit.ConsoleRunner.3.11.1/tools/nunit3-console.exe ExampleDotNetLib.Tests/bin/Debug/net48/ExampleDotNetLib.Tests.dll
```

```shell
msbuild ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj -t:BuildTarget -p:Configuration=Debug


msbuild /p:OutputPath=TestOutput ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj



msbuild ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj -p:Configuration=Debug /verbosity:diagnostic




msbuild ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj -t:Build








nuget restore

nuget list -Source /root/.nuget/packages

msbuild ExampleDotNetLib.sln

msbuild ExampleDotNetLib.Tests/ExampleDotNetLib.Tests.csproj

mono packages/NUnit.ConsoleRunner.3.10.0/tools/nunit3-console.exe ExampleDotNetLib.Tests/bin/Debug/net48/ExampleDotNetLib.Tests.dll



```

### Sources

- https://stackoverflow.com/questions/3304741/how-do-i-fix-a-type-or-namespace-name-could-not-be-found-error-in-visual-studi

### JetBrains Rider IDE

- https://www.jetbrains.com/help/rider/Installation_guide.html
- https://www.jetbrains.com/dotnet/download/system-requirements/#section-rider
- https://rider-support.jetbrains.com/hc/en-us/articles/207335749-Using-Rider-under-Linux-prerequisites

### Install Toolbox App

Check if `libfuse2` is installed:
```shell
apt list --installed | grep libfuse2
```

Download JetBrains Toolbox App from web page:

- https://www.jetbrains.com/toolbox-app/

https://www.jetbrains.com/toolbox-app/download/download-thanks.html?platform=linux

Extract tar package:
```shell
tar -xvf jetbrains-toolbox-*.tar.gz
```

Install ToolBox App:
```shell
./jetbrains-toolbox
```

### Install Mono project

- [Mono download](https://www.mono-project.com/download/stable/#download-lin-debian)

Check if dependencies are installed:
```shell
apt list --installed | grep -E 'dirmngr|ca-certificates|gnupg'
```

Add create mono keyring:
```shell
gpg --homedir /tmp --no-default-keyring --keyring /usr/share/keyrings/mono-official-archive-keyring.gpg --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
```

Create mono source.list in source.list directory:
```shell
echo "deb [signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] https://download.mono-project.com/repo/debian stable-buster main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
```

Run apt update:
```shell
sudo apt update
```

Install `mono-devel`, `msbuild` and `nuget` packages:
```shell
apt install mono-devel msbuild nuget -y
```


### Fix dotnet errors:

- Error:
```shell
Process terminated. Couldn't find a valid ICU package installed on the system. Set the configuration flag System.Globalization.Invariant to true if you want to run with no globalization support.
   at System.Environment.FailFast(System.String)
   at System.Globalization.GlobalizationMode.GetGlobalizationInvariantMode()
   at System.Globalization.GlobalizationMode..cctor()
   at System.Globalization.CultureData.CreateCultureWithInvariantData()
   at System.Globalization.CultureData.get_Invariant()
   at System.Globalization.CultureInfo..cctor()
   at System.String.ToLowerInvariant()
   at Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.GetArch()
   at Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment..cctor()
   at Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.GetRuntimeIdentifier()
   at Microsoft.DotNet.Cli.MulticoreJitProfilePathCalculator.CalculateProfileRootPath()
   at Microsoft.DotNet.Cli.MulticoreJitActivator.StartCliProfileOptimization()
   at Microsoft.DotNet.Cli.MulticoreJitActivator.TryActivateMulticoreJit()
   at Microsoft.DotNet.Cli.Program.Main(System.String[])
Aborted
```

- Solution:
```shell
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
```

- Error:
```shell
No usable version of libssl was found
Aborted
```

- Solution:
```shell
// to do
```

### Run Unit Tests

```shell
 msbuild ExampleDotNetLib.sln /t:Build
```

### Dotnet Links

- https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian#use-apt-to-update-net
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#manual-install
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian#unable-to-locate--some-packages-could-not-be-installed
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-snap-sdk
- https://dotnet.microsoft.com/en-us/download/dotnet
- https://dotnet.microsoft.com/en-us/download/dotnet/3.1
- https://docs.github.com/en/actions/use-cases-and-examples/building-and-testing/building-and-testing-net
- https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script?WT.mc_id=dotnet-35129-website
- https://dotnet.microsoft.com/en-us/download/dotnet/scripts
- https://stackoverflow.com/questions/59119904/process-terminated-couldnt-find-a-valid-icu-package-installed-on-the-system-in
- https://learn.microsoft.com/en-us/dotnet/core/install/remove-runtime-sdk-versions?pivots=os-linux
- https://rider-support.jetbrains.com/hc/en-us/community/posts/11788971319570-Unable-to-connect-to-MSBuild-process-to-load-project
- https://stackoverflow.com/questions/43048629/netcore-project-loading-failed-in-jetbrains-rider-on-windows
- https://stackoverflow.com/questions/62328211/dotnet-in-rider-cannot-resolve-symbol-microsoft



### Dotnet commands

```shell
dotnet --list-sdks
```

```shell
dotnet --list-runtime
```