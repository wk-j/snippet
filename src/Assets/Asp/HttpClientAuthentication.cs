private void RegisterHttpClient(IServiceCollection services, AppSettings settings) {
    services.AddHttpClient();
    void Config(HttpClient options) {
        var content = settings.ContentOptions;
        var url = content.Url;
        var user = content.User;
        var password = content.Password;
        var base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));

        options.BaseAddress = new Uri(url);
        options.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64);
    }
    services.AddHttpClient<DiscountController>("content-client")
        .ConfigureHttpClient(Config);
}