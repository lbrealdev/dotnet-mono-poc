# dotnet poc unit tests

## Usage

Start .NET mono docker environment to build the project:
```shell
docker run -it -v $(pwd):/home -w /home mono /bin/bash

docker run -it -v $(pwd):/home -w /home mono bash
```

Build project:
```shell
msbuild ExampleDotNetLib.sln
```

