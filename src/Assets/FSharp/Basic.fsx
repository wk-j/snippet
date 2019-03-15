open System.Text
open System.Net.Http.Headers

let basicToken user password =
    let byteArray = Encoding.ASCII.GetBytes(sprintf "%s:%s" user password)
    let base64 = Convert.ToBase64String(byteArray)
    AuthenticationHeaderValue("Basic", base64)
