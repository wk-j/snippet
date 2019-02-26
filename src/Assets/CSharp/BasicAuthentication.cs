using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class BasicAuthentication {

    public void Code(string user, string password) {
        var byteArray = Encoding.ASCII.GetBytes($"{user}:{password}");
        var base64 = Convert.ToBase64String(byteArray);
        using (var client = new HttpClient()) {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);
        }
    }
}