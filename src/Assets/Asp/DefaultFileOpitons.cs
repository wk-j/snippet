class Startup {    
    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            var defaultOptions = new DefaultFilesOptions();
            defaultOptions.DefaultFileNames.Clear();
            defaultOptions.DefaultFileNames.Add("index.html");

            app.UseDefaultFiles(defaultOptions);
            app.UseStaticFiles();

            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
    }
}
