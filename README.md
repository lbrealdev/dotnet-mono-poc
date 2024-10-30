# dotnet poc unit tests

## Usage

Start .NET mono docker environment to build the project:
```shell
docker run -it -v $(pwd):/home -w /home mono bash
```

Restore packages:
```shell
nuget restore
```

Build project:
```shell
msbuild ExampleDotNetLib.sln /t:Tests
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
```