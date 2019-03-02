var project =  "../Snippet/Snippet.csproj";
var publishDir = "../../.publish";
var version = DateTime.Now.ToString("yy.MM.dd.HHss")

Task("Pack").Does(() => {
    var settings = new DotNetCoreMSBuildSettings();
    settings.Properties["Version"] = new string[] { version };

    DotNetCorePack(project, new DotNetCorePackSettings {
        MSBuildSettings = settings,
        OutputDirectory = publishDir
    });
});

RunTarget("Pack");
