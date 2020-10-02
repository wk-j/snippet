public Startup(IWebHostEnvironment env) {
    var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("__app__/appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"__app__/appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
    Configuration = builder.Build();
}