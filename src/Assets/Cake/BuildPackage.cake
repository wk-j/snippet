Task("Build-Package").Does(() => {
    DotNetCoreBuild($"src/{name}", new DotNetCoreBuildSettings {
       OutputDirectory = ".deploy",
       ArgumentCustomization = args =>
        args
            .Append("/p:WebPublishMethod=package")
            .Append("/p:DesktopBuildPackageLocation=../../.deploy/A.zip")
            .Append("/p:DeployOnBuild=true")
    });
});
