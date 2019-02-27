#! "netcoreapp2.1"
#r "nuget:Microsoft.Extensions.Configuration,2.2.0"
#r "nuget:Microsoft.Extensions.Configuration.FileExtensions,2.2.0"
#r "nuget:Microsoft.Extensions.Configuration.Json,2.2.0"
#r "nuget:Microsoft.Extensions.Configuration.Binder,2.2.0"

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

class AppSettings { }

static (AppSettings, IConfigurationRoot) LoadAppSettings() {
    var pathToExe = Assembly.GetExecutingAssembly().Location;
    var pathToContentRoot = Path.GetDirectoryName(pathToExe);
    var builder = new ConfigurationBuilder()
            .SetBasePath(pathToContentRoot)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    var configuration = builder.Build();

    var settings = new AppSettings();
    configuration.Bind(settings);
    return (settings, configuration);
}