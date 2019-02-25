var process = new Process();
var start = new ProcessStartInfo();

start.FileName = "/bin/sh";
start.Arguments = @" -c ""dotnet run --project src/Snippet/Snippet.csproj  -- --path Snippet.Program.cs | bat -l cs""";
start.UseShellExecute = true;

process.StartInfo = start;
process.Start();

