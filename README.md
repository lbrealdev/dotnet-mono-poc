# dotnet poc unit tests

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




### Run Unit Tests

```shell
 msbuild ExampleDotNetLib.sln /t:Build
```