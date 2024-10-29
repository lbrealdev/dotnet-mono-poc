# dotnet poc unit tests

## Usage

Start .NET mono docker environment to build the project:
```shell
docker run -it -v $(pwd):/home -w /home mono bash
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
```

