# iS3-Server

iS3-Server offers some basic functions for common use in infrastructure engineering.

## Requirement

* .Net Framework 4.5.2

## How to run

### Installed from UI

1. Download the whole project
2. Double click `iS3.Server.sln` and open in Visual Studio
3. Right click `iS3.Server` solution in the `Solution Explorer`, and click `Build Solution`. It will take some time for the first time build to download the dependencies
4. Press `F5` or click `run` button to run in debug mode

### Installed from command line

1. `git clone https://github.com/iS3-Project/iS3-Server.git`
2. `cd iS3-Server`
3. `.nuget/NuGet restore`
4. Double click `iS3.Server.sln`, open in Visual Studio and Press `F5` to run in debug mode.

## How to publish

Before publish the project, the config file should be created.

* publish in **Debug** mode: Copy `iS3.Server/Web.Demo.config`, rename to `iS3.Server/Web.Debug.config`, and fill the information
* publish in **Release** mode: Copy `iS3.Server/Web.Demo.config`, rename to `iS3.Server/Web.Release.config`, and fill the information

More informaiton please refer to [web config introduction](https://deanhume.com/working-with-multiple-web-config-files/).

